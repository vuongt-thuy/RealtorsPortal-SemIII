using BusinessLogicLayer.Mapper;
using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using RealtorsPortal.Areas.UserBackend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.UserBackend.Controllers
{
    [CustomeAuthentication]
    public class ContactController : Controller
    {
        private Respository<Contact> resContact;
        private Respository<Ads> resAds;

        public ContactController ()
        {
            resContact = new Respository<Contact>();
            resAds = new Respository<Ads>();
        }

        public ActionResult Index()
        {
            var user = (User) Session["user"];
            var listAds = resAds.GetList(x => x.UserId == user.Id);

            List<Contact> contacts = new List<Contact>();
            foreach (var ads in listAds)
            {
                foreach (var ct in resContact.GetAll())
                {
                    if(ct.AdsId == ads.Id)
                    {
                        contacts.Add(ct);
                    }
                }
            }
            return View(contacts.Select(x => new ContactMapper().Mapping(x)));
        }

        public ActionResult Detail(int id)
        {
            var user = (User)Session["user"];
            var contact = resContact.FindById(id);
            if (contact.Ads.User.Id == user.Id)
            {
                return View(new ContactMapper().Mapping(contact));
            }
            return View("~/Areas/UserBackend/Views/Shared/_Error404.cshtml");
        }

        [HttpPost]
        public JsonResult Edit(int id, bool status)
        {
            var contact = resContact.FindById(id);
            contact.Status = status;
            contact.UpdatedAt = DateTime.Now;

            if (resContact.Update(contact))
            {
                return Json(new ResponeJSON<string>() {
                    statusCode = 200,
                    msg = "Oke",
                    data = ""
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponeJSON<string>()
            {
                statusCode = 201,
                msg = "Update Status Fail!",
                data = ""
            }, JsonRequestBehavior.AllowGet);
        }
    }
}