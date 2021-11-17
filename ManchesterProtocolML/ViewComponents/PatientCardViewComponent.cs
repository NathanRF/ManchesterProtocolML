using ManchesterProtocolML.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ManchesterProtocolML.ViewComponents
{
    [ViewComponent(Name = "PatientCard")]
    public class PatientCardViewComponent : ViewComponent
    {
        public Paciente Paciente { get; set; }
        public PatientCardViewComponent()
        {
            //Paciente = new Paciente();
            //Paciente.Nome = "Teste";
        }
        public async Task<IViewComponentResult> InvokeAsync(Paciente paciente)
        {
            return View(paciente);
        }
    }
}
