using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
   public class PasswordElement : BaseElement, IHtmlString
   {
      private object _attributes = null;
      private object _labelAttributes = null;

      public PasswordElement(string name, string value, string columnClass, string label, string labelColumnClass)
         : base(name, value, columnClass, label, labelColumnClass)
      {

      }

      public override string RenderElement()
      {

         TagBuilder tb = this.CreateInputTag(ElementType.Password, _attributes);

         if (this.LabelText != null && this.LabelText != "")
         {
            TagBuilder tblbl = new TagBuilder("label");
            tblbl.Attributes.Add("for", this.Id);

            tblbl.AddCssClass("control-label");
            tblbl.AddCssClass(this.ColumnLabel);

            tblbl.InnerHtml = this.LabelText;

            if (_labelAttributes != null)
               tblbl.MergeAttributes(new RouteValueDictionary(_labelAttributes));
            return tblbl.ToString() + tb.ToString();
         }

         return tb.ToString();
      }

      public override string ToString()
      {
         return RenderElement();
      }

      public string ToHtmlString()
      {
         return ToString();
      }

      public PasswordElement Attributes(object value)
      {
         _attributes = value;
         return this;
      }

      public PasswordElement LabelAttributes(object value)
      {
         _labelAttributes = value;
         return this;
      }
   }
}
