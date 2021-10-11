using System;

namespace ManchesterProtocolML.Models
{
    public class Prontuario
    {
        public Guid Id { get; set; }
        public int FrequenciaCardiaca { get; set; }
        public int SaturacaoOxigenio { get; set; }
        public int FrequenciaRespiratoria { get; set; }
        public Sintoma Sintoma { get; set; }
    }
}