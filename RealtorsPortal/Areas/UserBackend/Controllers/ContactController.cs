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
            var listAds = resAds.GetList(x => x.PackageOfUser.UserId == user.Id).ToList();

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
            return View(contacts);
        }
    }
}