using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
   public enum LabelStateType
   {
      label_default = 0,
      label_primary = 1,
      label_success = 2,
      label_info = 3,
      label_warning = 4,
      label_danger = 5
   }

    public class LabelStateElement : BaseElement, IHtmlString
    {
        private object _attributes = null;
        private object _attributesLabel = null;
        private LabelStateType _labelStateType = LabelStateType.label_default;
        
        public LabelStateElement(string name, string value,LabelStateType type)
            : base(name, value)
        {
            _labelStateType = type;
        }
        public LabelStateElement(string name, string value,LabelStateType type, string colinput)
            : base(name, value, colinput)
        {
             _labelStateType = type;
        }
        public LabelStateElement(string name, string value,LabelStateType type, string colinput, string labeltext, string collabel)
            : base(name, value, colinput, labeltext, collabel)
        {
             _labelStateType = type;
        }

        public override string RenderElement()
        {
            TagBuilder tbdiv = new TagBuilder("div");

            TagBuilder tb = new TagBuilder("div");
            tb.AddCssClass("label");
            tb.AddCssClass(_labelStateType.ToString().Replace("_", "-").ToLower());
            tb.InnerHtml = Value;

            if (_attributes != null)
                tb.MergeAttributes(new RouteValueDictionary(_attributes));

            if (this.ColumnInput != null && this.ColumnInput != "")
            {
                tbdiv.AddCssClass(this.ColumnInput);
                tbdiv.InnerHtml = tb.ToString();
            }
            else
                return tb.ToString();

            if (this.LabelText != null && this.LabelText != "")
            {
                TagBuilder tblbl = new TagBuilder("label");
                tblbl.Attributes.Add("for", this.Id);

                tblbl.AddCssClass("control-label");
                tblbl.AddCssClass(this.ColumnLabel);

                tblbl.InnerHtml = this.LabelText;

                if (_attributesLabel != null)
                    tblbl.MergeAttributes(new RouteValueDictionary(_attributesLabel));
                return tblbl.ToString() + tbdiv.ToString();
            }

            return tbdiv.ToString();
        }

        public override string ToString()
        {
            return RenderElement();
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public LabelStateElement Attributes(object value)
        {
            _attributes = value;
            return this;
        }

        public LabelStateElement AttributesLabel(object value)
        {
            _attributesLabel = value;
            return this;
        }

    }
}
