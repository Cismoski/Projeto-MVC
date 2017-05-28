using Persistencia.Context;
using System.Linq;
using Modelo.Cadastros;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Fabricante> ObterFabricantesClassificadosPorNome()
        {
            return context.Fabricantes.OrderBy(c => c.Nome);
        }

        public Fabricante ObterFabricantePorId(long id)
        {
            return context.Fabricantes.Where(f => f.FabricanteId == id).First();
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            if (fabricante.FabricanteId == null)
            {
                context.Fabricantes.Add(fabricante);
            }
            else
            {
                context.Entry(fabricante).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Fabricante EliminarFabricante(long id)
        {
            Fabricante fabricante = ObterFabricantePorId(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return fabricante;
        }
    }
}

