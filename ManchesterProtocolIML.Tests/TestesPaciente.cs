using ManchesterProtocolML.Models;
using ManchesterProtocolML.Validators;
using Xunit;

namespace ManchesterProtocolIML.Tests
{
    public class TestesPaciente
    {
        [Fact]
        public void TestarCadastroInvalido()
        {
            var paciente = new Paciente();
            var validator = new PacienteValidator();

            Assert.False(validator.Validate(paciente).IsValid);
        }
        [Fact]
        public void TestarCadastroValido()
        {
            var paciente = new Paciente();
            paciente.Nome = "Tom";
            paciente.Sobrenome = "Hagen";
            var validator = new PacienteValidator();

            Assert.True(validator.Validate(paciente).IsValid);
        }
        [Fact]
        public void TestarCadastroNomeInvalido()
        {
            var paciente = new Paciente();
            paciente.Nome = "To";
            paciente.Sobrenome = "Hagen";
            var validator = new PacienteValidator();

            Assert.False(validator.Validate(paciente).IsValid);
        }
        [Fact]
        public void TestarCadastroSobrenomeInvalido()
        {
            var paciente = new Paciente();
            paciente.Nome = "Tom";
            paciente.Sobrenome = "Hag";
            var validator = new PacienteValidator();

            Assert.False(validator.Validate(paciente).IsValid);
        }
    }
}
