using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Promocao
    {
        [DisplayName("Id")]
        public long? PromocaoId { get; set; }

        [Required(ErrorMessage = "Informe a descrição da promoção")]
        public string Descricao { get; set; }

        [DisplayName("Data de Inicio")]
        [Required(ErrorMessage = "Informe a data de inicio da promoção")]
        public DateTime? DataInicio { get; set; }

        [DisplayName("Data de Término")]
        [Required(ErrorMessage = "Informe a data de término da promoção")]
        public DateTime? DataFim { get; set; }

        [DisplayName("Produtos em promoção")]
        [Required(ErrorMessage = "Infome ao menos um produto na promoção")]
        public virtual ICollection<ProdutoPromocao> Produtos { get; set; }
}
}