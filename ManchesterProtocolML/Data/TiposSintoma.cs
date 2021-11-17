using ManchesterProtocolML.Models;

namespace ManchesterProtocolML.Data
{
    public static class TiposSintoma
    {
        public static TipoSintoma Outros { get; } = new(0, "Outros");
        public static TipoSintoma GastroIntestinais { get; } = new(1, "Gastro Intestinais");
        public static TipoSintoma ProblemasNoAparelhoUrinario { get; } = new(2, "Problemas No Aparelho Urinario");
        public static TipoSintoma Traumatismo { get; } = new(3, "Traumatismo");
        public static TipoSintoma OuvidoNarizGarganta { get; } = new(4, "Ouvido Nariz Garganta");
        public static TipoSintoma Ferimentos { get; } = new(5, "Ferimentos");
        public static TipoSintoma FebreSemCausa { get; } = new(6, "Febre Sem Causa");
        public static TipoSintoma Neurologico { get; } = new(7, "Neurológico");
        public static TipoSintoma Dispneia { get; } = new(8, "Dispneia");
        public static TipoSintoma Irritacao { get; } = new(9, "Irritação");
        public static TipoSintoma InfeccaoLocal { get; } = new(10, "Infecção Local");
    }
}
