using System.Collections.Generic;

namespace ManchesterProtocolML.Models
{
    public class PacienteViewModel
    {
        public Paciente Paciente { get; set; }
        public List<Sintoma> Sintomas { get; set; }
        public List<Status> Statuses { get; set; }
        public List<Prioridade> Prioridades { get; set; }
    }
}
