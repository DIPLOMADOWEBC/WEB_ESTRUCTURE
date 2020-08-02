using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.OP
{
    public class OPAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OP_default",
                "OP/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}