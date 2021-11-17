using ManchesterProtocolML.Models;
using ManchesterProtocolML.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentValidation.Results;
using ManchesterProtocolML.Data;

namespace ManchesterProtocolML.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PacienteController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("paciente")]
        public IActionResult Paciente(Guid? id)
        {
            var sintomas = new List<Sintoma>();
            sintomas.Add(Sintomas.Teste1);
            Paciente a = new Paciente(
            id: Guid.NewGuid(),
            nome: "1",
            idade: 80,
            sobrenome: "testado",
            horaDeEntrada: DateTime.Now,
            prontuario: new Prontuario(Guid.NewGuid(), 35, 99, 20, sintomas),
            situacao: new Situacao(Guid.NewGuid(), Statuses.Aguardando, Prioridades.Emergencia)
            );
            PacienteValidator validator = new PacienteValidator();
            ValidationResult validationResult = validator.Validate(a);

            if(!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            PacienteViewModel pacienteViewModel = new PacienteViewModel();
            pacienteViewModel.Prioridades = Prioridades.List;
            pacienteViewModel.Statuses = Statuses.List;
            pacienteViewModel.Sintomas = Sintomas.List;
            pacienteViewModel.Paciente = a;
            return View(pacienteViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
