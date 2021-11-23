using ManchesterProtocolML.Models;
using ManchesterProtocolML.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentValidation.Results;
using ManchesterProtocolML.Data;
using System.Net.Http;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
        public async Task<IActionResult> Salvar(PrioridadeViewModel paciente)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsJsonAsync("https://predictmanchester.azurewebsites.net/api/Predict", paciente);
            var priority = (await response.Content.ReadFromJsonAsync<PrioridadeResponse>());

            return Json(priority.PriorityCode);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
