using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
   public enum ElementType
   {
      Text = 0,
      Password = 1,
      Checkbox = 2,
      Radio = 3,
      Submit = 4,
      Image = 5,
      Reset = 6,
      Button = 7,
      Hidden = 8,
      File = 9,
   }

   public class BaseElement
   {
      private string _id = string.Empty;
      private string _value = "";
      private string _labelText = "";
      private string _columnLabel = "";
      private string _columnInput = "";

      public string Id
      {
         get { return _id; }
      }

      public string Value
      {
         get { return _value; }
      }

      public string LabelText
      {
         get { return _labelText; }
      }
      public string ColumnLabel
      {
         get { return _columnLabel; }
      }

      public string ColumnInput
      {
         get { return _columnInput; }
      }


      public BaseElement(string name)
      {
         _id = name;
      }

      public BaseElement(string name, string value)
      {
         _id = name;
         _value = value;
      }

      public BaseElement(string name, string value, string colinput)
      {
         _id = name;
         _value = value;
         _columnInput = colinput;
      }

      public BaseElement(string name, string value, string colinput, string labeltext, string collabel)
      {
         _id = name;
         _value = value;
         _columnInput = colinput;
         _labelText = labeltext;
         _columnLabel = collabel;
      }

      public virtual string RenderElement()
      {
         return "";
      }

      public TagBuilder CreateInputTag(ElementType type, object htmlAttributes, bool includeParentDiv)
      {

         TagBuilder tb = new TagBuilder("input");
         tb.GenerateId(_id);
         tb.Attributes.Add("type", type.ToString().ToLower());
         tb.Attributes.Add("name", _id);
         tb.AddCssClass("form-control");
         if (_value != "")
            tb.Attributes.Add("value", _value);

         if (htmlAttributes != null)
            tb.MergeAttributes(new RouteValueDictionary(htmlAttributes));

         if (includeParentDiv)
            if (_columnInput != null && _columnInput != "")
            {
               TagBuilder div = new TagBuilder("div");
               div.Attributes.Add("class", _columnInput);
               div.InnerHtml = tb.ToString();
               return div;
            }

         return tb;
      }

      public TagBuilder CreateInputTag(ElementType type, object htmlAttributes)
      {
         return CreateInputTag(type, htmlAttributes, true);
      }
   }

}
