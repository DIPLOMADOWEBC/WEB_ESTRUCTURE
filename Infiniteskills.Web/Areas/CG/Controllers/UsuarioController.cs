using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Transport;
using Infiniteskills.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Infiniteskills.Web.Areas.CG.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioService usuarioService;
        private IPersonalService personalService;
        private ISucursalService sucursalService;
        public UsuarioController(IUsuarioService usuarioService,
            IPersonalService personalService,
            ISucursalService sucursalService)
        {
            this.usuarioService = usuarioService;
            this.personalService = personalService;
            this.sucursalService = sucursalService;
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

                List<UsuarioDTO> usuarioDTOList = usuarioService.ListarUsuario(parameters);
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = usuarioDTOList.Count,
                    rows = from f in usuarioDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.UsuarioId,
                                   f.PersonalDTO.PersonalId,
                                   Nombre = string.Concat(f.PersonalDTO.Nombres, " ", f.PersonalDTO.Apellidos),
                                   f.UserName,
                                   Sucursal = string.Empty,
                                   Estado = f.Estado == "A" ? LetraEstadoConstante.ACTIVO : LetraEstadoConstante.INACTIVO
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

        // GET: CG/Usuario/Create
        [HttpGet]
        public ActionResult Create(string editAction, string personalId)
        {
            PersonalDTO personalDTO = new PersonalDTO();
            try
            {
                switch (editAction)
                {
                    case EditActionConstant.NEW:
                        ViewBag.Title = "Nuevo Usuario";
                        personalDTO.FechaNacimiento = DateTime.Now;
                        personalDTO.EditAction = editAction;
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.Title = "Editar Usuario";
                        personalDTO = personalService.GetPersonalId(Convert.ToInt32(personalId));
                        personalDTO.EditAction = editAction;
                        ListarPersonal(personalDTO.PersonalId);
                        break;
                }

                ListDropList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return PartialView(personalDTO);
        }

        private void ListarPersonal(int id)
        {
            IEnumerable<PersonalDTO> personalList = personalService.ListarPersonal(id);
            ViewBag.ListarPersonal = WebHelper.ToSelectListItem<PersonalDTO>(personalList
                , x => x.PersonalId.ToString(), x => x.Nombres, SelectListFirstElementType.Select, string.Empty);
        }

        private void ListDropList()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();


            List<SucursalDTO> sucursalDTOList = sucursalService.SearchFor(parameters, string.Empty).Cast<SucursalDTO>().ToList();
            ViewBag.SucursalList = WebHelper.ToSelectListItem<SucursalDTO>(sucursalDTOList,
                x => x.SucursalId.ToString(), x => x.Nombre, SelectListFirstElementType.Select, string.Empty);
        }

        // POST: CG/Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JsonHeader collection)
        {
            Dictionary<string, string> headerDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            PersonalDTO personaDTO = new PersonalDTO();
            try
            {
                personaDTO.PersonalId = Convert.ToInt32(headerDictionary["PersonalId"]);
                personaDTO.NumeroDocumento = Convert.ToString(headerDictionary["NumeroDocumento"]);
                personaDTO.Apellidos = Convert.ToString(headerDictionary["Apellidos"]);
                personaDTO.FechaNacimiento = Convert.ToDateTime(headerDictionary["FechaNacimiento"]);
                personaDTO.Telefono = Convert.ToString(headerDictionary["Telefono"]);
                personaDTO.Correo = Convert.ToString(headerDictionary["Correo"]);
                personaDTO.Usuario = Convert.ToString(headerDictionary["Usuario"]);
                personaDTO.Password = Convert.ToString(headerDictionary["Password"]);
                personaDTO.Estado = EstadoConstante.ACTIVO;
                personaDTO.UsuarioDTO = new UsuarioDTO
                {
                    PersonalId = personaDTO.PersonalId,
                    Nombre = string.Concat(personaDTO.Nombres, " ", personaDTO.Apellidos),
                    UserName = personaDTO.Usuario,
                    Password = personaDTO.Password,
                    Estado = EstadoConstante.ACTIVO
                };
                personalService.InsertarUsuario(personaDTO);
                jsonResultMessage.message = "Usuario grabado satisfactoriamente.";

                return Json(jsonResultMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetPersonal(string query)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();

            try
            {
                IEnumerable<PersonalDTO> personalList = await personalService.ListarPersonal(query);

                var jsonData = personalList
                    .Select(x => new
                    {
                        x.PersonalId,
                        Nombres = string.Concat(x.Nombres, " ", x.Apellidos)
                    });


                jsonResultMessage.data = jsonData;
                return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: CG/Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView();
        }



        // GET: CG/Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}
