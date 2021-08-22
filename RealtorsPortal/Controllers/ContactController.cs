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
    public class ContactController : Controller
    {
        private Respository<Contact> resContact;

        public ContactController()
        {
            resContact = new Respository<Contact>();
        }

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            if(ModelState.IsValid)
            {
                contact.Status = false;
                contact.CreatedAt = DateTime.Now;
                contact.UpdatedAt = DateTime.Now;

                if(resContact.Create(contact))
                {
                    SendEmail.Notification(contact.Email, "Contact", 
                        "We have received your information. Please wait for communication from Realtors Portal!");
                    return View();
                }
            }
            return View(contact);
        }
    }
}