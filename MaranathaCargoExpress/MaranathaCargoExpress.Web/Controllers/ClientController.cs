using MaranathaCargoExpress.Service.Service;
using MaranathaCargoExpress.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MaranathaCargoExpress.Web.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        private readonly ClienteServices _clienteService = new ClienteServices();
        public ActionResult Cotizacion()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            ViewBag.ListaCliente = _clienteService.ListaCliente(SessionHelper.GetToken()).Result;
            return View();
        }
        
        [HttpPost]
        public JsonResult AddClient(ClienteDto clienteDto)
        {
            var request = _clienteService.AddClienteAsync(clienteDto,SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
    }
}