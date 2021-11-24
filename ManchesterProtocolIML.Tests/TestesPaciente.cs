using ManchesterProtocolML.Models;
using ManchesterProtocolML.Validators;
using Xunit;
using System;
using System.Collections.Generic;
using ManchesterProtocolML.Data;
using FluentValidation.TestHelper;
using System.Linq;

namespace ManchesterProtocolIML.Tests
{
    public class TestesPaciente
    {
        [Fact]
        public void CadastroInvalido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "",
                sobrenome: "",
                idade: -1,
                horaDeEntrada: DateTime.Now,
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                    {
                        Sintomas.List[3]
                    }
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.Aguardando, Prioridades.Emergencia)
            );
            var validator = new PacienteValidator();

            Assert.False(validator.TestValidate(paciente).IsValid);
        }
        [Fact]
        public void CadastroValido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "Tom",
                sobrenome: "Hagen",
                idade: 80,
                horaDeEntrada: DateTime.Now,
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.Aguardando, Prioridades.PoucoUrgente)
            );
            var validator = new PacienteValidator();

            Assert.True(validator.TestValidate(paciente).IsValid);
        }
        [Fact]
        public void HoraDeChegadaInvalida()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "",
                sobrenome: "",
                idade: -1,
                horaDeEntrada: DateTime.Now.AddDays(-1),
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.Aguardando, Prioridades.NaoUrgente)
            );
            var validator = new PacienteValidator();

            Assert.False(validator.TestValidate(paciente).IsValid);
        }
        [Fact]
        public void HoraDeChegadaValida()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "",
                sobrenome: "",
                idade: -1,
                horaDeEntrada: DateTime.Now.AddHours(1),
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.Aguardando, Prioridades.NaoUrgente)
            );
            var validator = new PacienteValidator();

            Assert.False(validator.TestValidate(paciente).IsValid);
        }
        [Fact]
        public void CadastroNomeInvalido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "To",
                sobrenome: "Hagen",
                idade: 80,
                horaDeEntrada: DateTime.Now,
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.Atendido, Prioridades.MuitoUrgente)
            );
            var validator = new PacienteValidator();

            Assert.True(validator.TestValidate(paciente).ShouldHaveValidationErrorFor("Nome").Any());
        }
        [Fact]
        public void CadastroSobrenomeInvalido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "Tom",
                sobrenome: "Hag",
                idade: 80,
                horaDeEntrada: DateTime.Now,
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.EmConsulta, Prioridades.Urgente)
            );
            var validator = new PacienteValidator();

            Assert.True(validator.TestValidate(paciente).ShouldHaveValidationErrorFor("Sobrenome").Any());
        }
        [Fact]
        public void CadastroIdadeInvalido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "Tom",
                sobrenome: "Hagem",
                idade: -1,
                horaDeEntrada: DateTime.Now,
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.EmConsulta, Prioridades.Urgente)
            );
            var validator = new PacienteValidator();

            Assert.True(validator.TestValidate(paciente).ShouldHaveValidationErrorFor("Idade").Any());
        }
        [Fact]
        public void CadastroIdadeValido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "Tom",
                sobrenome: "Hagem",
                idade: 80,
                horaDeEntrada: DateTime.Now,
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.EmConsulta, Prioridades.Urgente)
            );
            var validator = new PacienteValidator();

            validator.TestValidate(paciente).ShouldNotHaveValidationErrorFor("Idade");
        }
        [Fact]
        public void CadastroProntuarioInvalido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "Tom",
                sobrenome: "Hagem",
                idade: 80,
                horaDeEntrada: DateTime.Now,
                prontuario: null,
                situacao: new Situacao(Guid.NewGuid(), Statuses.EmConsulta, Prioridades.Urgente)
            );
            var validator = new PacienteValidator();

            Assert.True(validator.TestValidate(paciente).ShouldHaveValidationErrorFor("Prontuario").Any());
        }
        [Fact]
        public void CadastroProntuarioValido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "Tom",
                sobrenome: "Hagem",
                idade: 123,
                horaDeEntrada: DateTime.Now,
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.EmConsulta, Prioridades.Urgente)
            );
            var validator = new PacienteValidator();

            validator.TestValidate(paciente).ShouldNotHaveValidationErrorFor("Prontuario");
        }
        [Fact]
        public void CadastroSituacaoInvalido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "Tom",
                sobrenome: "Hagem",
                idade: 50,
                horaDeEntrada: DateTime.Now,
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: null
            );
            var validator = new PacienteValidator();

            Assert.True(validator.TestValidate(paciente).ShouldHaveValidationErrorFor("Situacao").Any());
        }
        [Fact]
        public void CadastroSituacaoValido()
        {
            var paciente = new Paciente
            (
                id: Guid.NewGuid(),
                nome: "Tom",
                sobrenome: "Hagem",
                idade: 0,
                horaDeEntrada: DateTime.Now,
                prontuario: new Prontuario
                (
                    id: Guid.NewGuid(),
                    frequenciaCardiaca: 59,
                    saturacaoOxigenio: 98,
                    frequenciaRespiratoria: 89,
                    temperatura: 37,
                    sintomas: new List<Sintoma>()
                ),
                situacao: new Situacao(Guid.NewGuid(), Statuses.EmConsulta, Prioridades.Urgente)
            );
            var validator = new PacienteValidator();

            validator.TestValidate(paciente).ShouldNotHaveValidationErrorFor("Situacao");
        }
    }
}
