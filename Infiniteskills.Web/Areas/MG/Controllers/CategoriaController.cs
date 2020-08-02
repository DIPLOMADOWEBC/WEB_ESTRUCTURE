using System;
using System.Collections.Generic;
using System.Linq;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using Infiniteskills.Helpers;
using System.Web.Mvc;
using Infiniteskills.Common;

namespace Infiniteskills.Web.Areas.MG.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: Categoria
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

                List<CategoriaDTO> categoriaDTOList = _categoriaService.SearchFor(parameters, string.Empty).Cast<CategoriaDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = categoriaDTOList.Count,
                    rows = from f in categoriaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   CategoriaId = f.CategoriaId,
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
            CategoriaDTO categoriaDTO = new CategoriaDTO();
            try
            {

                if (collection.EditAction == EditActionConstant.EDIT)
                    categoriaDTO.CategoriaId = Convert.ToInt32(headerDictionary["CategoriaId"]);

                categoriaDTO.Codigo = headerDictionary["Codigo"].ToString().Trim();
                categoriaDTO.Nombre = headerDictionary["Nombre"].ToString().Trim();
                categoriaDTO.Estado = EstadoConstante.ACTIVO;
           

                if (collection.EditAction == EditActionConstant.NEW)
                    _categoriaService.Create(categoriaDTO);
                else
                    _categoriaService.Update(categoriaDTO);

                jsonResultMessage.message = "Categoria grabado satifactoriamente";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
                throw ex;
            }
            return Json(jsonResultMessage);
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}