using System.Linq;
using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Collections;

namespace Servico.Cadastros
{
    public class ProdutoServico
    {
        private ProdutoDAL produtoDAL = new ProdutoDAL();

        public IQueryable ObterProdutosClassificadosPorNome()
        {
            return produtoDAL.ObterProdutosClassificadosPorNome();
        }

        public Produto ObterProdutoPorId(long id) {
            return produtoDAL.ObterProdutoPorId(id);
        }

        public void GravarProduto(Produto produto)
        {
            produtoDAL.GravarProduto(produto);
        }

        public Produto RemoverProduto(long id)
        {
            return produtoDAL.EliminarProduto(id);
        }

        public IList ObterProdutosPorNome(string param)
        {
            return produtoDAL.ObterProdutosPorNome(param);
        }
    }
}
