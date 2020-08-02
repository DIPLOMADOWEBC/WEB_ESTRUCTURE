using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Transport;
using Infiniteskills.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.CG.Controllers
{
    public class TablaController : Controller
    {
        private ITablaService tablaService;
        public TablaController(ITablaService tablaService)
        {
            this.tablaService = tablaService;
        }
        // GET: CG/Tabla
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

                List<TablaDTO> tablaDTOList = tablaService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = tablaDTOList.Count,
                    rows = from f in tablaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   TablaId = f.TablaId,
                                   Codigo = f.Codigo,
                                   Nombre = f.Nombre,
                                   Formato = f.Formato
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
        public ActionResult Create(string editAction,string tablaId)
        {
            TablaDTO tablaDTO = new TablaDTO();
            switch (editAction)
            {
                case EditActionConstant.NEW:
                    ViewBag.IsNew = true;
                    break;
                case EditActionConstant.EDIT:
                    ViewBag.IsNew = false;
                    tablaDTO = tablaService.GetById(Convert.ToInt32(tablaId));
                    break;
            }
            return PartialView(tablaDTO);
        }

        // POST: CG/Tabla/Create
        [HttpPost]
        public ActionResult Create(JsonHeader collection)
        {
            TablaDTO tablaDTO = new TablaDTO();
            Dictionary<string, string> editDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                if (collection.EditAction == EditActionConstant.EDIT)
                    tablaDTO.TablaId = Convert.ToInt32(editDictionary["TablaId"]);

                tablaDTO.Codigo = Convert.ToString(editDictionary["Codigo"]);
                tablaDTO.Nombre = Convert.ToString(editDictionary["Nombre"]);
                tablaDTO.Formato = editDictionary["Formato"].ToString();


                tablaDTO.Estado = EstadoConstante.ACTIVO;
                tablaDTO.UsuarioCreacionId = 1;
                tablaDTO.FechaCreacion = DateTime.Now;

                if (collection.EditAction == EditActionConstant.NEW)
                    tablaService.Create(tablaDTO);
                else
                    tablaService.Update(tablaDTO);

                jsonResultMessage.message = "Tabla grabado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }

        // GET: CG/Tabla/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CG/Tabla/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // POST: CG/Tabla/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
