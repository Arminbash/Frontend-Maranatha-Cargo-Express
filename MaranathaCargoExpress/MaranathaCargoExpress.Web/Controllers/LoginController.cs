using MaranathaCargoExpress.Service.Service;
using MaranathaCargoExpress.Service.ViewModel;
using System;
using System.Net;
using System.Web.Mvc;

namespace MaranathaCargoExpress.Web.Controllers
{
    [NoLoginAttribute]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService = new LoginService();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(LoginDto user)
        {
           var request =  _loginService.Login(user.Email, user.Password);
            if (request.Result == null)
            {
                return new BadRequest();
            }
            SessionHelper.AddUserToSession(request.Result,"Empleado");
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
    }
}