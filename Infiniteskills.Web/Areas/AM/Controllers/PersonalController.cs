using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.AM.Controllers
{

    public class PersonalController : Controller
    {
        private  IPersonalService _personalService;
        private  ISucursalService _sucursalService;
        public PersonalController(IPersonalService personalService,
            ISucursalService sucursalService)
        {
            _personalService = personalService;
            _sucursalService = sucursalService;
        }
        // GET: Personal
        public ActionResult Bandeja()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarBandeja(string documento, string nombre)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(documento))
                    parameters.Add("documento", documento);

                if (!string.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);

                List<PersonalDTO> personalDTOList = _personalService.SearchFor(parameters, string.Empty).Cast<PersonalDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = personalDTOList.Count,
                    rows = from f in personalDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   PersonalId = f.PersonalId,
                                   NumeroDocumento = f.NumeroDocumento,
                                   Nombres = string.Concat(f.Nombres, " ", f.Apellidos),
                                   Telefono = f.Telefono,
                                   EmailPersonal = f.Correo
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

        // GET: Personal/Create
        [HttpGet]
        public ActionResult Create(string editAction, string personalId)
        {
            PersonalDTO personalDTO = new PersonalDTO();
            try
            {
                switch (editAction)
                {
                    case EditActionConstant.NEW:
                        ViewBag.Title = "Nuevo Personal";
                        personalDTO.FechaNacimiento = DateTime.Now;
                        personalDTO.EditAction = editAction;
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.Title = "Editar Personal";
                        personalDTO = _personalService.GetById(Convert.ToInt32(personalId));
                        personalDTO.EditAction = editAction;
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return PartialView(personalDTO);
        }

        private void ListDropList()
        {

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            List<SucursalDTO> sucursalDTOList = _sucursalService.SearchFor(parameters, string.Empty).Cast<SucursalDTO>().ToList();
            ViewBag.SucursalList = WebHelper.ToSelectListItem<SucursalDTO>(sucursalDTOList,
                x => x.SucursalId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> editDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            PersonalDTO personalDTO = new PersonalDTO();
            try
            {
                if (collection.EditAction == EditActionConstant.EDIT)
                    personalDTO.PersonalId = Convert.ToInt32(editDictionary["PersonalId"]);

                personalDTO.Nombres = editDictionary["Nombres"].ToUpper().ToString();
                personalDTO.Apellidos = editDictionary["Apellidos"].ToUpper().ToString();
                personalDTO.NumeroDocumento = editDictionary["NumeroDocumento"].ToString();
                personalDTO.FechaNacimiento = Convert.ToDateTime(editDictionary["FechaNacimiento"]);
                personalDTO.Telefono = editDictionary["Telefono"].ToString();
                personalDTO.Celular = editDictionary["Celular"].ToString();
                personalDTO.Correo = editDictionary["Correo"].ToUpper().ToString();

                personalDTO.Estado = EstadoConstante.ACTIVO;
                personalDTO.UsuarioCreacionId = 1;
                personalDTO.FechaCreacion = DateTime.Now;

                if (collection.EditAction == EditActionConstant.NEW)
                    _personalService.Create(personalDTO);
                else
                    _personalService.Update(personalDTO);

                jsonResultMessage.message = "Personal grabado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
                throw ex;
            }
            return Json(jsonResultMessage);
        }


        // GET: Personal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}