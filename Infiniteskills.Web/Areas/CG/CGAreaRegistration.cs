using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.CG
{
    public class CGAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CG";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CG_default",
                "CG/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}