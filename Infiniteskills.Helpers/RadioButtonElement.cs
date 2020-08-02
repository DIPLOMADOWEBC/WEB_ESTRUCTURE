
using Infiniteskills.Common;
using System;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Helpers
{
   public class RadioButtonElement : BaseElement, IHtmlString
   {
      private object _attributes = null;
      private string _checked = String.Empty;

      public RadioButtonElement(string name, string isChecked)
         : base(name, String.Empty)
      {
         _checked = isChecked;
      }

      public RadioButtonElement(string name, string value, string isChecked, string columnClass, string label)
         : base(name, value, columnClass, label, String.Empty)
      {
         _checked = isChecked;
      }
      public override string RenderElement()
      {
         TagBuilder tb = this.CreateInputTag(ElementType.Checkbox, _attributes, false);
         tb.Attributes.Remove("class");

         if (!tb.Attributes.ContainsKey("checked"))
         {
            if ((_checked == HabilitadoConstante.HABILITADO || _checked == EstadoConstante.ACTIVO) || _checked == "true" || _checked == "TRUE")
               tb.Attributes.Add("checked", "checked");
         }

         if (this.ColumnInput != null && this.ColumnInput != "")
         {
            TagBuilder div = new TagBuilder("div");
            TagBuilder divCheckBox = new TagBuilder("div");
            TagBuilder label = new TagBuilder("label");
            div.Attributes.Add("class", this.ColumnInput);
            divCheckBox.Attributes.Add("class", "checkbox");
            label.InnerHtml = tb.ToString() + this.LabelText;
            divCheckBox.InnerHtml = label.ToString();
            div.InnerHtml = divCheckBox.ToString();

            return div.ToString();
         }
         return tb.ToString() + this.LabelText;
      }

      public override string ToString()
      {
         return RenderElement();
      }

      public string ToHtmlString()
      {
         return ToString();
      }

      public RadioButtonElement Attributes(object value)
      {
         _attributes = value;
         return this;
      }

   }
}
