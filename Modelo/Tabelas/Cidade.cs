namespace Modelo.Tabelas
{
    public class Cidade
    {
        public long? CidadeID { get; set; }
        public long? EstadoID { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }
    }
}
