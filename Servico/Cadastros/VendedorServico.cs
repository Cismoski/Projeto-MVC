using System.Linq;
using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;

namespace Servico.Cadastros
{
    public class VendedorServico
    {
        private VendedorDAL vendedorDAL = new VendedorDAL();

        public IQueryable<Vendedor> ObterVendedoresClassificadosPorNome()
        {
            return vendedorDAL.ObterVendedoresClassificadosPorNome();
        }

        public Vendedor ObterVendedorPorId(long id)
        {
            return vendedorDAL.ObterVendedorPorId(id);
        }

        public void GravarVendedor(Vendedor vendedor)
        {
            vendedorDAL.GravarVendedor(vendedor);
        }

        public Vendedor RemoverVendedor(long id)
        {
            return vendedorDAL.EliminarVendedor(id);
        }
    }
}
