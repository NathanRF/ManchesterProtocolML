using ManchesterProtocolML.Models;
using System.Collections.Generic;

namespace ManchesterProtocolML.Data
{
    public static class Statuses
    {
        public static Status Aguardando { get; } = new(0, "Aguardando");
        public static Status EmConsulta { get; } = new(1, "Em Consulta");
        public static Status Atendido { get; } = new(2, "Atendido");

        public static List<Status> List { get; } = new ()
        {
            Aguardando,
            EmConsulta,
            Atendido
        };
    }
}
