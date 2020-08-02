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
    public class TipoProveedorController : Controller
    {
        private ITipoProveedorService tipoProveedorService;

        public TipoProveedorController(ITipoProveedorService tipoProveedorService)
        {
            this.tipoProveedorService = tipoProveedorService;
        }
        // GET: MG/TipoProveedor
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

                List<TipoProveedorDTO> tipoProveedorDTOList = tipoProveedorService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = tipoProveedorDTOList.Count,
                    rows = from f in tipoProveedorDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   TipoProveedorId = f.TipoProveedorId,
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



        // POST: MG/TipoProveedor/Create

        [HttpPost]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Row);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            TipoProveedorDTO tipoProveedorDTO = new TipoProveedorDTO();
            try
            {

                if (collection.EditAction == EditActionConstant.EDIT)
                    tipoProveedorDTO.TipoProveedorId = Convert.ToInt32(headerDictionary["TipoProveedorId"]);

                tipoProveedorDTO.Codigo = headerDictionary["Codigo"].ToString().Trim();
                tipoProveedorDTO.Nombre = headerDictionary["Nombre"].ToString().Trim();
                tipoProveedorDTO.Estado = EstadoConstante.ACTIVO;


                if (collection.EditAction == EditActionConstant.NEW)
                    tipoProveedorService.Create(tipoProveedorDTO);
                else
                    tipoProveedorService.Update(tipoProveedorDTO);

                jsonResultMessage.message = "Tipo proveedor grabado satifactoriamente";
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
