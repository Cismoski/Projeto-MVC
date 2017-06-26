﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Projeto.Areas.Seguranca.Models;
using Projeto.Infraestrutura;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Areas.Seguranca.Controllers
{
    public class AccountController : Controller
    {
        // GET: Seguranca/Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel details,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Usuario user = UserManager.Find(details.Nome, details.Senha);
                if(user == null){
                    ModelState.AddModelError("", "Nome ou senha invalido(s).");
                }
                else
                {
                    ClaimsIdentity ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent=false},ident);
                    if(returnUrl == null)
                        returnUrl = "/Home";
                    return Redirect(returnUrl); 
                }
            }
            return View(details);
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private GerenciadorUsuario UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}