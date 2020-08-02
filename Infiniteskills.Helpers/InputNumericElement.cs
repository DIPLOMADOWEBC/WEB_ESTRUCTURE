using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
   public class NumericType
   {
      public static readonly string Integer = "integer";
      public static readonly string Decimal = "decimal";
   }
   public class InputNumericElement : BaseElement, IHtmlString
   {
      private object _attributes = null;
      private object _attributesLabel = null;
      private string _cantDecimales = "*";
      private string _cantEnteros = "+";
      private bool _signomenos = false;
      private bool _signomas = false;
      private string _decimalseparator = ".";
      private string _groupseparator = ",";
      private int _groupsize = 3;
      private string _numericType = NumericType.Integer;
      private bool _digitalOption = false;

      public InputNumericElement(string name, object value)
         : base(name, value == null ? "0" : value.ToString())
      {

      }
      public InputNumericElement(string name, object value, string colinput)
         : base(name, value == null ? "0" : value.ToString(), colinput)
      {

      }
      public InputNumericElement(string name, object value, string colinput, string labeltext, string collabel)
         : base(name, value == null ? "0" : value.ToString(), colinput, labeltext, collabel)
      {

      }

      public override string RenderElement()
      {
         TagBuilder tblbl = new TagBuilder("label");
         TagBuilder div = new TagBuilder("div");
         TagBuilder tb = new TagBuilder("input");
         TagBuilder tbJS = new TagBuilder("script");


         tb.GenerateId(this.Id);
         tb.Attributes.Add("type", "text");
         tb.Attributes.Add("name", this.Id);
         tb.AddCssClass("form-control");
         tb.AddCssClass("inputnumeric-element");

         if (this.Value != "")
            tb.Attributes.Add("value", this.Value);

         if (this._attributes != null)
            tb.MergeAttributes(new RouteValueDictionary(this._attributes));

         if (this.ColumnInput != null && this.ColumnInput != "")
         {
            div.Attributes.Add("class", this.ColumnInput);
            div.InnerHtml = tb.ToString();
         }

         tbJS.Attributes.Add("type", "text/javascript");
         tbJS.InnerHtml = " $(\"#" + this.Id + "\").inputmask({";
         tbJS.InnerHtml += "alias:  \"" + _numericType + "\"";
         tbJS.InnerHtml += ",allowMinus: " + _signomenos.ToString().ToLower();
         tbJS.InnerHtml += ",allowPlus: " + _signomenos.ToString().ToLower();
         if (_numericType == NumericType.Decimal)
         {
            tbJS.InnerHtml += ",autoGroup: true";
            tbJS.InnerHtml += ",radixPoint: \"" + _decimalseparator + "\"";
            tbJS.InnerHtml += ",groupSeparator: \"" + _groupseparator + "\"";
            tbJS.InnerHtml += ",groupSize: " + _groupsize;

            tbJS.InnerHtml += ",digits: \"" + _cantDecimales + "\"";
            tbJS.InnerHtml += ",integerDigits:  \"" + _cantEnteros + "\"";
            tbJS.InnerHtml += ",digitsOptional: " + _digitalOption.ToString().ToLower();
            }
         else 
         {
            if(!String.IsNullOrEmpty(_cantEnteros))
               tbJS.InnerHtml += ",integerDigits:  \"" + _cantEnteros + "\"";
         }

         tbJS.InnerHtml += "});";


         if (this.LabelText != null && this.LabelText != "")
         {
            tblbl.Attributes.Add("for", this.Id);
            tblbl.AddCssClass("control-label");
            tblbl.AddCssClass(this.ColumnLabel);
            tblbl.InnerHtml = this.LabelText;

            if (_attributesLabel != null)
               tblbl.MergeAttributes(new RouteValueDictionary(_attributesLabel));
         }

         return string.Concat((this.LabelText != null && this.LabelText != "") ? tblbl.ToString() : "",
            (this.ColumnInput != null && this.ColumnInput != "") ? div.ToString() : tb.ToString(),
            tbJS.ToString());
      }

      public override string ToString()
      {
         return RenderElement();
      }

      public string ToHtmlString()
      {
         return ToString();
      }

      public InputNumericElement Attributes(object value)
      {
         _attributes = value;
         return this;
      }
      public InputNumericElement AttributesLabel(object value)
      {
         _attributesLabel = value;
         return this;
      }
      public InputNumericElement CantidadDecimales(int value)
      {
         _cantDecimales = value.ToString();
         return this;
      }
      public InputNumericElement CantidadEnteros(int value)
      {
         _cantEnteros = value.ToString();
         return this;
      }

      public InputNumericElement TextNumericType(string value)
      {
         _numericType = value;
         return this;
      }
      public InputNumericElement SignoMenos(bool value)
      {
         _signomenos = value;
         return this;
      }
      public InputNumericElement SignoMas(bool value)
      {
         _signomas = value;
         return this;
      }
      public InputNumericElement DecimalSeparator(string value)
      {
         _decimalseparator = value;
         return this;
      }
      public InputNumericElement GroupSeparator(string value)
      {
         _groupseparator = value;
         return this;
      }
      public InputNumericElement GroupSize(int value)
      {
         _groupsize = value;
         return this;
      }


   }
}
