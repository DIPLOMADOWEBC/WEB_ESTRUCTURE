using System;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Helpers
{
   public class DatePickerElement : BaseElement, IHtmlString
   {
      private object _attributes = null;
      private DateTime? _date = null;
      private ViewContext _vc = null;

      public DatePickerElement(ViewContext vc, string name, DateTime? value)
         : base(name, "")
      {
         _date = value;
         _vc = vc;
      }

      public DatePickerElement(ViewContext vc, string name, DateTime value)
         : base(name, "")
      {
         _date = value;
         _vc = vc;
      }

      public override string RenderElement()
      {

         TagBuilder tb = this.CreateInputTag(ElementType.Text, _attributes);

         if (!tb.Attributes.ContainsKey("class"))
         {
            tb.Attributes.Add("class", "datepicker-element");
         }

         if (_date != null)
            tb.Attributes["value"] = _date.Value.ToShortDateString();

         string strJS = string.Format(@"jQuery(function ($) {{ $('#{0}').mask('{1}'); }});", this.Id, "99/99/9999");

         UrlHelper urlH = new UrlHelper(_vc.RequestContext);

         TagBuilder tbJS = new TagBuilder("script");
         tbJS.Attributes.Add("type", "text/javascript");
         tbJS.InnerHtml += strJS;
         tbJS.InnerHtml += string.Format(@"$(function() {{$('#{0}').datepicker({{dateFormat: 'dd/mm/yy',changeMonth: 
            true,changeYear: true ,showOn:'button',buttonImage:'" + urlH.Content("~/content/images/calendar.gif") + "',buttonImageOnly: true}})}});", this.Id);

         return tbJS.ToString() + tb.ToString();
      }

      public override string ToString()
      {
         return RenderElement();
      }

      public string ToHtmlString()
      {
         return ToString();
      }

      public DatePickerElement Attributes(object value)
      {
         _attributes = value;
         return this;
      }

   }
}
