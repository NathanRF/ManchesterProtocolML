using FluentValidation;
using ManchesterProtocolML.Models;
using System;

namespace ManchesterProtocolML.Validators
{
    public class SituacaoValidator : AbstractValidator<Situacao>
    {
        public SituacaoValidator()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty)
                .WithMessage("Prioridade com Id inválido");

            RuleFor(c => c.Status).NotNull()
                .WithMessage("O campo 'Status' não pode ficar vazio");

            RuleFor(c => c.Prioridade).NotNull()
                .WithMessage("O campo 'Prioridade' não pode ficar vazio");
        }
    }
}
