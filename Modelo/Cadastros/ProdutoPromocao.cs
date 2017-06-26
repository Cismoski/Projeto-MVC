using System;
using System.ComponentModel;

namespace Modelo.Cadastros
{
    public class ProdutoPromocao : Produto
    {
        public long? ProdutoPromocaoId { get; set; }
        public long? PromocaoId { get; set; }
        [DisplayName("Quantidade em Estoque")]
        public UInt16? QtdEstoque { get; set; }
        [DisplayName("Promoção")]
        public Promocao Promocao { get; set; }
        [DisplayName("Valor em promoção")]
        double ValorPromocao { get; set; }
    }
}
