using FluentValidation;
using ManchesterProtocolML.Models;
using System;

namespace ManchesterProtocolML.Validators
{
    public class StatusValidator : AbstractValidator<Status>
    {
        public StatusValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
                .WithMessage("Status com Id inválido");

            RuleFor(c => c.Identificador).NotEmpty()
                .WithMessage("O campo 'Identificador' não pode ficar vazio");
        }
    }
}
