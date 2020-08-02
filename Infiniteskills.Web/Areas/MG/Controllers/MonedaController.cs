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
    public class MonedaController : Controller
    {
        private IMonedaService monedaService; 
        public MonedaController(IMonedaService monedaService)
        {
            this.monedaService = monedaService;
        }
        // GET: MG/Moneda
        public ActionResult Bandeja()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarBandeja(string codigo,string nombre)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!String.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);

                if (!String.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);

                List<MonedaDTO> monedaDTOList = monedaService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = monedaDTOList.Count,
                    rows = from f in monedaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   MonedaId = f.MonedaId,
                                   Codigo =  f.Codigo,
                                   Nombre = f.Nombre,
                                   Simbolo = f.Simbolo
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

     
        // POST: MG/Moneda/Create
        [HttpPost]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Row);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            MonedaDTO monedaDTO = new MonedaDTO();
            try
            {

                if (collection.EditAction == EditActionConstant.EDIT)
                    monedaDTO.MonedaId = Convert.ToInt32(headerDictionary["MonedaId"]);

                monedaDTO.Codigo = headerDictionary["Codigo"].ToString().Trim();
                monedaDTO.Nombre = headerDictionary["Nombre"].ToString().Trim();
                monedaDTO.Simbolo = headerDictionary["Simbolo"].ToString().Trim();
                monedaDTO.Estado = EstadoConstante.ACTIVO;


                if (collection.EditAction == EditActionConstant.NEW)
                    monedaService.Create(monedaDTO);
                else
                    monedaService.Update(monedaDTO);

                jsonResultMessage.message = "Moneda grabado satifactoriamente.";
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
