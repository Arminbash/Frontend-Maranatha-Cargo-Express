using MaranathaCargoExpress.Service.Service;
using MaranathaCargoExpress.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.Json;
using MaranathaCargoExpress.Service.ViewModel.Base;

namespace MaranathaCargoExpress.Web.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private readonly TipoPersonaService _tipoPersonaService = new TipoPersonaService();
        PersonService _personaService = new PersonService();
        // GET: Person
        public ActionResult Index()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            ViewBag.TipoPersona = _tipoPersonaService.ListaTipoPersona(SessionHelper.GetToken()).Result;
            return View();
        }

        public ActionResult Person()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            ViewBag.TipoPersona = _tipoPersonaService.ListaTipoPersona(SessionHelper.GetToken()).Result;
            return View();
        }

        [HttpPost]
        public JsonResult AddPersona(PersonaDto personaDto)
        {
            var request = _personaService.AddPersonaAsync(personaDto, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListTipoPersona()
        {
            var request = _personaService.ListaPersona(SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(JsonSerializer.Serialize(request.Result), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarPersona(int Id)
        {
            var request = _personaService.EliminarPersona(Id, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }

       
        public JsonResult GetPersonaPorId(int Id)
        {
            var request = _personaService.ObtenerPersona(Id, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditarPersona(PersonaDto personaDto)
         {
            var request = _personaService.EditarPersona(personaDto, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetListaPersona(PaginationDto pagination, SortDto sort, QueryDto query)
        {
            pagination.sort = sort != null ? sort.sort : null;
            pagination.field = sort != null ? sort.field : null;
            pagination.Estado = query != null ? query.Estado : null;
            pagination.generalSearch = query != null ? query.generalSearch : null;
            var request = _personaService.ListPersonPagination(pagination, SessionHelper.GetToken());
            if (request == null || request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListPersonForSelect(string q, int? page = null)
        {
            PaginationDto pagination = new PaginationDto();
            pagination.generalSearch = q;
            pagination.Estado = true;
            pagination.page = page is null ? 1 : (int)page;
            pagination.pages = 0;
            pagination.perpage = 30;
            var request = _personaService.ListPersonPagination(pagination, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            LoadDataSelectDto<PersonViewModel> newRequest = new Service.ViewModel.Base.LoadDataSelectDto<PersonViewModel>();
            newRequest.incomplete_results = true;
            newRequest.items = request.Result.data;
            newRequest.total_count = request.Result.meta.total;

            return Json(newRequest, JsonRequestBehavior.AllowGet);
        }
    }
}
