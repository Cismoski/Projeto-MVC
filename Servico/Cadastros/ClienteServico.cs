using System.Linq;
using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;

namespace Servico.Cadastros
{
    public class ClienteServico
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public IQueryable<Cliente> ObterClientesClassificadosPorNome()
        {
            return clienteDAL.ObterClienteslassificadosPorNome();
        }

        public Cliente ObterClientePorId(long id)
        {
            return clienteDAL.ObterClientesPorId(id);
        }

        public void GravarCliente(Cliente cliente)
        {
            clienteDAL.GravarCliente(cliente);
        }

        public Cliente RemoverCliente(long id)
        {
            return clienteDAL.EliminarCliente(id);
        }
    }
}
