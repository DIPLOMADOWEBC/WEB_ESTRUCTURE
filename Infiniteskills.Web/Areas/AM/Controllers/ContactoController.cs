using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.AM.Controllers
{
    public class ContactoController : Controller
    {

        private IContactoService contactoService;
        private IAreaService areaService;

        public ContactoController(IContactoService contactoService,
            IAreaService areaService)
        {
            this.contactoService = contactoService;
            this.areaService = areaService;
        }

        public ActionResult Bandeja()
        {
            return PartialView();
        }

        // GET: LG/Contacto/Details/5
        [HttpPost]
        public ActionResult ListarBandeja(string nombre, string numDocumento)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {

              
                if (!string.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);

                if (!string.IsNullOrEmpty(numDocumento))
                    parameters.Add("numDocumento", numDocumento);


                List<ContactoDTO> contactoDTOList = contactoService.SearchFor(parameters, string.Empty).Cast<ContactoDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = contactoDTOList.Count,
                    rows = from f in contactoDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.ContactoId,
                                   f.NombreContacto,
                                   f.NumeroDocumentoContacto,
                                   f.TelefonoContacto,
                                   f.CelularContacto,
                                   f.EmailContacto,
                                   f.DireccionContacto
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

        // GET: LG/Contacto/Create
        [HttpGet]
        public ActionResult Create(string editAction, string contactoId)
        {
            ContactoDTO contactoDTO = new ContactoDTO();
            switch (editAction)
            {
                case EditActionConstant.NEW:
                    ViewBag.Title = "Nuevo Contacto";
                    contactoDTO.EditAction = editAction;
                    break;
                case EditActionConstant.EDIT:
                    ViewBag.IsNew = false;
                    ViewBag.Title = "Editar Contacto";
                    contactoDTO = contactoService.GetById(Convert.ToInt32(contactoId));
                    contactoDTO.EditAction = editAction;
                    break;
            }
            ListarDropList();
            return PartialView(contactoDTO);
        }


        private void ListarDropList()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            List<AreaDTO> areaDTOList = areaService.SearchFor(parameters, string.Empty).Cast<AreaDTO>().ToList();

            ViewBag.AreaList = WebHelper.ToSelectListItem<AreaDTO>(
                areaDTOList, x => x.AreaId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, String.Empty);

        }

        // POST: LG/Contacto/Create
        [HttpPost]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            ContactoDTO contactoDTO = new ContactoDTO();
            try
            {
                contactoDTO.ContactoId = Convert.ToInt32(headerDictionary["ContactoId"]);
                contactoDTO.AreaId = Convert.ToInt32(headerDictionary["AreaId"]);
                contactoDTO.NombreContacto = headerDictionary["NombreContacto"].ToString();
                contactoDTO.NumeroDocumentoContacto = headerDictionary["NumeroDocumentoContacto"].ToString();
                contactoDTO.TelefonoContacto = headerDictionary["TelefonoContacto"].ToString();
                contactoDTO.CelularContacto = headerDictionary["CelularContacto"].ToString();
                contactoDTO.EmailContacto = headerDictionary["EmailContacto"].ToString();
                contactoDTO.DireccionContacto = headerDictionary["DireccionContacto"].ToString();

                if (collection.EditAction == EditActionConstant.NEW)
                    contactoService.Create(contactoDTO);
                else
                    contactoService.Update(contactoDTO);

                jsonResultMessage.message = "Contacto grabado satisfactoriamente.";
                return Json(jsonResultMessage);
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }

 

        // POST: LG/Contacto/Edit/5
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

  

        // POST: LG/Contacto/Delete/5
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
