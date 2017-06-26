using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Projeto.DAL;
using Projeto.Areas.Seguranca.Models;
using Microsoft.Owin;

namespace Projeto.Infraestrutura
{
    public class GerenciadorUsuario : UserManager<Usuario>
    {
        public GerenciadorUsuario(IUserStore<Usuario> store): base(store){}

        public static GerenciadorUsuario Create(IdentityFactoryOptions<GerenciadorUsuario> options,IOwinContext context)
        {
            IdentityDbContextAplicacao db = context.Get <IdentityDbContextAplicacao>();
            GerenciadorUsuario manager = new GerenciadorUsuario(new UserStore<Usuario>(db));
            return manager;
        }
    }
}