using System.Web.Mvc;

namespace DagusBlog.Areas.Adminstration
{
    public class AdminstrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Adminstration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Adminstration_default",
                "Adminstration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            //       context.MapRoute(
            //    "Adminstration_default",
            //    "Adminstration/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional },
            //    new { controller = "Posts" },
            //    new[] { "DagusBlog.Areas.Administration.Controllers" }
            //);
        }
    }
}