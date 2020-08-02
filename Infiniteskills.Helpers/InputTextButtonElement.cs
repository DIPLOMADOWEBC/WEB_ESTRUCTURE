using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
    public class InputTextButtonElement : BaseElement, IHtmlString
    {
        private object _attributes = null;
        private object _attributesLabel = null;
        private string _textButton = string.Empty;
        private string _fontButton = string.Empty;
        private string _imgButton = string.Empty;
        private string _onButtonClick = string.Empty;

        public InputTextButtonElement(string name, string value)
           : base(name, value)
        {

        }
        public InputTextButtonElement(string name, string value, string colinput)
           : base(name, value, colinput)
        {

        }
        public InputTextButtonElement(string name, string value, string colinput, string labeltext, string collabel)
           : base(name, value, colinput, labeltext, collabel)
        {

        }

        public override string RenderElement()
        {
            TagBuilder tbIGroup = new TagBuilder("div");
            tbIGroup.AddCssClass("input-group");

            TagBuilder tbInput = new TagBuilder("input");
            tbInput.GenerateId(this.Id);
            tbInput.Attributes.Add("name", this.Id);
            tbInput.Attributes.Add("type", ElementType.Text.ToString().ToLower());
            tbInput.AddCssClass("form-control");
            if (Value != "")
                tbInput.Attributes.Add("value", Value);
            if (_attributes != null)
                tbInput.MergeAttributes(new RouteValueDictionary(_attributes));

            TagBuilder tbSpan = new TagBuilder("span");
            tbSpan.AddCssClass("input-group-addon");

            TagBuilder tbButton = new TagBuilder("span");
            //tbButton.AddCssClass("btn btn-default");
            //tbButton.Attributes.Add("type", "button");

            if (!String.IsNullOrEmpty(this._onButtonClick))
                tbSpan.Attributes.Add("onclick", this._onButtonClick);


            if (!String.IsNullOrEmpty(this._textButton))
                tbButton.InnerHtml = this._textButton;
            else if (!String.IsNullOrEmpty(this._fontButton))
                tbButton.InnerHtml = string.Concat("<span class=\"", this._fontButton, "\" aria-hidden=\"true\"></span>");
            else if (!String.IsNullOrEmpty(this._imgButton))
                tbButton.InnerHtml = string.Concat("<img src=\"", this._imgButton, "\" alt=\"+\" />");

            tbSpan.InnerHtml = tbButton.ToString();
            tbIGroup.InnerHtml = tbInput.ToString() + tbSpan.ToString();

            TagBuilder tbDiv = new TagBuilder("div");
            if (!String.IsNullOrEmpty(this.ColumnInput))
            {
                tbDiv.AddCssClass(this.ColumnInput);
                tbDiv.InnerHtml = tbIGroup.ToString();
            }

            if (this.LabelText != null && this.LabelText != string.Empty)
            {
                TagBuilder tblbl = new TagBuilder("label");
                tblbl.Attributes.Add("for", this.Id);

                tblbl.AddCssClass("control-label");
                tblbl.AddCssClass(this.ColumnLabel);

                tblbl.InnerHtml = this.LabelText;

                if (_attributesLabel != null)
                    tblbl.MergeAttributes(new RouteValueDictionary(_attributesLabel));
                return tblbl.ToString() + tbDiv.ToString();
            }

            if (!String.IsNullOrEmpty(this.ColumnInput))
                return tbDiv.ToString();
            else
                return tbIGroup.ToString();
        }

        public override string ToString()
        {
            return RenderElement();
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public InputTextButtonElement Attributes(object value)
        {
            _attributes = value;
            return this;
        }

        public InputTextButtonElement AttributesLabel(object value)
        {
            _attributesLabel = value;
            return this;
        }

        public InputTextButtonElement OnButtonClick(string value)
        {
            _onButtonClick = value;
            return this;
        }

        public InputTextButtonElement TextButton(string value)
        {
            _textButton = value;
            return this;
        }

        public InputTextButtonElement FontButton(string value)
        {
            _fontButton = value;
            return this;
        }

        public InputTextButtonElement UrlImgButton(string value)
        {
            _imgButton = value;
            return this;
        }

    }
}
