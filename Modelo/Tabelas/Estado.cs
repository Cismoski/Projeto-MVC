using System.Collections.Generic;

namespace Modelo.Tabelas
{
    public class Estado
    {
        public long? EstadoID { get; set; }
        public string UF { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
