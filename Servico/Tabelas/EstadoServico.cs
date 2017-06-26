using System.Linq;
using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;

namespace Servico.Tabelas
{
    public class EstadoServico
    {
        private EstadoDAL estadoDAL = new EstadoDAL();
        
        public IQueryable<Estado> ObterEstadosClassificadosPorNome()
        {
            return estadoDAL.ObterEstadosClassificadosPorNome();
        }
    }

}
