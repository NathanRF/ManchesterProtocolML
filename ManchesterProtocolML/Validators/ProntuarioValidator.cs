using FluentValidation;
using ManchesterProtocolML.Models;
using System;

namespace ManchesterProtocolML.Validators
{
    public class ProntuarioValidator : AbstractValidator<Prontuario>
    {
        public ProntuarioValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Prontuário com Id inválido");

            RuleFor(c => c.FrequenciaCardiaca)
                .LessThan(200)
                .WithMessage("O campo 'Frequência Cardiaca' não deve ser maior que 200")
                .GreaterThan(0)
                .WithMessage("O campo 'Frequência Cardiaca' deve ser maior ou igual a 0");

            RuleFor(c => c.SaturacaoOxigenio)
                .LessThan(101)
                .WithMessage("O campo 'Saturação de Oxigênio' não deve ser maior que 100")
                .GreaterThan(0)
                .WithMessage("O campo 'Saturação de Oxigênio' deve ser maior ou igual a 0");

            RuleFor(c => c.FrequenciaRespiratoria)
                .LessThan(100)
                .WithMessage("O campo 'Frequência Respiratória' não deve ser maior que 100")
                .GreaterThan(0)
                .WithMessage("O campo 'Frequência Respiratória' deve ser maior ou igual a 0");

            RuleFor(c => c.Sintomas).NotEmpty()
                .WithMessage("O sintoma precisa ser informado no prontuário");
        }
    }
}
