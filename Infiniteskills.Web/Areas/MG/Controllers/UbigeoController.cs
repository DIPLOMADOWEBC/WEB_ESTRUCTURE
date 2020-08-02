using Infiniteskills.Transport;
using Infiniteskills.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.MG.Controllers
{
    public class UbigeoController : Controller
    {

        private IPaisService paisService;
        private IDepartamentoService departamentoService;
        private IProvinciaService provinciaService;
        private IDistritoService distritoService;
        public UbigeoController(IPaisService paisService,
            IDepartamentoService departamentoService,
            IProvinciaService provinciaService, 
            IDistritoService distritoService)
        {
            this.paisService = paisService;
            this.departamentoService = departamentoService;
            this.provinciaService = provinciaService;
            this.distritoService = distritoService;

        }
        // GET: MG/Ubigeo
        public ActionResult Bandeja()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult ListarPais()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                List<PaisDTO> paisDTOList = paisService.SearchFor(parameters, string.Empty);

                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = paisDTOList.Count,
                    rows = from f in paisDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   PaisId = f.PaisId,
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
        public JsonResult ListarDepartamento()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                List<DepartamentoDTO> departamentoList = departamentoService.SearchFor(parameters, string.Empty);

                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = departamentoList.Count,
                    rows = from f in departamentoList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   DepartamentoId = f.DepartamentoId,
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
        public JsonResult ListarProvincia()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                List<ProvinciaDTO> provinciaDTOList = provinciaService.SearchFor(parameters, string.Empty);

                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = provinciaDTOList.Count,
                    rows = from f in provinciaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   ProvinciaId = f.ProvinciaId,
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
        public JsonResult ListarDistrito()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                List<DistritoDTO> distritoDTOList = distritoService.SearchFor(parameters, string.Empty);

                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = distritoDTOList.Count,
                    rows = from f in distritoDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   DistritoId = f.DistritoId,
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

        // GET: MG/Ubigeo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MG/Ubigeo/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: MG/Ubigeo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MG/Ubigeo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MG/Ubigeo/Edit/5
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

        // GET: MG/Ubigeo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MG/Ubigeo/Delete/5
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
