using System.Linq;
using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;

namespace Servico.Tabelas
{
    public class CidadeServico
    {
        private CidadeDAL cidadeDAL = new CidadeDAL();

        public IQueryable<Cidade> ObterCidadesPorEstado(long? estadoID)
        {
            return cidadeDAL.ObterCidadesPorEstado(estadoID);
        }
    }
}
