using System.Linq;
using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;

namespace Servico.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable<Fabricante> ObterFabricantesClassificadosPorNome()
        {
            return fabricanteDAL.ObterFabricantesClassificadosPorNome();
        }

        public Fabricante ObterFabricantePorId(long id)
        {
            return fabricanteDAL.ObterFabricantePorId(id);
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            fabricanteDAL.GravarFabricante(fabricante);
        }

        public Fabricante RemoverFabricante(long id)
        {
            return fabricanteDAL.EliminarFabricante(id);
        }
    }
}
