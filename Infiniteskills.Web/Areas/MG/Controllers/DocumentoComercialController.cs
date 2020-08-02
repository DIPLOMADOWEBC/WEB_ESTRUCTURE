using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.MG.Controllers
{
    public class DocumentoComercialController : Controller
    {
        private IDocumentoComercialService documentoComercialService;
        public DocumentoComercialController(IDocumentoComercialService documentoComercialService)
        {
            this.documentoComercialService = documentoComercialService;
        }
        public ActionResult Bandeja()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult ListarBandeja(string codigo, string nombre)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {

                if (!string.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);

                if (!string.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);

                List<DocumentoComercialDTO> documentoComercialDTOList = documentoComercialService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = documentoComercialDTOList.Count,
                    rows = from f in documentoComercialDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   DocumentoComercialId = f.DocumentoComercialId,
                                   Codigo = f.Codigo,
                                   Nombre = f.Nombre,
                               }
                           }
                };

                return Json(jsonData,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // GET: MG/DocumentoComercial/Create
        [HttpPost]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Row);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            DocumentoComercialDTO documentoComercialDTO = new DocumentoComercialDTO();
            try
            {

                if (collection.EditAction == EditActionConstant.EDIT)
                    documentoComercialDTO.DocumentoComercialId = Convert.ToInt32(headerDictionary["DocumentoComercialId"]);

                documentoComercialDTO.Codigo = headerDictionary["Codigo"].ToString().Trim();
                documentoComercialDTO.Nombre = headerDictionary["Nombre"].ToString().Trim();
                documentoComercialDTO.Estado = EstadoConstante.ACTIVO;


                if (collection.EditAction == EditActionConstant.NEW)
                    documentoComercialService.Create(documentoComercialDTO);
                else
                    documentoComercialService.Update(documentoComercialDTO);

                jsonResultMessage.message = "Documento comercial grabado satifactoriamente";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
                throw ex;
            }
            return Json(jsonResultMessage);
        }

    }
}
