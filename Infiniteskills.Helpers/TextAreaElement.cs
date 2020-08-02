using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
   public class TextAreaElement : BaseElement, IHtmlString
   {
      private object _attributes = null;
      private object _attributesLabel = null;
      private int _rows = 3;

      public TextAreaElement(string name, string value)
         : base(name, value)
      {

      }
      public TextAreaElement(string name, string value, string colinput)
         : base(name, value, colinput)
      {

      }
      public TextAreaElement(string name, string value, string colinput, string labeltext, string collabel)
         : base(name, value, colinput, labeltext, collabel)
      {

      }

      public override string RenderElement()
      {

         TagBuilder tb = new TagBuilder("textarea");
         TagBuilder div = new TagBuilder("div");

         tb.GenerateId(this.Id);
         tb.Attributes.Add("name", tb.Attributes["id"]);
         tb.Attributes.Add("rows", _rows.ToString());

         tb.Attributes.Add("class", "form-control");

         if (this.Value != "")
            tb.InnerHtml = this.Value;
         
         if (_attributes != null)
            tb.MergeAttributes(new RouteValueDictionary(_attributes));

         if (this.ColumnInput != null && this.ColumnInput != "")
         {
            div.Attributes.Add("class", this.ColumnInput);
            div.InnerHtml = tb.ToString();
         }

         if (this.LabelText != null && this.LabelText != "")
         {
            TagBuilder tblbl = new TagBuilder("label");
            tblbl.Attributes.Add("for", this.Id);

            tblbl.AddCssClass("control-label");
            tblbl.AddCssClass(this.ColumnLabel);

            tblbl.InnerHtml = this.LabelText;

            if (_attributesLabel != null)
               tblbl.MergeAttributes(new RouteValueDictionary(_attributesLabel));
            return tblbl.ToString() + div.ToString();
         }

         return div.ToString();
      }

      public override string ToString()
      {
         return RenderElement();
      }

      public string ToHtmlString()
      {
         return ToString();
      }

      public TextAreaElement Attributes(object value)
      {
         _attributes = value;
         return this;
      }

      public TextAreaElement AttributesLabel(object value)
      {
         _attributesLabel = value;
         return this;
      }
      public TextAreaElement Rows(int value)
      {
         _rows = value;
         return this;
      }
   }
}
