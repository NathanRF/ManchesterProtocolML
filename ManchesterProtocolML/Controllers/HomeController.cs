using ManchesterProtocolML.Data;
using ManchesterProtocolML.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ManchesterProtocolML.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var sintomas = new List<Sintoma>();
            sintomas.Add(Sintomas.Teste1);
            Paciente a = new Paciente(
            id: Guid.Parse("8dd65072-9a93-4c08-8914-19d03e18c111"),
            nome: "1",
            idade: 80,
            sobrenome: "testado",
            horaDeEntrada: DateTime.Now,
            prontuario: new Prontuario(Guid.NewGuid(), 35, 89, 99, 20, sintomas),
            situacao: new Situacao(Guid.NewGuid(), Statuses.Aguardando, Prioridades.PoucoUrgente)
            );
            List<Paciente> ps = new List<Paciente>
            {
                a,
                a,
                a,
                a,
                a,
                a,
                a,
                a,
                a,
                a,
                a,
                a,
                a,
                a,
                a,
                a

            };
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
