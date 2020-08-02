
using Infiniteskills.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace Infiniteskills.Helpers
{
    public class ElementFactory
    {
    
        public ElementFactory(HtmlHelper helper)
        {
            this.HtmlHelper = helper;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HtmlHelper HtmlHelper
        {
            get;
            set;
        }
        public GridElement Grid()
        {
            return new GridElement();
        }
        public InputMaskElement MaskedTextBox(string name)
        {
            return new InputMaskElement(name, String.Empty);
        }

        public InputMaskElement MaskedTextBox(string name, string value)
        {
            return new InputMaskElement(name, value);
        }
        public InputMaskElement MaskedTextBox(string name, string value, string colinput)
        {
            return new InputMaskElement(name, value, colinput);
        }

        public InputMaskElement MaskedTextBox(string name, string value, string colinput, string optionlabel, string coloptionlabel)
        {
            return new InputMaskElement(name, value, colinput, optionlabel, coloptionlabel);
        }
        public InputElement TextBox(string name)
        {
            return new InputElement(name, String.Empty);
        }
        public InputElement TextBox(string name, string value)
        {
            return new InputElement(name, value);
        }
        public InputElement TextBox(string name, string value, string colinput)
        {
            return new InputElement(name, value, colinput);
        }

        public InputElement TextBox(string name, string value, string colinput, string optionlabel, string coloptionlabel)
        {
            return new InputElement(name, value, colinput, optionlabel, coloptionlabel);
        }

        public ColorPickerElement TextBoxColorPicker(string name)
        {
            return new ColorPickerElement(name, String.Empty);
        }

        public ColorPickerElement TextBoxColorPicker(string name, string value)
        {
            return new ColorPickerElement(name, value);
        }

        public ColorPickerElement TextBoxColorPicker(string name, string value, string colinput)
        {
            return new ColorPickerElement(name, value, colinput);
        }

        public ColorPickerElement TextBoxColorPicker(string name, string value, string colinput, string optionlabel, string coloptionlabel)
        {
            return new ColorPickerElement(name, value, colinput, optionlabel, coloptionlabel);
        }

        public InputTextButtonElement TextBoxButton(string name)
        {
            return new InputTextButtonElement(name, String.Empty);
        }

        public InputTextButtonElement TextBoxButton(string name, string value)
        {
            return new InputTextButtonElement(name, value);
        }

        public InputTextButtonElement TextBoxButton(string name, string value, string colinput)
        {
            return new InputTextButtonElement(name, value, colinput);
        }

        public InputTextButtonElement TextBoxButton(string name, string value, string colinput, string optionlabel, string coloptionlabel)
        {
            return new InputTextButtonElement(name, value, colinput, optionlabel, coloptionlabel);
        }

        public TextAreaElement TextArea(string name)
        {
            return new TextAreaElement(name, String.Empty);
        }

        public TextAreaElement TextArea(string name, string value)
        {
            return new TextAreaElement(name, value);
        }

        public TextAreaElement TextArea(string name, string value, string colinput)
        {
            return new TextAreaElement(name, value, colinput);
        }

        public TextAreaElement TextArea(string name, string value, string colinput, string optionlabel, string coloptionlabel)
        {
            return new TextAreaElement(name, value, colinput, optionlabel, coloptionlabel);
        }

        public DateTimePickerElement DateTimePicker(string name)
        {
            return new DateTimePickerElement(name, String.Empty);
        }

        public DateTimePickerElement DateTimePicker(string name, string colinput)
        {
            return new DateTimePickerElement(name, colinput);
        }

        public DateTimePickerElement DateTimePicker(string name, string colinput, string optionlabel, string coloptionlabel)
        {
            return new DateTimePickerElement(name, colinput, optionlabel, coloptionlabel);
        }
        public DateTimePickerElement DateTimePicker(string name, DateTime? value, string colinput, string optionlabel, string coloptionlabel)
        {
            return new DateTimePickerElement(name, value, colinput, optionlabel, coloptionlabel);
        }

        public LabelStateElement LabelState(string name, string value, LabelStateType type)
        {
            return new LabelStateElement(name, value, type);
        }

        public LabelStateElement LabelState(string name, string value, LabelStateType type, string colinput)
        {
            return new LabelStateElement(name, value, type, colinput);
        }

        public LabelStateElement LabelState(string name, string value, LabelStateType type, string colinput, string optionlabel, string coloptionlabel)
        {
            return new LabelStateElement(name, value, type, colinput, optionlabel, coloptionlabel);
        }

        public PasswordElement Password(string name, string value, string columnClass, string label, string labelColumnClass)
        {
            return new PasswordElement(name, value, columnClass, label, labelColumnClass);
        }

        public CheckBoxElement CheckBox(string name, string value, string columnClass, string label)
        {
            return new CheckBoxElement(name, value, columnClass, label);
        }
        public RadioButtonElement RadioButtonElement(string name, string value, string isChecked, string columnClass, string label)
        {
            return new RadioButtonElement(name, value, isChecked, columnClass, label);
        }
        public InputNumericElement NumericTextBox(string name)
        {
            return new InputNumericElement(name, null);
        }

        public InputNumericElement NumericTextBox(string name, Decimal? value)
        {
            return new InputNumericElement(name, value);
        }

        public InputNumericElement NumericTextBox(string name, Decimal? value, string colinput)
        {
            return new InputNumericElement(name, value, colinput);
        }

        public InputNumericElement NumericTextBox(string name, Decimal? value, string colinput, string optionlabel, string coloptionlabel)
        {
            return new InputNumericElement(name, value, colinput, optionlabel, coloptionlabel);
        }

        public InputNumericElement NumericTextBox(string name, float? value)
        {
            return new InputNumericElement(name, value);
        }
        public InputNumericElement NumericTextBox(string name, float? value, string colinput)
        {
            return new InputNumericElement(name, value, colinput);
        }

        public InputNumericElement NumericTextBox(string name, float? value, string colinput, string optionlabel, string coloptionlabel)
        {
            return new InputNumericElement(name, value, colinput, optionlabel, coloptionlabel);
        }

        public InputNumericElement NumericTextBox(string name, int? value)
        {
            return new InputNumericElement(name, value);
        }
        public InputNumericElement NumericTextBox(string name, int? value, string colinput)
        {
            return new InputNumericElement(name, value, colinput);
        }
        public InputNumericElement NumericTextBox(string name, int? value, string colinput, string optionlabel, string coloptionlabel)
        {
            return new InputNumericElement(name, value, colinput, optionlabel, coloptionlabel);
        }

        public InputButtonElement InputButton(string name, object htmlAttributes)
        {
            return new InputButtonElement(name, htmlAttributes);
        }

        public InputButtonElement InputButton(string name)
        {
            return new InputButtonElement(name, null);
        }

        public ButtonElement Button(string name, object htmlAttributes)
        {
            return new ButtonElement(name, htmlAttributes);
        }

        public ButtonElement Button(string name)
        {
            return new ButtonElement(name, null);
        }

        public IHtmlString MenuBar(string name, string onClickFunction, ItemMenuBar[] items)
        {
            return MenuBar(name, onClickFunction, items, null, MenuBarType.Custom);
        }
        public IHtmlString MenuBar(string name, string onClickFunction, ItemMenuBar[] items, MenuBarType type)
        {
            return MenuBar(name, onClickFunction, items, null, type);
        }
        public IHtmlString MenuBar(string name, string onClickFunction, ItemMenuBar[] items, object attributes, MenuBarType type)
        {
            TagBuilder tb;
            if (type == MenuBarType.Custom)
            {
                tb = new TagBuilder("nav");
                tb.AddCssClass("btn-toolbar text-center well");
            }
            else
            {
                tb = new TagBuilder("div");
                tb.AddCssClass("smallMenuBar row-fluid");
            }

            tb.Attributes.Add("id", name);

            string itemsHtml = string.Empty;
            foreach (ItemMenuBar item in items)
            {
                if (item.MenuBarButtonType != MenuBarButtonType.Custom)
                {
                    switch (item.MenuBarButtonType)
                    {
                        case MenuBarButtonType.New:
                            item.ImgPath = ButtonMenuBarFontConstant.NEW;
                            item.Argument = ButtonMenuBarActionConstant.NEW;
                            item.Value = ButtonMenuBarValueConstant.NEW;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.NEW;
                            break;

                        case MenuBarButtonType.Edit:
                            item.ImgPath = ButtonMenuBarFontConstant.EDIT;
                            item.Argument = ButtonMenuBarActionConstant.EDIT;
                            item.Value = ButtonMenuBarValueConstant.EDIT;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.EDIT;
                            break;

                        case MenuBarButtonType.Copy:
                            item.ImgPath = type == MenuBarType.Custom ? (AppConstante.ENABLED_TBR_IMAGES_PATH + "/copy.png") : ButtonMenuBarFontConstant.COPY;
                            item.Argument = ButtonMenuBarActionConstant.COPY;
                            item.Value = ButtonMenuBarValueConstant.COPY;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.COPY;
                            break;

                        case MenuBarButtonType.Delete:
                            item.ImgPath = ButtonMenuBarFontConstant.DELETE;
                            item.Argument = ButtonMenuBarActionConstant.DELETE;
                            item.Value = ButtonMenuBarValueConstant.DELETE;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.DELETE;
                            break;

                        case MenuBarButtonType.Save:
                            item.ImgPath = ButtonMenuBarFontConstant.SAVE;
                            item.Argument = ButtonMenuBarActionConstant.SAVE;
                            item.Value = ButtonMenuBarValueConstant.SAVE;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.SAVE;
                            break;
                        case MenuBarButtonType.SaveExit:
                            item.ImgPath = type == MenuBarType.Custom ? (AppConstante.ENABLED_TBR_IMAGES_PATH + "/SaveExit.png") : ButtonMenuBarFontConstant.SAVE;
                            item.Argument = ButtonMenuBarActionConstant.SAVEEXIT;
                            item.Value = ButtonMenuBarValueConstant.SAVEEXIT;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.SAVEEXIT;
                            break;

                        case MenuBarButtonType.Exit:
                            item.ImgPath = ButtonMenuBarFontConstant.EXIT;
                            item.Argument = ButtonMenuBarActionConstant.EXIT;
                            item.Value = ButtonMenuBarValueConstant.EXIT;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.EXIT;
                            break;

                        case MenuBarButtonType.Cancel:
                            item.ImgPath = ButtonMenuBarFontConstant.CANCEL;
                            item.Argument = ButtonMenuBarActionConstant.CANCEL;
                            item.Value = ButtonMenuBarValueConstant.CANCEL;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.CANCEL;
                            break;
                        case MenuBarButtonType.Print:
                            item.ImgPath = ButtonMenuBarFontConstant.PRINT;
                            item.Argument = ButtonMenuBarActionConstant.PRINT;
                            item.Value = ButtonMenuBarValueConstant.PRINT;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.PRINT;
                            break;
                        case MenuBarButtonType.ExportXls:
                            item.ImgPath = ButtonMenuBarFontConstant.IMPORT;
                            item.Argument = ButtonMenuBarActionConstant.IMPORT_XLS;
                            item.Value = ButtonMenuBarValueConstant.IMPORTAR_XLS;
                            if (String.IsNullOrEmpty(item.Name))
                                item.Name = ButtonMenuBarNameConstant.IMPORTAR_XLS;
                            break;

                    }
                }

                if (type == MenuBarType.Custom)
                {
                    itemsHtml += string.Concat("<button class='btn btn-primary btn-color btn-bg-color btn-sm' id='", name + "_" + item.Name, "' ", (item.Disabled ? "disabled='disabled'" : ""), " onclick=\"", onClickFunction, "('", item.Argument, "');\">");

                    if (item.ImgPath.Contains("."))
                        itemsHtml += item.ImgPath != "" ? "<img src=\"" +
                           (item.Disabled ? VirtualPathUtility.ToAbsolute(item.ImgPath.Replace(AppConstante.ENABLED_PATH + "/", AppConstante.DISABLED_PATH + "/")) :
                           VirtualPathUtility.ToAbsolute(item.ImgPath.Replace(AppConstante.DISABLED_PATH + "/", AppConstante.ENABLED_PATH + "/"))) +
                           "\" alt=\"" + item.Value + "\" title=\"" + item.Value + "\" />" : "";
                    else
                        itemsHtml += "<span class=\"" + item.ImgPath + "\"></span>";
                    itemsHtml += " " + item.Value + "</button>";
                }
                else
                {
                    itemsHtml += string.Concat("<button id='", name, "_", item.Name, "' type=\"button\" class=\"btn btn-sm\" ", (item.Disabled ? "disabled='disabled'" : ""), " onclick=\"", onClickFunction, "('", item.Argument, "');\">");

                    if (item.ImgPath.Contains("."))
                        itemsHtml += "<img src=\"" + VirtualPathUtility.ToAbsolute(item.ImgPath) +
                           (item.Disabled ? VirtualPathUtility.ToAbsolute(item.ImgPath.Replace(AppConstante.ENABLED_PATH + "/", AppConstante.DISABLED_PATH + "/")) :
                           VirtualPathUtility.ToAbsolute(item.ImgPath.Replace(AppConstante.DISABLED_PATH + "/", AppConstante.ENABLED_PATH + "/"))) +
                           "\" alt=\"" + item.Value + "\" title=\"" + item.Value + "\" />";
                    else
                        itemsHtml += "<span style=\"float:left;padding: 0px 4px 0px 0px;\" class=\"" + item.ImgPath + "\"></span>";
                    itemsHtml += "&nbsp;" + item.Value;
                    itemsHtml += "</button>";
                }
            }
            tb.InnerHtml = itemsHtml;
            return new MvcHtmlString(tb.ToString());
        }
        public MvcHtmlString DropDownList(string idcontrol, object value, IEnumerable<SelectListItem> selectList)
        {
            return DropDownList(idcontrol, value, selectList, "", "", "", "", "");
        }

        public MvcHtmlString DropDownList(string idcontrol, object value, IEnumerable<SelectListItem> selectList, string colselect)
        {
            return DropDownList(idcontrol, value, selectList, colselect, "", "", "", "");
        }

        public MvcHtmlString DropDownList(string idcontrol, object value, IEnumerable<SelectListItem> selectList, string colselect, string optionlabel, string coloptionlabel)
        {
            return DropDownList(idcontrol, value, selectList, colselect, optionlabel, coloptionlabel, "", "");
        }

        public MvcHtmlString DropDownList(string idcontrol, object value, IEnumerable<SelectListItem> selectList, string colselect, string optionlabel, string coloptionlabel, object attributessel)
        {
            return DropDownList(idcontrol, value, selectList, colselect, optionlabel, coloptionlabel, attributessel, "");
        }
     

        public MvcHtmlString DropDownList(string idcontrol, object value, IEnumerable<SelectListItem> selectList, string colselect, string optionlabel, string coloptionlabel, object attributessel, object attributeslabel)
        {

            TagBuilder lbl = new TagBuilder("label");
            if (optionlabel != null && optionlabel != "")
            {
                lbl.MergeAttribute("for", idcontrol);
                lbl.AddCssClass("control-label");
                lbl.AddCssClass(coloptionlabel);
                lbl.InnerHtml = optionlabel;
                lbl.MergeAttributes(new RouteValueDictionary(attributeslabel));
            }

            TagBuilder div = new TagBuilder("div");
            //if (coloptionlabel != null && coloptionlabel != "")
            div.AddCssClass(colselect);

            TagBuilder select = new TagBuilder("select");
            select.GenerateId(idcontrol);
            select.Attributes.Add("name", idcontrol);
            select.AddCssClass("form-control");
            select.MergeAttributes(new RouteValueDictionary(attributessel));
            StringBuilder sb = new StringBuilder();
            if (selectList != null)
            {
                foreach (SelectListItem item in selectList)
                {
                    sb.Append("<option value=\"" + item.Value + "\" " + (value != null && item.Value == value.ToString() ? "selected=\"selected\"" : "") + ">" + item.Text + "</option>");
                }
                select.InnerHtml = sb.ToString();
            }

            div.InnerHtml = select.ToString();

            return MvcHtmlString.Create(((optionlabel != null && optionlabel != "") ? lbl.ToString() : "") + div.ToString());
        }

        public MvcHtmlString Select2List(string idcontrol, object value, IEnumerable<SelectListItem> selectList)
        {
            return Select2List(idcontrol, value, selectList, "", "", "", "", "");
        }

        public MvcHtmlString Select2List(string idcontrol, object value, IEnumerable<SelectListItem> selectList, string colselect)
        {
            return Select2List(idcontrol, value, selectList, colselect, "", "", "", "");
        }
        public MvcHtmlString Select2List(string idcontrol, object value, IEnumerable<SelectListItem> selectList, string colselect, string optionlabel, string coloptionlabel)
        {
            return Select2List(idcontrol, value, selectList, colselect, optionlabel, coloptionlabel, "", "");
        }


        public MvcHtmlString Select2List(string idcontrol, object value, IEnumerable<SelectListItem> selectList, string colselect, string optionlabel, string coloptionlabel, object attributessel)
        {
            return Select2List(idcontrol, value, selectList, colselect, optionlabel, coloptionlabel, attributessel, string.Empty);
        }

        public MvcHtmlString Select2List(string idcontrol, object value, IEnumerable<SelectListItem> selectList, string colselect, string optionlabel, string coloptionlabel, object attributessel, object attributeslabel)
        {

            TagBuilder lbl = new TagBuilder("label");
            if (optionlabel != null && optionlabel != "")
            {
                lbl.MergeAttribute("for", idcontrol);
                lbl.AddCssClass("control-label");
                lbl.AddCssClass(coloptionlabel);
                lbl.InnerHtml = optionlabel;
                lbl.MergeAttributes(new RouteValueDictionary(attributeslabel));
            }

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass(colselect);

        

            TagBuilder select = new TagBuilder("select");
            select.GenerateId(idcontrol);
            select.Attributes.Add("name", idcontrol);
            select.AddCssClass("form-control");
            select.MergeAttributes(new RouteValueDictionary(attributessel));
            StringBuilder sb = new StringBuilder();
            if (selectList != null)
            {
                foreach (SelectListItem item in selectList)
                {
                    sb.Append("<option value=\"" + item.Value + "\" " + (value != null && item.Value == value.ToString() ? "selected=\"selected\"" : "") + ">" + item.Text + "</option>");
                }
                select.InnerHtml = sb.ToString();
            }
      
            div.InnerHtml = select.ToString();
            TagBuilder tbJS = new TagBuilder("script");
            tbJS.Attributes.Add("type", "text/javascript");
            string strJS = string.Format(@"jQuery(function ($) {{ $('#{0}').select2(); }});", idcontrol);
            tbJS.InnerHtml += strJS;

            return MvcHtmlString.Create(((optionlabel != null && optionlabel != "") ? lbl.ToString() : "") + div.ToString() + "" + tbJS.ToString());
        }
        public PopupElement Popup(string id, string title, string onOkClickFunction, object htmlAttributes, SizePopup sizePopup)
        {
            return new PopupElement(this.HtmlHelper, id, title, onOkClickFunction, htmlAttributes, sizePopup);
        }

        public PopupElement Popup(string id, string title, string onOkClickFunction, SizePopup sizePopup)
        {
            return new PopupElement(this.HtmlHelper, id, title, onOkClickFunction, null, sizePopup);
        }

        public PopupElement Popup(string id, string title, string onOkClickFunction, object htmlAttributes)
        {
            return new PopupElement(this.HtmlHelper, id, title, onOkClickFunction, htmlAttributes, SizePopup.Default);
        }
        public PopupElement Popup(string id, string title, string okButtonID, string onOkClickFunction)
        {
            return new PopupElement(this.HtmlHelper, id, title, okButtonID, onOkClickFunction, null, SizePopup.Default);
        }

        public PopupElement Popup(string id, string title, string onOkClickFunction)
        {
            return new PopupElement(this.HtmlHelper, id, title, onOkClickFunction, null, SizePopup.Default);
        }
        public PopupElement Popup(string id, string title)
        {
            return new PopupElement(this.HtmlHelper, id, title, "", null, SizePopup.Default);
        }
        public JavaScriptElement JS()
        {
            return new JavaScriptElement();
        }
        public MvcHtmlString AssemblyVersion()
        {
            string version = "v." + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return MvcHtmlString.Create(version);
        }
    }

    public class ElementFactory<TModel> : ElementFactory
    {
        public new HtmlHelper<TModel> HtmlHelper { get; set; }

        public ElementFactory(HtmlHelper<TModel> htmlHelper)
           : base((HtmlHelper)htmlHelper)
        {
            this.HtmlHelper = htmlHelper;
        }

        public InputMaskElement MaskedTextBoxFor(Expression<Func<TModel, string>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.MaskedTextBox(strName, meta.Model as string);
        }
        public InputElement TextBoxFor(Expression<Func<TModel, string>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextBox(strName, meta.Model as string);
        }
        public InputElement TextBoxFor(Expression<Func<TModel, string>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextBox(strName, meta.Model as string, colinput);
        }
        public InputElement TextBoxFor(Expression<Func<TModel, string>> expression, string colinput, string optionlabel, string collabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextBox(strName, meta.Model as string, colinput, optionlabel, collabel);
        }
        public ColorPickerElement TextBoxColorPickerFor(Expression<Func<TModel, string>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextBoxColorPicker(strName, meta.Model as string);
        }
        public ColorPickerElement TextBoxColorPickerFor(Expression<Func<TModel, string>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextBoxColorPicker(strName, meta.Model as string, colinput);
        }
        public ColorPickerElement TextBoxColorPickerFor(Expression<Func<TModel, string>> expression, string colinput, string optionlabel, string collabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextBoxColorPicker(strName, meta.Model as string, colinput, optionlabel, collabel);
        }
        public InputTextButtonElement TextBoxButtonFor(Expression<Func<TModel, string>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextBoxButton(strName, meta.Model as string);
        }
        public InputTextButtonElement TextBoxButtonFor(Expression<Func<TModel, string>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextBoxButton(strName, meta.Model as string, colinput);
        }
        public InputTextButtonElement TextBoxButtonFor(Expression<Func<TModel, string>> expression, string colinput, string optionlabel, string collabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextBoxButton(strName, meta.Model as string, colinput, optionlabel, collabel);
        }
        public TextAreaElement TextAreaFor(Expression<Func<TModel, string>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextArea(strName, meta.Model as string);
        }
        public TextAreaElement TextAreaFor(Expression<Func<TModel, string>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextArea(strName, meta.Model as string, colinput);
        }
        public TextAreaElement TextAreaFor(Expression<Func<TModel, string>> expression, string colinput, string optionlabel, string collabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.TextArea(strName, meta.Model as string, colinput, optionlabel, collabel);
        }
        public PasswordElement PasswordFor(Expression<Func<TModel, string>> expression, string columnClass, string label, string labelColumnClass)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.Password(strName, meta.Model as string, columnClass, label, labelColumnClass);
        }
        public CheckBoxElement CheckBoxFor(Expression<Func<TModel, string>> expression, string columnClass, string label)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.CheckBox(strName, meta.Model as string, columnClass, label);
        }
        public DateTimePickerElement DateTimePickerFor(Expression<Func<TModel, DateTime>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, DateTime>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DateTimePicker(strName).Value((DateTime)meta.Model);
        }
        public DateTimePickerElement DateTimePickerFor(Expression<Func<TModel, DateTime>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, DateTime>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DateTimePicker(strName, colinput).Value((DateTime)meta.Model);
        }
        public DateTimePickerElement DateTimePickerFor(Expression<Func<TModel, DateTime>> expression, string colinput, string optionlabel, string coloptionlabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, DateTime>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DateTimePicker(strName, colinput, optionlabel, coloptionlabel).Value((DateTime)meta.Model);
        }
        public DateTimePickerElement DateTimePickerFor(Expression<Func<TModel, DateTime?>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, DateTime?>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DateTimePicker(strName).Value((DateTime)meta.Model);
        }
        public DateTimePickerElement DateTimePickerFor(Expression<Func<TModel, DateTime?>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, DateTime?>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DateTimePicker(strName, colinput).Value((DateTime)meta.Model);
        }
        public DateTimePickerElement DateTimePickerFor(Expression<Func<TModel, DateTime?>> expression, string colinput, string optionlabel, string coloptionlabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, DateTime?>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DateTimePicker(strName, colinput, optionlabel, coloptionlabel).Value((DateTime?)meta.Model);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, Decimal>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, Decimal>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (Decimal)meta.Model);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, Decimal>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, Decimal>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (Decimal)meta.Model, colinput);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, Decimal>> expression, string colinput, string optionlabel, string coloptionlabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, Decimal>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (Decimal)meta.Model, colinput, optionlabel, coloptionlabel);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, float>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, float>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (float)meta.Model);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, float>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, float>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (float)meta.Model, colinput);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, float>> expression, string colinput, string optionlabel, string coloptionlabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, float>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (float)meta.Model, colinput, optionlabel, coloptionlabel);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, int>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, int>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (int)meta.Model);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, int>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, int>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (int)meta.Model, colinput);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, int>> expression, string colinput, string optionlabel, string coloptionlabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, int>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (int)meta.Model, colinput, optionlabel, coloptionlabel);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, short>> expression)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, short>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (short)meta.Model);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, short>> expression, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, short>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (short)meta.Model, colinput);
        }
        public InputNumericElement NumericTextBoxFor(Expression<Func<TModel, short>> expression, string colinput, string optionlabel, string coloptionlabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, short>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.NumericTextBox(strName, (short)meta.Model, colinput, optionlabel, coloptionlabel);
        }
        public MvcHtmlString DropDownListFor(Expression<Func<TModel, string>> expression, IEnumerable<SelectListItem> selectList)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DropDownList(strName, (string)meta.Model, selectList);
        }
        public MvcHtmlString DropDownListFor(Expression<Func<TModel, string>> expression, IEnumerable<SelectListItem> selectList, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DropDownList(strName, (string)meta.Model, selectList, colinput);
        }
        public MvcHtmlString DropDownListFor(Expression<Func<TModel, string>> expression, IEnumerable<SelectListItem> selectList, string colinput, string optionlabel, string coloptionlabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, string>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DropDownList(strName, (string)meta.Model, selectList, colinput, optionlabel, coloptionlabel);
        }
        public MvcHtmlString DropDownListFor(Expression<Func<TModel, int>> expression, IEnumerable<SelectListItem> selectList)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, int>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DropDownList(strName, (string)meta.Model, selectList);
        }
        public MvcHtmlString DropDownListFor(Expression<Func<TModel, int>> expression, IEnumerable<SelectListItem> selectList, string colinput)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, int>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DropDownList(strName, (string)meta.Model, selectList, colinput);
        }
        public MvcHtmlString DropDownListFor(Expression<Func<TModel, int>> expression, IEnumerable<SelectListItem> selectList, string colinput, string optionlabel, string coloptionlabel)
        {
            ModelMetadata meta = ModelMetadata.FromLambdaExpression<TModel, int>(expression, this.HtmlHelper.ViewData);
            string strName = ExpressionHelper.GetExpressionText(expression);

            return this.DropDownList(strName, (string)meta.Model, selectList, colinput, optionlabel, coloptionlabel);
        }
    }
}
