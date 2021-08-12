using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RealtorsPortal.Areas.UserBackend.Utils
{
    public class CustomeAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] != null)
            {
                return;
            }
            filterContext.Result = new RedirectResult("/");
        }
    }
}