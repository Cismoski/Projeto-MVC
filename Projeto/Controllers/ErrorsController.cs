using System;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult General()
        {
            return View();
        }

        public ActionResult Http400()
        {
            return View();
        }

        public ActionResult Http404()
        {
            return View();
        }
    }
}