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
    public class TipoPrecioController : Controller
    {

        private ITipoPrecioService tipoPrecioService;
        public TipoPrecioController(ITipoPrecioService tipoPrecioService)
        {
            this.tipoPrecioService = tipoPrecioService;
        }
        // GET: MG/TipoPrecio
        public ActionResult Bandeja()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult ListarBandeja(string nombre)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!String.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);

                List<TipoPrecioDTO> tipoPrecioDTOList = tipoPrecioService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = tipoPrecioDTOList.Count,
                    rows = from f in tipoPrecioDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                    f.TipoPrecioId,
                                    f.Nombre
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

        [HttpGet]
        public JsonResult GetDeterminado()
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                var jsonData = new
                {
                    foo = "1",
                    baz = "Blech"
                };

                jsonResultMessage.data = jsonData;
                return Json(jsonResultMessage);
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
            TipoPrecioDTO tipoPrecioDTO = new TipoPrecioDTO();
            try
            {

                if (collection.EditAction == EditActionConstant.EDIT)
                    tipoPrecioDTO.TipoPrecioId = Convert.ToInt32(headerDictionary["TipoPrecioId"]);

                tipoPrecioDTO.Nombre = headerDictionary["Nombre"].ToString().Trim();
                tipoPrecioDTO.Estado = EstadoConstante.ACTIVO;

                if (collection.EditAction == EditActionConstant.NEW)
                    tipoPrecioService.Create(tipoPrecioDTO);
                else
                    tipoPrecioService.Update(tipoPrecioDTO);

                jsonResultMessage.message = "Tipo precio grabado satifactoriamente";
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
