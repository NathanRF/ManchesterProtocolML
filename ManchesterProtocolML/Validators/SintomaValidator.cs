using FluentValidation;
using ManchesterProtocolML.Models;
using System;

namespace ManchesterProtocolML.Validators
{
    public class SintomaValidator : AbstractValidator<Sintoma>
    {
        public SintomaValidator()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty)
                .WithMessage("Sintoma com Id inválido");

            RuleFor(c => c.Nome).NotEmpty()
                .WithMessage("O campo 'Nome do Sintoma' não pode ficar vazio");

            RuleFor(c => c.TipoSintoma).NotNull()
                .WithMessage("O campo 'Tipo de Sintoma' não pode ficar vazio");
        }
    }
}
