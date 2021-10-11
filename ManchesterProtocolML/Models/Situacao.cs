using System;

namespace ManchesterProtocolML.Models
{
    public class Situacao
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}