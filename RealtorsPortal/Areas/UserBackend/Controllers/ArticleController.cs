using RealtorsPortal.Areas.UserBackend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.UserBackend.Controllers
{
    [CustomeAuthentication]
    public class ArticleController : Controller
    {
        // GET: UserBackend/Article

        public ActionResult All()
        {
            return View("ListAll");
        }

        public ActionResult PostedArticle()
        {
            return View("ListPosted");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}