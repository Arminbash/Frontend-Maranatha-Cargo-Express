using MaranathaCargoExpress.Service.Service;
using MaranathaCargoExpress.Service.ViewModel;
using MaranathaCargoExpress.Service.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MaranathaCargoExpress.Web.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Client
        private readonly ClienteServices _clienteService = new ClienteServices();
        private readonly TypeClientService _typeClientService = new TypeClientService();
        public ActionResult Cotizacion()
        {
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            ViewBag.TipoCliente = _typeClientService.ListTypeClient(SessionHelper.GetToken()).Result;
            return View();
        }
        public ActionResult Client()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            ViewBag.TipoCliente = _typeClientService.ListTypeClient(SessionHelper.GetToken()).Result;
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

        public JsonResult GetListClientForSelect(string q, int? page = null)
        {
            PaginationDto pagination = new PaginationDto();
            pagination.generalSearch = q;
            pagination.Estado = true;
            pagination.page = page is null ? 1 :(int) page;
            pagination.pages = 0;
            pagination.perpage = 30;
            var request = _typeClientService.ListaTipoClientePaginado(pagination, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            LoadDataSelectDto<TipoClienteDto> newRequest = new Service.ViewModel.Base.LoadDataSelectDto<TipoClienteDto>();
            newRequest.incomplete_results = true;
            foreach (var items in request.Result.data)
            {
                items.full_name = items.Tipo;
            }
            newRequest.items = request.Result.data;
            newRequest.total_count = request.Result.meta.total;

            return Json(newRequest, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListaCliente(PaginationDto pagination, SortDto sort, QueryDto query)
        {
            pagination.sort = sort != null ? sort.sort : null;
            pagination.field = sort != null ? sort.field : null;
            pagination.Estado = query != null ? query.Estado : null;
            pagination.generalSearch = query != null ? query.generalSearch : null;

            var request = _clienteService.ListaClientePaginado(pagination, SessionHelper.GetToken());
            if (request == null || request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
    }
}