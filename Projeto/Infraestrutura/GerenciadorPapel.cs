using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Projeto.DAL;
using Projeto.Areas.Seguranca.Models;
using Microsoft.Owin;
using System;

namespace Projeto.Infraestrutura
{
    public class GerenciadorPapel : RoleManager<Papel>, IDisposable
    {
        public GerenciadorPapel(RoleStore<Papel> store) : base(store) { }

        public static GerenciadorPapel Create(IdentityFactoryOptions<GerenciadorPapel> options, IOwinContext context)
        {
            return new GerenciadorPapel(new RoleStore<Papel>(context.Get<IdentityDbContextAplicacao>()));
        }
    }
}