using System;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Helpers
{
    public enum ButtonElementType
    {
        Submit = 4,
        Image = 5,
        Reset = 6,
        Button = 7,
    }

    public class InputButtonElement : BaseElement, IHtmlString
    {
        private object _attributes = null;
        private ButtonElementType _buttonElementType = ButtonElementType.Button;
        private string _value = "";
        private string _onClick = "";
        private string _imgSrc = "";

        public InputButtonElement(string name, object htmlAttributes)
           : base(name, "")
        {
            _attributes = htmlAttributes;
        }

        public override string RenderElement()
        {

            TagBuilder tb = this.CreateInputTag((ElementType)Enum.Parse(typeof(ElementType), ((int)_buttonElementType).ToString()), _attributes);
            TagBuilder tbSpan = new TagBuilder("span");

            if (_value != "")
                tb.Attributes.Add("value", _value);

            if (_onClick != "")
                tb.Attributes.Add("onclick", _onClick);

            if (_imgSrc != "")
                tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(_imgSrc));

            tb.AddCssClass("btn btn-primary  btn-sm btn-block");
         
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

        public InputButtonElement ElementType(ButtonElementType value)
        {
            _buttonElementType = value;
            return this;
        }

        public new InputButtonElement Value(string value)
        {
            _value = value;
            return this;
        }

        public InputButtonElement OnClick(string value)
        {
            _onClick = value;
            return this;
        }
        public InputButtonElement ImagePath(string value)
        {
            _imgSrc = value;
            return this;
        }
    }
}
