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

            RuleFor(c => c.Sobrenome).NotEmpty().WithMessage("Preencha o campo 'Sobrenome'")
                .MinimumLength(4).WithMessage("O campo 'Sobrenome' deve possuir no mínimo 4 caracteres")
                .MaximumLength(100).WithMessage("O campo 'Sobrenome' deve possuir no máximo 100 caracteres");

            RuleFor(c => c.Idade)
                .InclusiveBetween(0, 123).WithMessage("O campo 'Idade' deve ter um valor entre 0 e 123");

            RuleFor(c => c.HoraDeEntrada)
                .InclusiveBetween(DateTime.Now.Date, DateTime.Now.Date.AddDays(1).AddTicks(-1))
                .WithMessage("O campo 'Hora de Chegada' não deve ter uma data diferente da data atual");

            RuleFor(c => c.Prontuario).NotNull()
                .WithMessage("O prontuário do paciente não pode ficar vazio");

            RuleFor(c => c.Situacao).NotNull()
                .WithMessage("A situação do paciente não pode ficar vazia");
        }
    }
}
