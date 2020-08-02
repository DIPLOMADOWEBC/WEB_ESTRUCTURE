using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.LG
{
    public class LGAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LG";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LG_default",
                "LG/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}