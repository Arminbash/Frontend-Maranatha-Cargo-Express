using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaranathaCargoExpress.Web.Controllers
{
    public class DocumentoController : Controller
    {
        // GET: Documento
        public ActionResult Documento()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            return View();
        }
    }
}