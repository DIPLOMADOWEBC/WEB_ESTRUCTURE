using Infiniteskills.Helpers;
using System.Web.Mvc;

namespace Infiniteskills.Helpers
{
   public static class HtmlHelperExtension
   {
       public static ElementFactory CRM(this HtmlHelper helper)
      {
         return new ElementFactory(helper);
      }

       public static ElementFactory<TModel> CRM<TModel>(this HtmlHelper<TModel> helper)
      {
         return new ElementFactory<TModel>(helper);
      }
   }
}
