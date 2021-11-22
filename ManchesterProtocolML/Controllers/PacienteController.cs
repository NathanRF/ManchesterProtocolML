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
        
        [HttpGet]
        [Route("paciente")]
        public IActionResult Paciente(Guid? id)
        {
            PacienteViewModel pacienteViewModel = new PacienteViewModel();
            pacienteViewModel.Prioridades = Prioridades.List;
            pacienteViewModel.Statuses = Statuses.List;
            pacienteViewModel.Sintomas = Sintomas.List;
            return View(pacienteViewModel);
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Salvar(Paciente paciente)
        {
            //PacienteValidator p = new PacienteValidator();
            //var erros = p.Validate(paciente).Errors;
            //foreach (var erro in erros)
            //{
            //    ModelState.AddModelError(erro.ErrorCode, erro.ErrorMessage);
            //}
            return View(paciente);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
