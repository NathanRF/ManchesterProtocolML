using FluentValidation;
using ManchesterProtocolML.Models;
using System;

namespace ManchesterProtocolML.Validators
{
    public class PrioridadeValidator : AbstractValidator<Prioridade>
    {
        public PrioridadeValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
                .WithMessage("Prioridade com Id inválido");

            RuleFor(c => c.Identificador).NotEmpty()
                .WithMessage("O campo 'Identificador' não pode ficar vazio");
        }
    }
}
