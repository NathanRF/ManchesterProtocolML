using ManchesterProtocolML.Models;
using ManchesterProtocolML.Validators;
using Xunit;
using System;
using System.Collections.Generic;
using ManchesterProtocolML.Data;
using FluentValidation.TestHelper;

namespace ManchesterProtocolIML.Tests
{
    public class TestesSituacao
    {
        [Fact]
        public void SituacaoValida()
        {
            var situacao = new Situacao
            (
                id: Guid.NewGuid(),
                status: new Status(1, "Situacao"),
                prioridade: new Prioridade(0, "Urgente")
             );
            var validator = new SituacaoValidator();

            Assert.True(validator.TestValidate(situacao).IsValid);
        }
        [Fact]
        public void SituacaoInvalida()
        {
            var situacao = new Situacao
            (
                id: Guid.NewGuid(),
                status: null,
                prioridade: null
             );
            var validator = new SituacaoValidator();

            Assert.False(validator.TestValidate(situacao).IsValid);
        }
    }
}

