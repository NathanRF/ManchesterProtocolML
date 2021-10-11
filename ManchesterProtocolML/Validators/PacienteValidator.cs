using FluentValidation;
using ManchesterProtocolML.Models;

namespace ManchesterProtocolML.Validators
{
    public class PacienteValidator : AbstractValidator<Paciente>
    {
        public PacienteValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Preencha o campo 'Nome'")
                .MinimumLength(3).WithMessage("O campo 'Nome' deve possuir no mínimo 3 caracteres")
                .MaximumLength(50).WithMessage("O campo 'Nome' deve possuir no máximo 50 caracteres");

            RuleFor(c => c.Sobrenome).NotEmpty().WithMessage("Preencha o campo 'Mensagem'")
                .MinimumLength(4).WithMessage("O campo 'Mensagem' deve possuir no mínimo 4 caracteres")
                .MaximumLength(50).WithMessage("O campo 'Mensagem' deve possuir no máximo 50 caracteres");
        }
    }
}
