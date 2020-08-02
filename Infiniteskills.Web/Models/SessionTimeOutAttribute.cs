using Infiniteskills.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web
{
    public class SessionTimeOutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;

            if (context.Session != null)
            {
                if (context.Session[VariableSesionConstante.USUARIO_NOMBRE] == null)
                {
                    context.Response.Redirect("~/Login/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}