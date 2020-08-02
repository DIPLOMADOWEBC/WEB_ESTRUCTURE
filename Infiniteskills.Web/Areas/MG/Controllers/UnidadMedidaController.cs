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
    public class UnidadMedidaController : Controller
    {
        private IUnidadMedidaService unidadMedidaService;
        public UnidadMedidaController(IUnidadMedidaService unidadMedidaService)
        {
            this.unidadMedidaService = unidadMedidaService;
        }
        // GET: MG/UnidadMedida
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


                List<UnidadMedidaDTO> unidadMedidaDTOList = unidadMedidaService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = unidadMedidaDTOList.Count,
                    rows = from f in unidadMedidaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   UnidadMedidaId = f.UnidadMedidaId,
                                   Codigo = f.Codigo,
                                   Nombre = f.Nombre,
                                   Abreaviatura = f.Abreaviatura
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
            UnidadMedidaDTO unidadMedidaDTO = new UnidadMedidaDTO();
            try
            {

                if (collection.EditAction == EditActionConstant.EDIT)
                    unidadMedidaDTO.UnidadMedidaId = Convert.ToInt32(headerDictionary["UnidadMedidaId"]);

                unidadMedidaDTO.Codigo = headerDictionary["Codigo"].ToString().Trim();
                unidadMedidaDTO.Nombre = headerDictionary["Nombre"].ToString().Trim();
                unidadMedidaDTO.Abreaviatura = headerDictionary["Abreaviatura"].ToString().Trim();
                unidadMedidaDTO.Estado = EstadoConstante.ACTIVO;


                if (collection.EditAction == EditActionConstant.NEW)
                    unidadMedidaService.Create(unidadMedidaDTO);
                else
                    unidadMedidaService.Update(unidadMedidaDTO);

                jsonResultMessage.message = "Unidad medida grabado satifactoriamente";
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
