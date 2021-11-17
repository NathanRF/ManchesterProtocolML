using System;

namespace ManchesterProtocolML.Models
{
    public class Situacao
    {
        public Situacao(Guid id, Status status, Prioridade prioridade)
        {
            Id = id;
            Status = status;
            Prioridade = prioridade;
        }

        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}