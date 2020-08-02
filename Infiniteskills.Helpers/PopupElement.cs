using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infiniteskills.Helpers
{
   public enum SizePopup
   {
      Default = 0,
      Small = 1,
      Medium = 2,
      Large = 3,
      ExtraLarge = 4
   }

   public class PopupElement : IDisposable
   {
      protected string _id;
      protected HtmlHelper _helper;
      protected TagBuilder _model;
      protected TagBuilder _dialog;
      protected TagBuilder _content;
      protected TagBuilder _body;
      protected string _okButtonId = "";
      protected string _onOkClickFunction;

      public PopupElement(HtmlHelper helper, string id, string title, string onOkClickFunction, object htmlAttributes, SizePopup sizePopup)
         : this(helper, id, title, "", onOkClickFunction, htmlAttributes, sizePopup)
      {

      }

      public PopupElement(HtmlHelper helper, string id, string title, string okButtonId, string onOkClickFunction, object htmlAttributes, SizePopup sizePopup)
      {
         _helper = helper;
         _onOkClickFunction = onOkClickFunction;
         _model = new TagBuilder("div");
         _id = id;
         _okButtonId = okButtonId;
         if (htmlAttributes != null)
            _model.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

         _model.GenerateId(id);
         _model.Attributes.Add("tabindex", "-1");
         _model.Attributes.Add("role", "dialog");
         _model.Attributes.Add("aria-labelledby", "myModalLabel");
         _model.Attributes.Add("aria-hidden", "true");
         _model.AddCssClass("modal fade");

         TagBuilder modelLoading = new TagBuilder("div");
         modelLoading.GenerateId(string.Concat(id, "-locked"));
         modelLoading.AddCssClass("popup-locked");

         TagBuilder modelLoadingContent = new TagBuilder("div");
         modelLoadingContent.AddCssClass("popup-locked-content");

      
         modelLoading.InnerHtml = modelLoadingContent.ToString();

         _dialog = new TagBuilder("div");
         _dialog.AddCssClass("modal-dialog");

         switch (sizePopup)
         {
            case SizePopup.Small:
               _dialog.AddCssClass("modal-sm");
               break;
            case SizePopup.Medium:
               _dialog.AddCssClass("modal-md");
               break;
            case SizePopup.Large:
               _dialog.AddCssClass("modal-lg");
               break;
            case SizePopup.ExtraLarge:
               _dialog.AddCssClass("modal-xlg");
               break;
         }

         _content = new TagBuilder("div");
         _content.AddCssClass("modal-content");

         TagBuilder header = new TagBuilder("div");
         header.AddCssClass("modal-header");

         TagBuilder button = new TagBuilder("button");
         button.AddCssClass("close");
         button.Attributes.Add("aria-hidden", "true");
         button.Attributes.Add("data-dismiss", "modal");
         button.InnerHtml = "<span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Cerrar</span>";

         TagBuilder mtitle = new TagBuilder("h5");
         mtitle.GenerateId(string.Concat(this._id, "-title"));
         mtitle.AddCssClass("modal-title");
         mtitle.InnerHtml = title;

         header.InnerHtml = string.Concat(button.ToString(), mtitle.ToString());

         _body = new TagBuilder("div");
         _body.AddCssClass("modal-body");

         helper.ViewContext.Writer.Write(string.Concat(_model.ToString(TagRenderMode.StartTag),
                                        _dialog.ToString(TagRenderMode.StartTag),
                                        _content.ToString(TagRenderMode.StartTag),
                                        modelLoading.ToString(),
                                        header.ToString(),
                                        _body.ToString(TagRenderMode.StartTag)));

      }
      public void Dispose()
      {

         TagBuilder footer = new TagBuilder("div");
         footer.AddCssClass("modal-footer");

         TagBuilder cancelButton = new TagBuilder("button");
         cancelButton.AddCssClass("btn btn-primary btn-sm");
         cancelButton.Attributes.Add("type", "button");
         cancelButton.Attributes.Add("data-dismiss", "modal");
         cancelButton.InnerHtml = "Cerrar";

         TagBuilder okButton = new TagBuilder("button");
         okButton.AddCssClass("btn btn-primary btn-sm");
         if (!String.IsNullOrEmpty(_okButtonId))
            okButton.Attributes.Add("id", _okButtonId);

         okButton.Attributes.Add("type", "button");
         if (_onOkClickFunction != null && _onOkClickFunction != "")
            okButton.Attributes.Add("onclick", _onOkClickFunction + "();");
         okButton.InnerHtml = "Aceptar";

         footer.InnerHtml = string.Concat(cancelButton.ToString(), okButton.ToString());

         TagBuilder tbJS = new TagBuilder("script");
         tbJS.Attributes.Add("type", "text/javascript");
         tbJS.InnerHtml = string.Concat("$('#", this._id, "').modal({ backdrop: 'static', show: false, keyboard: false })");

         _helper.ViewContext.Writer.Write(string.Concat(_body.ToString(TagRenderMode.EndTag),
                                                        footer.ToString(),
                                                        _content.ToString(TagRenderMode.EndTag),
                                                        _dialog.ToString(TagRenderMode.EndTag),
                                                        _model.ToString(TagRenderMode.EndTag),
                                                        tbJS.ToString()));

      }

   }
}
