using FluentValidation;
using ManchesterProtocolML.Models;
using System;

namespace ManchesterProtocolML.Validators
{
    public class TipoSintomaValidator : AbstractValidator<TipoSintoma>
    {
        public TipoSintomaValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
                .WithMessage("Tipo de Sintoma com Id inválido");

            RuleFor(c => c.Nome).NotEmpty()
                .WithMessage("O campo 'Nome do Tipo de Sintoma' não pode ficar vazio");
        }
    }
}
