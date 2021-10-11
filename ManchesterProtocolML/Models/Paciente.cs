using System;

namespace ManchesterProtocolML.Models
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public DateTime HoraDeEntrada { get; set; }
        public Prontuario Prontuario { get; set; }
        public Situacao Situacao { get; set; }
    }
}
