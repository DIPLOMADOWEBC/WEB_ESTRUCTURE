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
    public class DocumentoController : Controller
    {
        private IDocumentoIdentidadService documentoIdentidadService;
        public DocumentoController(IDocumentoIdentidadService documentoIdentidadService)
        {
            this.documentoIdentidadService = documentoIdentidadService;
        }

        [HttpGet]
        public ActionResult Bandeja()
        {
            return PartialView();
        }

        public ActionResult ListarBandeja(string codigo, string nombre)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {

                if (!string.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);

                if (!string.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);

                List<DocumentoIdentidadDTO> documentoIdentidadDTOList = documentoIdentidadService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = documentoIdentidadDTOList.Count,
                    rows = from f in documentoIdentidadDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   DocumentoIdentidadId = f.DocumentoIdentidadId,
                                   Codigo = f.Codigo,
                                   Nombre = f.Nombre,
                               }
                           }
                };

                return Json(jsonData);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Row);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            DocumentoIdentidadDTO documentoIdentidadDTO = new DocumentoIdentidadDTO();
            try
            {

                if (collection.EditAction == EditActionConstant.EDIT)
                    documentoIdentidadDTO.DocumentoIdentidadId = Convert.ToInt32(headerDictionary["DocumentoIdentidadId"]);

                documentoIdentidadDTO.Codigo = headerDictionary["Codigo"].ToString().Trim();
                documentoIdentidadDTO.Nombre = headerDictionary["Nombre"].ToString().Trim();
                documentoIdentidadDTO.Estado = EstadoConstante.ACTIVO;


                if (collection.EditAction == EditActionConstant.NEW)
                    documentoIdentidadService.Create(documentoIdentidadDTO);
                else
                    documentoIdentidadService.Update(documentoIdentidadDTO);

                jsonResultMessage.message = "Documento identidad grabado satifactoriamente";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }


    }
}
