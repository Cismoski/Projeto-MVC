using Persistencia.Context;
using System.Linq;
using Modelo.Tabelas;
using System.Data.Entity;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return context.Categorias.OrderBy(c => c.Nome);
        }

        public Categoria ObterCategoriaPorId(long id)
        {
            return context.Categorias.Where(c => c.CategoriaId == id).First();
        }

        public void GravarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Categoria EliminarCategoria(long id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}
