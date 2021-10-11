using System;

namespace ManchesterProtocolML.Models
{
    public class Sintoma
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoSintoma TipoSintoma { get; set; }
    }
}