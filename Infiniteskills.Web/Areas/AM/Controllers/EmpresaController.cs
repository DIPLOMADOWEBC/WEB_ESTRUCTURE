using Infiniteskills.Common;
using Infiniteskills.Helpers;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Areas.AM.Controllers
{

    public class EmpresaController : Controller
    {
        private IEmpresaService _empresaService;
        private ISucursalService _sucursalService;
        public EmpresaController(IEmpresaService empresaService,
            ISucursalService sucursalService)
        {
            _empresaService = empresaService;
            _sucursalService = sucursalService;
        }
        // GET: Empresa
        public ActionResult Bandeja()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ListarBandeja(string codigo, string nombre,
            string numeroRuc, string telefono)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(codigo))
                    parameters.Add("codigo", codigo);

                if (!string.IsNullOrEmpty(nombre))
                    parameters.Add("nombre", nombre);


                if (!string.IsNullOrEmpty(numeroRuc))
                    parameters.Add("numeroRuc", numeroRuc);

                if (!string.IsNullOrEmpty(telefono))
                    parameters.Add("telefono", telefono);

                List<EmpresaDTO> empresaDTOList = _empresaService.SearchFor(parameters, string.Empty).Cast<EmpresaDTO>().ToList();
                int index = 1;
                var jsonData = new
                {
                    total = 1,
                    page = 1,
                    records = empresaDTOList.Count,
                    rows = from f in empresaDTOList.AsEnumerable()
                           select new
                           {
                               id = index++,
                               cell = new
                               {
                                   f.EmpresaId,
                                   f.NumeroRuc,
                                   f.RazonSocial,
                                   f.Direccion,
                                   f.Telefono
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


        // GET: Empresa/Create
        [HttpGet]
        public ActionResult Create(string editAction, string empresaId)
        {
            EmpresaDTO empresaDTO = new EmpresaDTO();
            try
            {
                switch (editAction)
                {
                    case EditActionConstant.NEW:
                        ViewBag.Title = "Nuevo Empresa";
                        empresaDTO.EditAction = editAction;
                        break;
                    case EditActionConstant.EDIT:
                        ViewBag.Title = "Editar Empresa";
                        empresaDTO = _empresaService.GetById(Convert.ToInt32(empresaId));
                        empresaDTO.EditAction = editAction;
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return PartialView(empresaDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JsonHeader collection, HttpPostedFileBase fileXml,
            HttpPostedFileBase filePdf, HttpPostedFileBase fileCdr,
            HttpPostedFileBase fileFirma, HttpPostedFileBase fileImage)
        {
            Dictionary<string, string> editDictionary = WebHelper.JsonToDictionary(collection.Header);
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            EmpresaDTO empresaDTO = new EmpresaDTO();
            try
            {
                if (collection.EditAction == EditActionConstant.EDIT)
                    empresaDTO.EmpresaId = Convert.ToInt32(editDictionary["EmpresaId"]);

                empresaDTO.NumeroRuc = editDictionary["NumeroRuc"].ToString();
                empresaDTO.Nombre = editDictionary["Nombre"].ToString();
                empresaDTO.RazonSocial = editDictionary["RazonSocial"].ToString();
                empresaDTO.Direccion = editDictionary["Direccion"].ToString();
                empresaDTO.Telefono = editDictionary["Telefono"].ToString();
                empresaDTO.Email = String.Empty;
                empresaDTO.UsuarioCorreo = editDictionary["UsuarioCorreo"].ToString();
                empresaDTO.Correo = editDictionary["Correo"].ToString();
                empresaDTO.AliasCorreo = editDictionary["AliasCorreo"].ToString();
                empresaDTO.ContrasenaCorreo = editDictionary["ContrasenaCorreo"].ToString();
                empresaDTO.ServerSmtp = editDictionary["ServerSmtp"].ToString();
                empresaDTO.PuertoSmtp = editDictionary["PuertoSmtp"].ToString();
                empresaDTO.SeguridadSsl = false;
                empresaDTO.UsuarioSunat = editDictionary["UsuarioSunat"].ToString();
                empresaDTO.ContrasenaSunat = editDictionary["ContrasenaSunat"].ToString();
                empresaDTO.RutaXml = fileXml == null ? string.Empty : Path.GetFileName(fileXml.FileName);
                empresaDTO.RutaPdf = filePdf == null ? string.Empty : Path.GetFileName(filePdf.FileName);
                empresaDTO.RutaCrd = fileCdr == null ? string.Empty : Path.GetFileName(fileCdr.FileName);
                empresaDTO.RutaFirma = fileFirma == null ? string.Empty : Path.GetFileName(fileFirma.FileName);
                empresaDTO.ContrasenaFirma = editDictionary["ContrasenaFirma"].ToString();

                if (fileImage != null)
                {

                    BinaryReader br = new BinaryReader(fileImage.InputStream);
                    byte[] bytes = br.ReadBytes((int)fileImage.InputStream.Length);

                    // string fil = Path.GetFileName(fileImage.FileName);
                    // string path = Path.Combine(@"D:\FileUpload\firma", fil);
                    empresaDTO.Logo = bytes;

                    //fileImage.SaveAs(path);
                }

                if (collection.EditAction == EditActionConstant.NEW)
                    _empresaService.Create(empresaDTO);
                else
                    _empresaService.Update(empresaDTO);

                if (fileXml != null)
                {

                    string fil = Path.GetFileName(fileXml.FileName);
                    string path = Path.Combine(@"D:\FileUpload\factura", fil);
                    fileXml.SaveAs(path);
                }

                if (filePdf != null)
                {

                    string file = Path.GetFileName(filePdf.FileName);
                    string path = Path.Combine(@"D:\FileUpload\pdf", file);
                    fileXml.SaveAs(path);
                }

                if (fileCdr != null)
                {

                    string fil = Path.GetFileName(fileCdr.FileName);
                    string path = Path.Combine(@"D:\FileUpload\cdr", fil);
                    fileXml.SaveAs(path);
                }

                if (fileFirma != null)
                {

                    string fil = Path.GetFileName(fileFirma.FileName);
                    string path = Path.Combine(@"D:\FileUpload\firma", fil);
                    fileXml.SaveAs(path);
                }

                jsonResultMessage.message = "Empresa grabado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                jsonResultMessage.success = false;
                jsonResultMessage.message = ex.Message;
            }
            return Json(jsonResultMessage);
        }

        public byte[] ImageToBinary(string imagePath)
        {
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            fileStream.Close();
            return buffer;
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFile file)
        {
            return Json(string.Empty);
        }

        [HttpPost]
        public ActionResult FileUpload(List<HttpPostedFile> file)
        {
            return Json(string.Empty);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public FileResult ShowImage(int id)
        {
            byte[] fileBytes = new byte[] { };
            string NArchivo = "";
            EmpresaDTO empresaDTO = new EmpresaDTO();
            empresaDTO = _empresaService.GetById(Convert.ToInt32(id));
            if (empresaDTO != null)
            {
                if (!System.IO.File.Exists(NArchivo))
                    NArchivo = Path.Combine(Server.MapPath("~") + @"Content\image", "160x240.png");

                if (System.IO.File.Exists(NArchivo))
                    fileBytes = empresaDTO.Logo;
            }
            else
            {
                NArchivo = Path.Combine(Server.MapPath("~") + @"Content\image", "160x240.png");
            }

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet);

        }


        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}