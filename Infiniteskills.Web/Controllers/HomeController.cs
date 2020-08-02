using Infiniteskills.Helpers;
using Infiniteskills.Infra.Base;
using Infiniteskills.Service;
using Infiniteskills.Transport;
using Infiniteskills.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infiniteskills.Web.Controllers
{
    //[CustomAuthorize]
    public class HomeController : Controller
    {
        private IPersonalService personalService;
        public HomeController(IPersonalService personalService,ISunatClient sunatClient)
        {
            this.personalService = personalService;
        }
        public ActionResult Index()
        {
           
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpPost]
        public async Task<JsonResult> GetPersonal(string nombre)
        {
            JsonResultMessage jsonResultMessage = new JsonResultMessage();
            try
            {
                IEnumerable<PersonalDTO> listarPesonal = await personalService.ListarPersonal(nombre);

                var dataJson = from f in listarPesonal.ToList()
                               select new
                               {
                                   f.PersonalId,
                                   f.Nombres
                               };
                jsonResultMessage.data = dataJson;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
        }
    }
}
