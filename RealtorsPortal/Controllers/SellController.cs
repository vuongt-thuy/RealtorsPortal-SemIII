using BusinessLogicLayer.Mapper;
using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using RealtorsPortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Controllers
{
    public class SellController : Controller
    {

        private Respository<Category> resCat;
        private Respository<Country> resCountry;
        private Respository<Ads> resAds;

        public SellController()
        {
            resCat = new Respository<Category>();
            resCountry = new Respository<Country>();
            resAds = new Respository<Ads>();
        }

        public ActionResult Index()
        {
            var ads = resAds.GetAll().Where(x => x.Status == SystemConstant.APPROVED).Select(x => new AdsMapper().Mapping(x));
            ViewBag.countries = resCountry.GetAll().Select(x => new CountryMapper().Mapping(x));
            ViewBag.categories = resCat.GetAll().Select(x => new CategoryMapper().Mapping(x));
            return View(ads);
        }

        public JsonResult FilterByPrice()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}