using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
    public class ColorPickerElement : BaseElement, IHtmlString
    {
        private object _attributes = null;
        private object _attributesLabel = null;

        public ColorPickerElement(string name, string value)
            : base(name, value)
        {

        }
        public ColorPickerElement(string name, string value, string colinput)
            : base(name, value, colinput)
        {

        }
        public ColorPickerElement(string name, string value, string colinput, string labeltext, string collabel)
            : base(name, value, colinput, labeltext, collabel)
        {

        }

        public override string RenderElement()
        {
            
           TagBuilder tbDiv = new TagBuilder("div");
           tbDiv.Attributes.Add("id", string.Concat(this.Id, "-picker"));
           tbDiv.AddCssClass("input-group");

           if(!string.IsNullOrEmpty(this.ColumnInput))
              tbDiv.AddCssClass(this.ColumnInput);

           TagBuilder tb = this.CreateInputTag(ElementType.Text, _attributes,false);
           tbDiv.InnerHtml = tb.ToString();

           TagBuilder tbSpan = new TagBuilder("span");
           tbSpan.AddCssClass("input-group-addon");
           tbSpan.InnerHtml = "<i></i>";
           tbDiv.InnerHtml = string.Concat(tbDiv.InnerHtml, tbSpan.ToString());

           TagBuilder JS = new TagBuilder("script");
           JS.Attributes.Add("type", "text/javascript");
           JS.InnerHtml = string.Concat("$(function(){$('#",this.Id, "-picker", "').colorpicker();});");

           if (this.LabelText != null && this.LabelText != "")
            {
                TagBuilder tblbl = new TagBuilder("label");
                tblbl.Attributes.Add("for", this.Id);

                tblbl.AddCssClass("control-label");
                tblbl.AddCssClass(this.ColumnLabel);

                tblbl.InnerHtml = this.LabelText;

                if (_attributesLabel != null)
                    tblbl.MergeAttributes(new RouteValueDictionary(_attributesLabel));
                return string.Concat(tblbl.ToString(),tbDiv.ToString(),JS.ToString()) ;
            }

           return string.Concat(tbDiv.ToString(),JS.ToString());


        }

        public override string ToString()
        {
            return RenderElement();
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public ColorPickerElement Attributes(object value)
        {
            _attributes = value;
            return this;
        }

        public ColorPickerElement AttributesLabel(object value)
        {
            _attributesLabel = value;
            return this;
        }

    }
}
