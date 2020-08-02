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
    public class ParametroController : Controller
    {
        private IParametroSistemaService parametroSistemaService;
        public ParametroController(IParametroSistemaService parametroSistemaService)
        {
            this.parametroSistemaService = parametroSistemaService;
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

                List<ParametroSistemaDTO> parametroSistemaDTOList = parametroSistemaService.SearchFor(parameters, string.Empty);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = parametroSistemaDTOList.Count,
                    rows = from f in parametroSistemaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   ParametroSistemaId = f.ParametroSistemaId,
                                   Codigo = f.Codigo,
                                   Nombre = f.Nombre,
                                   ValorNumerico = f.ValorNumerico,
                                   ValorFecha = Convert.ToDateTime(f.ValorFecha).ToString("dd/M/yyyy"),
                                   ValorCadena = f.ValorCadena
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

        // GET: CG/Parametro/Create
        [HttpGet]
        public ActionResult Create(string editAction,
            string parametroSistemaId)
        {
            ParametroSistemaDTO parametroSistemaDTO = new ParametroSistemaDTO();
            switch (editAction)
            {
                case EditActionConstant.NEW:
                    ViewBag.Title = "Nuevo Parametro";
                    break;
                case EditActionConstant.EDIT:
                    ViewBag.Title = "Editar Parametro";
                    parametroSistemaDTO = parametroSistemaService.GetById(Convert.ToInt32(parametroSistemaId));
                    break;
            }
            return PartialView(parametroSistemaDTO);
        }

        // POST: CG/Parametro/Create
        [HttpPost]
        public ActionResult Create(JsonHeader collection)
        {
            ParametroSistemaDTO parametroSistemaDTO = new ParametroSistemaDTO();
            Dictionary<string, string> editDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                if (collection.EditAction == EditActionConstant.EDIT)
                    parametroSistemaDTO.ParametroSistemaId = Convert.ToInt32(editDictionary["ParametroSistemaId"]);

                parametroSistemaDTO.Codigo = Convert.ToString(editDictionary["Codigo"]);
                parametroSistemaDTO.Nombre = Convert.ToString(editDictionary["Nombre"]);

                parametroSistemaDTO.ValorCadena = editDictionary["ValorCadena"].ToString();
                parametroSistemaDTO.ValorNumerico = Convert.ToDecimal(editDictionary["ValorNumerico"]);
                if (!string.IsNullOrEmpty(editDictionary["ValorFecha"]))
                    parametroSistemaDTO.ValorFecha = Convert.ToDateTime(editDictionary["ValorFecha"]);

                parametroSistemaDTO.Estado = EstadoConstante.ACTIVO;
                parametroSistemaDTO.UsuarioCreacionId = 1;
                parametroSistemaDTO.FechaCreacion = DateTime.Now;

                if (collection.EditAction == EditActionConstant.NEW)
                    parametroSistemaService.Create(parametroSistemaDTO);
                else
                    parametroSistemaService.Update(parametroSistemaDTO);

                jsonResultMessage.message = "Parametro grabado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }

        // GET: CG/Parametro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CG/Parametro/Edit/5
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

        // GET: CG/Parametro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}
