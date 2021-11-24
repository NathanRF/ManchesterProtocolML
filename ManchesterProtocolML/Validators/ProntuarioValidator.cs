using FluentValidation;
using ManchesterProtocolML.Models;

namespace ManchesterProtocolML.Validators
{
    public class ProntuarioValidator : AbstractValidator<Prontuario>
    {
        public ProntuarioValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("* Prontuário com Id inválido");

            RuleFor(c => c.FrequenciaCardiaca)
                .InclusiveBetween(0, 200)
                .WithMessage("* O campo 'Frequência Cardiaca' deve ter um valor entre 0 e 200");

            RuleFor(c => c.SaturacaoOxigenio)
                .InclusiveBetween(0, 101)
                .WithMessage("* O campo 'Saturação de Oxigênio' deve ter um valor entre 0 e 100");

            RuleFor(c => c.FrequenciaRespiratoria)
                .InclusiveBetween(0, 100)
                .WithMessage("* O campo 'Frequência Respiratória' deve ter um valor entre 0 e 100");

            RuleFor(c => c.Temperatura)
                .InclusiveBetween(34, 42)
                .WithMessage("* O campo 'Temperatura' deve ter um valor entre 34 e 42");

            RuleFor(c => c.Sintomas).NotEmpty()
                .WithMessage("* O sintoma precisa ser informado no prontuário");
        }
    }
}
