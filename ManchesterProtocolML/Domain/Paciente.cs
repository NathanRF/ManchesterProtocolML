using System;

namespace ManchesterProtocolML.Models
{
    public class Paciente
    {
        public Paciente(Guid id, string nome, string sobrenome, int idade, DateTime horaDeEntrada, Prontuario prontuario, Situacao situacao)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Idade = idade;
            HoraDeEntrada = horaDeEntrada;
            Prontuario = prontuario;
            Situacao = situacao;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int? Idade { get; set; }
        public DateTime HoraDeEntrada { get; set; }
        public Prontuario Prontuario { get; set; }
        public Situacao Situacao { get; set; }
    }
}
