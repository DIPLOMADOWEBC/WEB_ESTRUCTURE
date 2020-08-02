using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
    public class InputElement : BaseElement, IHtmlString
    {
        private object _attributes = null;
        private object _attributesLabel = null;

        public InputElement(string name, string value)
            : base(name, value)
        {

        }
        public InputElement(string name, string value, string colinput)
            : base(name, value, colinput)
        {

        }
        public InputElement(string name, string value, string colinput, string labeltext,string collabel)
            : base(name, value, colinput, labeltext, collabel)
        {

        }

        public override string RenderElement()
        {
            TagBuilder tb = this.CreateInputTag(ElementType.Text, _attributes);

            if (this.LabelText != null && this.LabelText != "")
            {
                TagBuilder tblbl = new TagBuilder("label");
                tblbl.Attributes.Add("for", this.Id);

                tblbl.AddCssClass("control-label");
                tblbl.AddCssClass(this.ColumnLabel);

                tblbl.InnerHtml = this.LabelText;

                if (_attributesLabel != null)
                    tblbl.MergeAttributes(new RouteValueDictionary(_attributesLabel));
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

        public InputElement Attributes(object value)
        {
            _attributes = value;
            return this;
        }

        public InputElement AttributesLabel(object value)
        {
            _attributesLabel = value;
            return this;
        }

    }
}
