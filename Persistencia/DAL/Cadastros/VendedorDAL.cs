using Persistencia.Context;
using System.Linq;
using Modelo.Cadastros;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros
{
    public class VendedorDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Vendedor> ObterVendedoresClassificadosPorNome()
        {
            return context.Vendedores.OrderBy(v => v.Nome);
        }

        public Vendedor ObterVendedorPorId(long id)
        {
            return context.Vendedores.Where(v => v.VendedorId == id).First();
        }

        public void GravarVendedor(Vendedor vendedor)
        {
            if (vendedor.VendedorId == null)
            {
                context.Vendedores.Add(vendedor);
            }
            else
            {
                context.Entry(vendedor).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Vendedor EliminarVendedor(long id)
        {
            Vendedor vendedor = ObterVendedorPorId(id);
            context.Vendedores.Remove(vendedor);
            context.SaveChanges();
            return vendedor;
        }
    }
}

