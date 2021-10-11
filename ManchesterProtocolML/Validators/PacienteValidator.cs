using FluentValidation;
using ManchesterProtocolML.Models;
using System;

namespace ManchesterProtocolML.Validators
{
    public class PacienteValidator : AbstractValidator<Paciente>
    {
        public PacienteValidator()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty).WithMessage("Paciente com Id inválido");

            RuleFor(c => c.Nome).NotEmpty().WithMessage("Preencha o campo 'Nome'")
                .MinimumLength(3).WithMessage("O campo 'Nome' deve possuir no mínimo 3 caracteres")
                .MaximumLength(50).WithMessage("O campo 'Nome' deve possuir no máximo 50 caracteres");

            RuleFor(c => c.Sobrenome).NotEmpty().WithMessage("Preencha o campo 'Mensagem'")
                .MinimumLength(4).WithMessage("O campo 'Mensagem' deve possuir no mínimo 4 caracteres")
                .MaximumLength(50).WithMessage("O campo 'Mensagem' deve possuir no máximo 50 caracteres");

            RuleFor(c => c.Idade)
                .GreaterThanOrEqualTo(0).WithMessage("O campo 'Idade' deve ser maior ou igual que 0")
                .LessThan(123).WithMessage("O campo 'Idade' deve possuir no máximo 122");

            RuleFor(c => c.HoraDeEntrada)
                .GreaterThan(DateTime.UtcNow.AddDays(-1)).WithMessage("O campo 'Hora de Entrada' não deve ter uma data inferior a data atual");

            RuleFor(c => c.Prontuario).NotNull()
                .WithMessage("O prontuário do paciente não pode ficar vazio");

            RuleFor(c => c.Situacao).NotNull()
                .WithMessage("A situação do paciente não pode ficar vazia");
        }
    }
}
