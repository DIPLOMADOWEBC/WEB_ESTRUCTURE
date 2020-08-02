using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Helpers
{
   public class ButtonElement : BaseElement, IHtmlString
   {
      private object _attributes = null;
      private string _value = "";
      private string _onClick = "";

      public ButtonElement(string name, object htmlAttributes)
         : base(name,"")
      {
         _attributes = htmlAttributes;
      }

      public override string RenderElement()
      {

         TagBuilder tb = new TagBuilder("button");
         tb.GenerateId(this.Id);
         tb.Attributes.Add("name", tb.Attributes["id"]);

         if (_value != "")
            tb.InnerHtml = _value;

         if (_onClick != "")
            tb.Attributes.Add("onclick", _onClick);

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

      public new ButtonElement Value(string value)
      {
         _value = value;
         return this;
      }

      public ButtonElement OnClick(string value)
      {
         _onClick = value;
         return this;
      }
   }
}
