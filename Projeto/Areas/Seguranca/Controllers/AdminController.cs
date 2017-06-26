using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Projeto.Areas.Seguranca.Models;
using Projeto.Infraestrutura;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Areas.Seguranca.Controllers
{
    public class AdminController : Controller
    {

        [Authorize(Roles ="Administradores")]
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }
        private GerenciadorUsuario GerenciadorUsuario{
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }

        [Authorize(Roles = "Administradores")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administradores")]
        [HttpPost]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario
                {
                    UserName = model.Nome,
                    Email = model.Email
                };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [Authorize(Roles = "Administradores")]
        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if(usuario == null)
            {
                return HttpNotFound();
            }
            var uvm = new UsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.UserName,
                Email = usuario.Email
            };
            return View(uvm);
        }

        [Authorize(Roles = "Administradores")]
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = GerenciadorUsuario.FindById(uvm.Id);

                usuario.UserName = uvm.Nome;
                usuario.Email = uvm.Email;
                usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.HashPassword(uvm.Senha);
                IdentityResult result = GerenciadorUsuario.Update(usuario);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(uvm);  
        }

        [Authorize(Roles = "Administradores")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [Authorize(Roles = "Administradores")]
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            Usuario user = GerenciadorUsuario.FindById(usuario.Id);
            if(user != null)
            {
                IdentityResult result = GerenciadorUsuario.Delete(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return HttpNotFound();
            }
        }

        [Authorize(Roles = "Administradores")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
    }
}