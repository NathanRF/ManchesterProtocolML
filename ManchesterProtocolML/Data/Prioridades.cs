using ManchesterProtocolML.Models;
using System.Collections.Generic;

namespace ManchesterProtocolML.Data
{
    public static class Prioridades
    {
        public static Prioridade Emergencia { get; } = new(4, "Emergência");
        public static Prioridade MuitoUrgente { get; } = new(3, "Muito Urgente");
        public static Prioridade Urgente { get; } = new(2, "Urgente");
        public static Prioridade PoucoUrgente { get; } = new(1, "Pouco Urgente");
        public static Prioridade NaoUrgente { get; } = new(0, "Não Urgente");

        public static List<Prioridade> List { get; } = new ()
        {
            Emergencia,
            MuitoUrgente,
            Urgente,
            PoucoUrgente,
            NaoUrgente
        };
    }
}
