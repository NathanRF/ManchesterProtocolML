using System;
using System.Collections.Generic;
using System.Text;

namespace ManchesterProtocolML.Models
{
    public class Prontuario
    {
        public Prontuario()
        {

        }
        public Prontuario(Guid id, int frequenciaCardiaca, int temperatura, int saturacaoOxigenio, int frequenciaRespiratoria, List<Sintoma> sintomas)
        {
            Id = id;
            FrequenciaCardiaca = frequenciaCardiaca;
            SaturacaoOxigenio = saturacaoOxigenio;
            FrequenciaRespiratoria = frequenciaRespiratoria;
            Sintomas = sintomas;
            Temperatura = temperatura;
        }

        public Guid Id { get; set; }
        public int? FrequenciaCardiaca { get; set; }
        public int? Temperatura { get; set; }
        public int? SaturacaoOxigenio { get; set; }
        public int? FrequenciaRespiratoria { get; set; }
        public List<Sintoma> Sintomas { get; set; }
        public string ListaSintomas
        {
            get
            {
                StringBuilder sintomas = new StringBuilder();
                Sintomas?.ForEach(s => sintomas.AppendJoin(", ", s.Nome));
                return sintomas.ToString();
            }
        }

    }
}