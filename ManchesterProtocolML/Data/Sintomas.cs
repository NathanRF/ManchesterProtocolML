using ManchesterProtocolML.Models;
using System.Collections.Generic;

namespace ManchesterProtocolML.Data
{
    public static class Sintomas
    {
        public static Sintoma Teste { get; } = new(0, "Teste", TiposSintoma.Outros);
        public static Sintoma Teste1 { get; } = new(1, "Teste", TiposSintoma.Dispneia);
        public static Sintoma Teste2 { get; } = new(2, "Teste", TiposSintoma.Irritacao);

        public static List<Sintoma> List { get; } = new ()
        {
            Teste,
            Teste1,
            Teste2,
        };
    }
}
