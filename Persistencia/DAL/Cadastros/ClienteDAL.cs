using Persistencia.Context;
using System.Linq;
using Modelo.Cadastros;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros
{
    public class ClienteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Cliente> ObterClienteslassificadosPorNome()
        {
            return context.Clientes.OrderBy(c => c.Nome);
        }

        public Cliente ObterClientesPorId(long id)
        {
            return context.Clientes.Where(c => c.ClienteId == id).First();
        }

        public void GravarCliente(Cliente cliente)
        {
            if (cliente.ClienteId == null)
            {
                context.Clientes.Add(cliente);
            }
            else
            {
                context.Entry(cliente).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Cliente EliminarCliente(long id)
        {
            Cliente cliente = ObterClientesPorId(id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return cliente;
        }
    }
}

