using RealtorsPortal.Areas.UserBackend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.UserBackend.Controllers
{

    public class ArticleController : Controller
    {
        // GET: UserBackend/Article
        [CustomeAuthentication]
        public ActionResult All()
        {
            return View("ListAll");
        }

        [CustomeAuthentication]
        public ActionResult PostedArticle()
        {
            return View("ListPosted");
        }


        public ActionResult Create()
        {
            return View();
        }


        [CustomeAuthentication]
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}