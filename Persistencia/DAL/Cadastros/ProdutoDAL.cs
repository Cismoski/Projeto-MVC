using Persistencia.Context;
using System.Linq;
using System.Data.Entity;
using Modelo.Cadastros;
using System.Collections;

namespace Persistencia.DAL.Cadastros
{
    public class ProdutoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterProdutosClassificadosPorNome()
        {
            return context.Produtos.Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(c => c.Nome);
        }

        public Produto ObterProdutoPorId(long id)
        {
            return context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
        }

        public void GravarProduto(Produto produto)
        {
            if(produto.ProdutoId == null)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Produto EliminarProduto(long id)
        {
            Produto produto = ObterProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }

        public IList ObterProdutosPorNome(string param)
        {
            var r = from produto in context.Produtos
                    where produto.Nome.ToUpper().StartsWith(param.ToUpper())
                    orderby (produto.Nome)
                    select new
                    {
                        id = produto.ProdutoId,
                        label = produto.Nome,
                        value = produto.Nome
                    };
            return r.ToList();
        }
    }
}
