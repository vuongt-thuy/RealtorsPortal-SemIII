﻿using RealtorsPortal.Areas.UserBackend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.UserBackend.Controllers
{
    [CustomeAuthentication]
    public class UserController : Controller
    {
        // GET: UserBackend/User
        public ActionResult Information()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}