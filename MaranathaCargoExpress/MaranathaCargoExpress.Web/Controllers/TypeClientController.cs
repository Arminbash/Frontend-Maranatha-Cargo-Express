using MaranathaCargoExpress.Service.Service;
using MaranathaCargoExpress.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Mvc;
using MaranathaCargoExpress.Service.ViewModel.Base;

namespace MaranathaCargoExpress.Web.Controllers
{
    [Authorize]
    public class TypeClientController : Controller
    {
        TypeClientService _typeClientService = new TypeClientService();
        // GET: TypeClient
        public ActionResult Index()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            return View();
        }
        public ActionResult TypeClient()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            return View();

        }
        [HttpPost]
        public JsonResult AddTypeClient (TipoClienteDto tipoClienteDto)
        {
            var request = _typeClientService.AddTypeClientAsync(tipoClienteDto, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListTypeClient()
        {
            var request = _typeClientService.ListTypeClient(SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(JsonSerializer.Serialize(request.Result), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public  JsonResult DeleteTypeClient(int Id)
        {
            var request = _typeClientService.DeleteTypeClient(Id, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateTypeClient(TipoClienteDto tipoClienteDto)
        {
            var request = _typeClientService.UpdateTypeClient(tipoClienteDto, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetListaTipoCliente(PaginationDto pagination, SortDto sort, QueryDto query)
        {
            pagination.sort = sort != null ? sort.sort : null;
            pagination.field = sort != null ? sort.field : null;
            pagination.Estado = query != null ? query.Estado : null;
            pagination.generalSearch = query != null ? query.generalSearch : null;
            var request = _typeClientService.ListaTipoClientePaginado(pagination, SessionHelper.GetToken());
            if (request == null || request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
    }
}