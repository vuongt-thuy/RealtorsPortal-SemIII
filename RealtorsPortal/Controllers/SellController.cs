using BusinessLogicLayer.Mapper;
using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.ViewModel;
using RealtorsPortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Controllers
{
    public class SellController : Controller
    {

        private Respository<Category> resCat;
        private Respository<Country> resCountry;
        private Respository<Ads> resAds;
        private Respository<Contact> resContact;

        public SellController()
        {
            resCat = new Respository<Category>();
            resCountry = new Respository<Country>();
            resAds = new Respository<Ads>();
            resContact = new Respository<Contact>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.countries = resCountry.GetAll().Select(x => new CountryMapper().Mapping(x));
            ViewBag.categories = resCat.GetAll().Where(x => x.Active == true).Select(x => new CategoryMapper().Mapping(x));
            return View();
        }

        public ActionResult LoadAds(int catId, int countryId, string strPrice, string sortBy, string startDate, string endDate, int page = 1)
        {
            var ads = resAds.GetAll().Where(x => x.Need == SystemConstant.NEED_SELL && x.Status == SystemConstant.APPROVED).Select(x => new AdsMapper().Mapping(x));
            var result = new List<AdsViewModel>();

            result = ads.ToList();

            #region FILTER BY CATEGORY
            if (catId != 0)
            {
                result = result.Where(x => x.CategoryId == catId).ToList();

            }
            #endregion

            #region FILTER BY COUNTRY
            if (countryId != 0)
            {
                result = result.Where(x => x.CountryId == countryId).ToList();

            }
            #endregion

            #region FILTER BY PRICE
            if (!String.IsNullOrEmpty(strPrice))
            {
                double priceStart = 0;
                double priceEnd = 0;

                string[] price = strPrice.Split(new Char[] { '-' });

                if (price.Length == 2)
                {
                    priceStart = Double.Parse(price[0]);
                    priceEnd = Double.Parse(price[1]);

                    result = result.Where(x => x.Price >= priceStart && x.Price <= priceEnd).ToList();
                }
                else
                {
                    priceStart = Double.Parse(price[0]);
                    result = result.Where(x => x.Price >= priceStart).ToList();
                }

            }

            #endregion

            #region FILTER BY DATE
            if (startDate != null && endDate != null)
            {
                DateTime dtStartDate = DateTime.Parse(startDate);
                DateTime dtEndDate = DateTime.Parse(endDate);
                result = result.Where(x => x.CreatedAt >= dtStartDate && x.CreatedAt <= dtEndDate).ToList();
            }
            #endregion

            #region SORT
            if (sortBy == SystemConstant.SORT_ALPHABET_ASCENDING)
            {
                result = result.OrderBy(x => x.Title).ToList();
            }
            else if (sortBy == SystemConstant.SORT_ALPHABET_DECENDING)
            {
                result = result.OrderByDescending(x => x.Title).ToList();
            }
            else if (sortBy == SystemConstant.SORT_BY_PRICE_ASCENDING)
            {
                result = result.OrderBy(x => x.Price).ToList();
            }
            else if (sortBy == SystemConstant.SORT_BY_PRICE_DECENDING)
            {
                result = result.OrderByDescending(x => x.Price).ToList();
            }
            #endregion
            ViewBag.countAds = result.Count;

            #region PAGINATION
            int limit = 2;
            int totalPage = (int)Math.Ceiling((decimal)result.Count / limit);
            result = result.Skip((page - 1) * limit).Take(limit).ToList();

            ViewBag.totalPage = totalPage;
            ViewBag.currentPage = page;
            #endregion
            return PartialView("~/Views/Common/_ListAds.cshtml", result);
        }

        public JsonResult FilterByPrice()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAds(int id)
        {
            var ads = new AdsMapper().Mapping(resAds.FindById(id));
            return Json(ads, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AdsDetail(int id)
        {
            var ads = new AdsMapper().Mapping(resAds.FindById(id));
            var allAds = resAds.GetList(x => x.Status == SystemConstant.APPROVED && x.Need == SystemConstant.NEED_SELL && x.CategoryId == ads.CategoryId).ToList();
            int index = allAds.FindIndex(x => x.Id == ads.Id);
            ViewBag.adsRelateds = allAds.Where(x => x != allAds.ElementAtOrDefault(index))
                .Select(x => new AdsMapper().Mapping(x))
                .OrderByDescending(x => x.Id)
                .Take(5);
            ViewBag.categories = resCat.GetAll()
                                .Select(x => new CategoryMapper().Mapping(x))
                                .OrderByDescending(x => x.TotalAds).Where(x => x.Active == true)
                                .Take(5);
            return View("~/Views/Common/AdsDetail.cshtml", ads);
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            bool check = false;
            if (ModelState.IsValid)
            {
                contact.Status = false;
                contact.CreatedAt = DateTime.Now;
                contact.UpdatedAt = DateTime.Now;

                if (resContact.Create(contact))
                {
                    check = true;
                    return Json(new ResponeJSON<Contact>
                    {
                        statusCode = 200,
                        msg = "Contact successfully!",
                        data = null
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            if(check == true)
            {
                SendEmail.Notification(contact.Email, "Contact",
                       "We have received your information. Please wait for communication from Realtors Portal!");
            }

            Dictionary<string, string> errors = new Dictionary<string, string>();
            foreach (var k in ModelState.Keys)
            {
                foreach (var err in ModelState[k].Errors)
                {
                    string key = Regex.Replace(k, @"(\w+)\.(\w+)", @"$2");
                    if (!errors.ContainsKey(key))
                    {
                        errors.Add(key, err.ErrorMessage);
                    }
                }
            }
            return Json(new ResponeJSON<Dictionary<string, string>>
            {
                statusCode = 201,
                msg = "Contact fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }
    }
}