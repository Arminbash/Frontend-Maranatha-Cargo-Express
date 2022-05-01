using MaranathaCargoExpress.Service.Service;
using MaranathaCargoExpress.Service.ViewModel;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaranathaCargoExpress.Web.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        TipoPersonaService _tipoPersonaService = new TipoPersonaService();
        // GET: Person
        public ActionResult Index()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            return View();
        }

        public ActionResult TipoPersona()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            return View();
        }

        [HttpPost]
        public JsonResult AddTipoPersona(TipoPersonaDto tipoPersonaDto)
        {
            var request = _tipoPersonaService.AddTipoPersonaAsync(tipoPersonaDto, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListTipoPersona()
        {
            var request = _tipoPersonaService.ListaTipoPersona(SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(JsonSerializer.Serialize(request.Result), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTipoPersona(int Id)
        {
            var request = _tipoPersonaService.EliminarTipoPersona(Id, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditarTipoPersona(TipoPersonaDto tipoPersonaDto)
        {
            var request = _tipoPersonaService.EditarTipoPersona(tipoPersonaDto, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
    }
}