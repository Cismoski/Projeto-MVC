using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc;
using Projeto.Infraestrutura;

namespace Projeto.Areas.Seguranca.Models
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            GerenciadorUsuario mgr = HttpContext.Current.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }

        public static MvcHtmlString GetAuthenticatedUser(this HtmlHelper html)
        {
            return new MvcHtmlString(HttpContext.Current.User.Identity.Name);
        }
    }
}