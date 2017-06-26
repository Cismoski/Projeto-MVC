using System.Linq;
using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Collections;

namespace Servico.Cadastros
{
    public class PromocaoServico
    {
        private PromocaoDal promocaoDAL = new PromocaoDal();

        public IQueryable ObterPromocoesClassificadasPorNome()
        {
            return promocaoDAL.ObterPromocoesClassificadasPorNome();
        }

        public Promocao ObterPromocaoPorId(long id)
        {
            return promocaoDAL.ObterPromocaoPorId(id);
        }

        public void GravarPromocao(Promocao promocao)
        {
            promocaoDAL.GravarPromocao(promocao);
        }

        public Promocao RemoverPromocao(long id)
        {
            return promocaoDAL.EliminarPromocao(id);
        }

        public IList ObterPromocaoPorNome(string param)
        {
            return promocaoDAL.ObterPromocaoPorNome(param);
        }
    }
}
