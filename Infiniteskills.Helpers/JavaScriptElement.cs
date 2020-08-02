using System;
using System.Web;

namespace Infiniteskills.Helpers
{
   public class JavaScriptElement : IHtmlString
   {
      public HtmlString Write(string code) 
      {
         return new HtmlString(HttpUtility.HtmlDecode(code));
      }
      public HtmlString WriteLine(string code)
      {
         return this.Write(code + "\n");
      }
      public string ToHtmlString()
      {
         return ToString();
      }
   }
}
