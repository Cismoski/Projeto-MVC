using Persistencia.Context;
using System.Linq;
using System.Data.Entity;
using Modelo.Cadastros;
using System.Collections;

namespace Persistencia.DAL.Cadastros
{
    public class PromocaoDal
    {
        private EFContext context = new EFContext();

        public IQueryable ObterPromocoesClassificadasPorNome()
        {
            return context.Promocoes.OrderBy(c => c.Descricao);
        }

        public Promocao ObterPromocaoPorId(long id)
        {
            return context.Promocoes.Where(p => p.PromocaoId == id).First();
        }

        public void GravarPromocao(Promocao promocao)
        {
            if (promocao.PromocaoId == null)
            {
                context.Promocoes.Add(promocao);
            }
            else
            {
                context.Entry(promocao).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Promocao EliminarPromocao(long id)
        {
            Promocao promocao = ObterPromocaoPorId(id);
            context.Promocoes.Remove(promocao);
            context.SaveChanges();
            return promocao;
        }

        public IList ObterPromocaoPorNome(string param)
        {
            var r = from promocao in context.Promocoes
                    where promocao.Descricao.ToUpper().StartsWith(param.ToUpper())
                    orderby (promocao.Descricao)
                    select new
                    {
                        id = promocao.PromocaoId,
                        label = promocao.Descricao,
                        value = promocao.Descricao
                    };
            return r.ToList();
        }
    }
}
