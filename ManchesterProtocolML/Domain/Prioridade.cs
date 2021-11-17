using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ManchesterProtocolML.Models
{
    public class Prioridade
    {
        public Prioridade(int id, string identificador)
        {
            Id = id;
            Identificador = identificador;
        }

        public int Id { get; set; }
        public string Identificador { get; set; }
        public string IdentificadorNormalizado
        {
            get {
                string result;
                if (string.IsNullOrWhiteSpace(Identificador))
                    return Identificador;

                result = Identificador.Normalize(NormalizationForm.FormD);
                var chars = result.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
                return new string(chars).ToLower().Replace(' ', '-').Normalize(NormalizationForm.FormC);
            }
        }

    }
}
