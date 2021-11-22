namespace ManchesterProtocolML.Models
{
    public class TipoSintoma
    {
        public TipoSintoma()
        {

        }
        public TipoSintoma(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; }
        public string Nome { get; }
    }
}
