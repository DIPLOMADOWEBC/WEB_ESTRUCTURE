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
    public class FormaVentaController : Controller
    {
        private IFormaVentaService formaVentaService;

        public FormaVentaController(IFormaVentaService formaVentaService)
        {
            this.formaVentaService = formaVentaService;
        }
        // GET: MG/FormaVenta
        public ActionResult Bandeja()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult ListarBandeja()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {

                List<FormaVentaDTO> formaVentaDTOList = formaVentaService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = formaVentaDTOList.Count,
                    rows = from f in formaVentaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   FormaVentaId = f.FormaVentaId,
                                   Codigo = f.Codigo,
                                   Nombre = f.Nombre
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
            FormaVentaDTO formaVentaDTO = new FormaVentaDTO();
            try
            {

                if (collection.EditAction == EditActionConstant.EDIT)
                    formaVentaDTO.FormaVentaId = Convert.ToInt32(headerDictionary["FormaVentaId"]);

                formaVentaDTO.Codigo = headerDictionary["Codigo"].ToString().Trim();
                formaVentaDTO.Nombre = headerDictionary["Nombre"].ToString().Trim();
                formaVentaDTO.Estado = EstadoConstante.ACTIVO;


                if (collection.EditAction == EditActionConstant.NEW)
                    formaVentaService.Create(formaVentaDTO);
                else
                    formaVentaService.Update(formaVentaDTO);

                jsonResultMessage.message = "Forma de venta grabado satifactoriamente";
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
