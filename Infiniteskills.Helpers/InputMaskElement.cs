using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
   public class InputMaskElement : BaseElement, IHtmlString
   {
      private object _attributes = null;
      private object _attributesLabel = null;
      private string _mask = null;

      public InputMaskElement(string name, string value)
         : base(name,value)
      {
      }
      public InputMaskElement(string name, string value, string colinput)
         : base(name, value, colinput)
      {

      }
      public InputMaskElement(string name, string value, string colinput, string labeltext, string collabel)
         : base(name, value, colinput, labeltext, collabel)
      {

      }

      public override string RenderElement()
      {
         TagBuilder tb = this.CreateInputTag(ElementType.Text, _attributes);


         TagBuilder tbJS = new TagBuilder("script");
         tbJS.Attributes.Add("type", "text/javascript");
         
         if(!string.IsNullOrEmpty(_mask))
            tbJS.InnerHtml = " $(\"#" + this.Id + "\").inputmask(\"" + _mask + "\");";
         
         if (this.LabelText != null && this.LabelText != "")
         {
            TagBuilder tblbl = new TagBuilder("label");
            tblbl.Attributes.Add("for", this.Id);

            tblbl.AddCssClass("control-label");
            tblbl.AddCssClass(this.ColumnLabel);

            tblbl.InnerHtml = this.LabelText;

            if (_attributesLabel != null)
               tblbl.MergeAttributes(new RouteValueDictionary(_attributesLabel));
            return tblbl.ToString() + tb.ToString() + (string.IsNullOrEmpty(_mask) ? "" : tbJS.ToString());
         }

         return tb.ToString() + (string.IsNullOrEmpty(_mask) ? "" : tbJS.ToString());

      }

      public override string ToString()
      {
         return RenderElement();
      }

      public string ToHtmlString()
      {
         return ToString();
      }

      public InputMaskElement Attributes(object value)
      {
         _attributes = value;
         return this;
      }

      public InputMaskElement AttributesLabel(object value)
      {
         _attributesLabel = value;
         return this;
      }

      public InputMaskElement Mask(string value)
      {
         _mask = value;
         return this;
      }

   }
}
