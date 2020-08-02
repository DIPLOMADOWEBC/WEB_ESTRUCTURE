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
    public class MarcaController : Controller
    {
        private IMarcaService marcaService;
        public MarcaController(IMarcaService marcaService)
        {
            this.marcaService = marcaService;
        }
        // GET: MG/Marca
        public ActionResult Bandeja()
        {
            return PartialView();
        }
        public ActionResult ListarBandeja(string codigo,string nombre)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);


                if (!string.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);

                List<MarcaDTO> marcaDTOList = marcaService.SearchFor(parameters, string.Empty).ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = marcaDTOList.Count,
                    rows = from f in marcaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   MarcaId = f.MarcaId,
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

        // GET: MG/Marca/Create
        [HttpGet]
        public ActionResult Create(string editAction, string marcaId)
        {
            MarcaDTO marcaDTO = new MarcaDTO();
            switch (editAction)
            {
                case EditActionConstant.NEW:
                    break;
                case EditActionConstant.EDIT:
                    marcaDTO = marcaService.GetById(Convert.ToInt32(marcaId));
                    break;
            }
            return PartialView(marcaDTO);
        }

        // POST: MG/Marca/Create
        [HttpPost]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Row);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            MarcaDTO marcaDTO = new MarcaDTO();
            try
            {
                marcaDTO.MarcaId = Convert.ToInt32(headerDictionary["MarcaId"]);
                marcaDTO.Codigo = headerDictionary["Codigo"].ToString();
                marcaDTO.Nombre = headerDictionary["Nombre"].ToUpper().ToString();

                marcaDTO.Estado = EstadoConstante.ACTIVO;
                if (collection.EditAction == EditActionConstant.NEW)
                    marcaService.Create(marcaDTO);
                else
                    marcaService.Update(marcaDTO);


                jsonResultMessage.message = "Marca grabado satisfactoriamente.";
                return Json(jsonResultMessage);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
