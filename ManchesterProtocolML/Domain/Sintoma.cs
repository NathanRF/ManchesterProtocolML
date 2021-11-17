using System;

namespace ManchesterProtocolML.Models
{
    public class Sintoma
    {
        public Sintoma(int id, string nome, TipoSintoma tipoSintoma)
        {
            Id = id;
            Nome = nome;
            TipoSintoma = tipoSintoma;
        }

        public int Id { get; }
        public string Nome { get; }
        public TipoSintoma TipoSintoma { get; }

    }
}