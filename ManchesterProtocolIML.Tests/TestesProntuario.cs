using ManchesterProtocolML.Models;
using ManchesterProtocolML.Validators;
using Xunit;
using System;
using System.Collections.Generic;
using ManchesterProtocolML.Data;
using FluentValidation.TestHelper;

namespace ManchesterProtocolIML.Tests
{
    public class TestesProntuario
    {
        [Fact]
        public void ProntuarioValido()
        {
            var prontuario = new Prontuario
            (
                id: Guid.NewGuid(),
                frequenciaCardiaca: 80,
                saturacaoOxigenio: 80,
                frequenciaRespiratoria: 50,
                temperatura: 37,
                sintomas: new List <Sintoma>()
                {
                    Sintomas.List[7]
                }
             );
            var validator = new ProntuarioValidator();

            Assert.True(validator.TestValidate(prontuario).IsValid);
        }
        [Fact]
        public void ProntuarioInvalido()
        {
            var prontuario = new Prontuario
            (
                id: Guid.NewGuid(),
                frequenciaCardiaca: 300,
                saturacaoOxigenio: -10,
                frequenciaRespiratoria: 1000,
                temperatura: 37,
                sintomas: new List<Sintoma>()
             );
            var validator = new ProntuarioValidator();

            Assert.False(validator.TestValidate(prontuario).IsValid);
        }
    }
}
