using Modelo.Tabelas;
using Persistencia.Context;
using System.Linq;

namespace Persistencia.DAL.Tabelas
{
    public class EstadoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Estado> ObterEstadosClassificadosPorNome()
        {
            return context.Estados.OrderBy(e => e.Nome);
        }
    }
}
