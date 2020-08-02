using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
   public enum DateTimePickerType
   {
      Date = 0,
      Time = 1,
      DateTime = 3
   }

   public class DateTimePickerElement : BaseElement, IHtmlString
   {
      private object _attributes = null;
      private object _attributesLabel = null;
      private DateTimePickerType _dateTimePickerType = DateTimePickerType.DateTime;
      private DateTime? _value = null;
      private string _format = string.Concat(System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern.ToUpper()," HH:mm");
      private string _formatValue = string.Concat(System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern, " HH:mm");
      private DateTime? _minDate;
      private DateTime? _maxDate;
      private bool _time12Hour = false;

      public DateTimePickerElement(string name)
         : base(name, String.Empty)
      {

      }
      public DateTimePickerElement(string name, string colDateTimePicker)
         : base(name, String.Empty, colDateTimePicker)
      {

      }
      public DateTimePickerElement(string name, string colDateTimePicker, string labelOption, string colLabel)
         : base(name, String.Empty, colDateTimePicker, labelOption, colLabel)
      {

      }

      public DateTimePickerElement(string name, DateTime? value, string colDateTimePicker, string labelOption, string colLabel)
         : base(name, String.Empty, colDateTimePicker, labelOption, colLabel)
      {
         _value = value;
      }

      public override string RenderElement()
      {

         string idDiv = string.Concat("_div", this.Id);
         TagBuilder tbdiv = new TagBuilder("div");
         if (this.ColumnInput != String.Empty)
            tbdiv.AddCssClass(this.ColumnInput);

         TagBuilder tbdivDate = new TagBuilder("div");
         tbdivDate.Attributes.Add("id",idDiv);
         tbdivDate.Attributes.Add("name", idDiv);
         tbdivDate.AddCssClass("input-group date");

         TagBuilder tbinput = new TagBuilder("input");
         tbinput.Attributes.Add("type", InputType.Text.ToString().ToLower());
         tbinput.AddCssClass("form-control");
         tbinput.GenerateId(this.Id);
         tbinput.Attributes.Add("name", this.Id);

         switch (this._dateTimePickerType)
         {
            case DateTimePickerType.Date:
               _format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern.ToUpper();
               _formatValue = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
               break;
            case DateTimePickerType.Time:
               _format = "HH:mm:ss";
               _formatValue = _format;
               break;
         }

         if (_value.HasValue)
            tbinput.Attributes.Add("value", _format == null ? _value.ToString() : _value.Value.ToString(_formatValue));

         if (_format != null && _format != String.Empty)
            tbinput.Attributes.Add("data-format", _format);

         TagBuilder tbspan = new TagBuilder("span");
         tbspan.Attributes.Add("class", "input-group-addon");
         tbspan.InnerHtml = "<span class=\"glyphicon-calendar glyphicon\"></span>";

         if (_attributes != null)
            tbinput.MergeAttributes(new RouteValueDictionary(_attributes));

         tbdivDate.InnerHtml = tbinput.ToString() + tbspan.ToString();
         tbdiv.InnerHtml = tbdivDate.ToString();

         TagBuilder tbJS = new TagBuilder("script");
         tbJS.Attributes.Add("type", "text/javascript");
         tbJS.InnerHtml = string.Format("$(function() {{ $('#{0}').datetimepicker({{", idDiv);
         switch (this._dateTimePickerType)
         {
            case DateTimePickerType.Date:
               tbJS.InnerHtml += string.Concat("format: '",_format,"' ,");
               break;
            case DateTimePickerType.Time:
               tbJS.InnerHtml += string.Concat("format: '",_format,"' ,");
               break;
         }

         //tbJS.InnerHtml += "pick12HourFormat : " + _time12Hour.ToString().ToLower();
         if (_minDate != null)
            tbJS.InnerHtml += "startDate : new Date(" + _minDate.Value.Year.ToString() + ", " + _minDate.Value.Month.ToString() + ", " + _minDate.Value.Day.ToString() + ", " + _minDate.Value.Hour.ToString() + ", " + _minDate.Value.Minute.ToString() + ") ,";

         if (_maxDate != null)
            tbJS.InnerHtml += "startDate : new Date(" + _maxDate.Value.Year.ToString() + ", " + _maxDate.Value.Month.ToString() + ", " + _maxDate.Value.Day.ToString() + ", " + _maxDate.Value.Hour.ToString() + ", " + _maxDate.Value.Minute.ToString() + ") ,";

         tbJS.InnerHtml += " format : '" + _format + "'";
         //tbJS.InnerHtml += ", language : 'en'";
         tbJS.InnerHtml += " });});";

         if (this.LabelText != null && this.LabelText != String.Empty)
         {
            TagBuilder tblbl = new TagBuilder("label");
            tblbl.Attributes.Add("for", this.Id);
            tblbl.AddCssClass("control-label");
            tblbl.AddCssClass(this.ColumnLabel);
            tblbl.InnerHtml = this.LabelText;

            if (_attributesLabel != null)
               tblbl.MergeAttributes(new RouteValueDictionary(_attributesLabel));
            return tblbl.ToString() + tbdiv.ToString() + tbJS.ToString();
         }

         return tbdiv.ToString() + tbJS.ToString();
      }
      public override string ToString()
      {
         return RenderElement();
      }
      public string ToHtmlString()
      {
         return ToString();
      }
      public DateTimePickerElement PickerType(DateTimePickerType value)
      {
         _dateTimePickerType = value;
         return this;
      }
      public new DateTimePickerElement Value(DateTime? value)
      {
         _value = value;
         return this;
      }
      public DateTimePickerElement Format(string value)
      {
         _format = value;
         return this;
      }
      public DateTimePickerElement MinDate(DateTime? value)
      {
         _minDate = value;
         return this;
      }
      public DateTimePickerElement MaxDate(DateTime? value)
      {
         _maxDate = value;
         return this;
      }
      public DateTimePickerElement Attributes(object value)
      {
         _attributes = value;
         return this;
      }
      public DateTimePickerElement AttributesLabel(object value)
      {
         _attributes = value;
         return this;
      }
      public DateTimePickerElement Time12Hour(bool value)
      {
         _time12Hour = value;
         return this;
      }
   }
}
