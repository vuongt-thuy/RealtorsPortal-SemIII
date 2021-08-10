using System.Web.Mvc;

namespace RealtorsPortal.Areas.UserBackend
{
    public class UserBackendAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UserBackend";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UserBackend_main",
                "UserBackend/",
               new { action = "Information", controller = "User" }
            );


            context.MapRoute(
                "Article_Create",
                "Article/Create",
                new { action = "Create", controller = "Article" }
            );

            context.MapRoute(
                "Article_Edit",
                "Article/Edit/{id}",
                new { action = "Edit", controller = "Article", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "UserBackend_default",
                "UserBackend/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}