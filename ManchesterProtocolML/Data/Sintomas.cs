using ManchesterProtocolML.Models;
using System.Collections.Generic;

namespace ManchesterProtocolML.Data
{
    public static class Sintomas
    {
        public static List<Sintoma> List { get; } = new ()
        {
            new(1, "Problema recente", TiposSintoma.Outros),
            new(2, "Inchaço", TiposSintoma.Irritacao),
            new(3, "Sibilo", TiposSintoma.OuvidoNarizGarganta),
            new(4, "Criança com febre", TiposSintoma.FebreSemCausa),
            new(5, "Dor", TiposSintoma.Traumatismo),
            new(6, "Respiração reduzida", TiposSintoma.Irritacao),
            new(7, "Corrimento generalizado ou bolhas", TiposSintoma.OuvidoNarizGarganta),
            new(8, "Dor moderada", TiposSintoma.Traumatismo),
            new(9, "Lesão recente", TiposSintoma.Ferimentos),
            new(10, "Estridor", TiposSintoma.Ferimentos),
            new(11, "Sinais de desidratação", TiposSintoma.Irritacao),
            new(12, "Baixa Saturação O2", TiposSintoma.Outros),
            new(13, "Choro prolongado ou ininterrupto", TiposSintoma.Neurologico),
            new(14, "Choque", TiposSintoma.Neurologico),
            new(15, "Vômito", TiposSintoma.GastroIntestinais),
            new(16, "Novos neuro-sintomas ou sinais", TiposSintoma.Neurologico),
            new(17, "Febre", TiposSintoma.InfeccaoLocal),
            new(18, "Histórico inadequado", TiposSintoma.FebreSemCausa), // apagar
            new(19, "Nível de consciência alterado", TiposSintoma.Neurologico),
            new(20, "Sem resposta", TiposSintoma.Traumatismo), // apagar
            new(21, "Histórico significativa", TiposSintoma.Outros), // apagar
            new(22, "Histórico de trauma", TiposSintoma.Traumatismo),
            new(23, "Dor / coceira", TiposSintoma.Irritacao),
            new(24, "Hemorragia no couro cabeludo", TiposSintoma.Irritacao),
            new(25, "Acuidade visual reduzida", TiposSintoma.Outros),
            new(26, "Infecção local", TiposSintoma.InfeccaoLocal),
            new(27, "Incapaz de falar em frases", TiposSintoma.Neurologico),
            new(28, "Infecção torácica", TiposSintoma.InfeccaoLocal),
            new(29, "Histórico de asma", TiposSintoma.OuvidoNarizGarganta),
            new(30, "Via respiratória comprometida", TiposSintoma.OuvidoNarizGarganta),
            new(31, "Respiração inadequada", TiposSintoma.OuvidoNarizGarganta),
            new(32, "Passagem aguda de sangue fresco ou alteração do PR", TiposSintoma.Outros), // apagar
            new(33, "Dor forte", TiposSintoma.Traumatismo),
            new(34, "Febre alta", TiposSintoma.InfeccaoLocal),
            new(35, "Histórico de inconsciência", TiposSintoma.Traumatismo),
            new(36, "Falta de apetite", TiposSintoma.GastroIntestinais),
            new(37, "Inflamação local", TiposSintoma.InfeccaoLocal),
            new(38, "Hemorragia leve incontrolável", TiposSintoma.Ferimentos),
            new(39, "Vômito persistente", TiposSintoma.GastroIntestinais),
            new(40, "SaO2 muito baixa", TiposSintoma.Ferimentos),
            new(41, "Letalidade moderada", TiposSintoma.Outros), // apagar
            new(42, "Sem critérios", TiposSintoma.Outros), // apagar
            new(43, "Responde apenas à voz ou à dor", TiposSintoma.Irritacao), // apagar
            new(44, "Histórico psiquiátrico significativo", TiposSintoma.Irritacao), // apagar
            new(45, "Massa abdominal visível", TiposSintoma.Ferimentos),
            new(46, "Criança sem resposta", TiposSintoma.Neurologico),
            new(47, "Pulso anormal", TiposSintoma.Outros),
            new(48, "Erupção cutânea não escaldante", TiposSintoma.Irritacao),
            new(49, "Deformidade grosseira", TiposSintoma.Irritacao),
            new(50, "Dor / coceira moderada", TiposSintoma.Irritacao),
            new(51, "Comportamento atípico", TiposSintoma.Neurologico),
            new(52, "Olhos vermelhos", TiposSintoma.Irritacao),
            new(53, "Mecanismo significativo de lesão", TiposSintoma.Traumatismo), // apagar
            new(54, "Inconsolável pelos pais", TiposSintoma.Neurologico), // apagar
            new(55, "Disúria", TiposSintoma.ProblemasNoAparelhoUrinario),
            new(56, "Histórico de vômito agudo de sangue", TiposSintoma.GastroIntestinais),
            new(57, "Febre", TiposSintoma.FebreSemCausa), // apagar
            new(58, "Mecanismo de lesão", TiposSintoma.Ferimentos), // apagar
            new(59, "Não urina", TiposSintoma.ProblemasNoAparelhoUrinario),
            new(60, "Sem melhora com o próprio tratamento para asma", TiposSintoma.OuvidoNarizGarganta),
            new(61, "Dor pleurítica", TiposSintoma.Ferimentos),
            new(62, "Não reage aos pais", TiposSintoma.Neurologico), // apagar
            new(63, "Hemorragia grave incontrolável", TiposSintoma.Ferimentos),
            new(64, "Sinal de meningismo", TiposSintoma.OuvidoNarizGarganta),
            new(65, "Em adaptação", TiposSintoma.Irritacao), // apagar
            new(66, "Edema facial", TiposSintoma.Irritacao),
            new(67, "Hiperglicemia", TiposSintoma.Outros),
            new(68, "Histórico de doenças hematológicas", TiposSintoma.Outros),
            new(69, "Incapacidade de manter o próprio peso", TiposSintoma.Outros),
            new(70, "Histórico de vômito com sangue", TiposSintoma.GastroIntestinais),
            new(71, "Imunossupressão conhecida", TiposSintoma.InfeccaoLocal),
            new(72, "'Idade <25 anos", TiposSintoma.Outros),
            new(73, "Edema facial", TiposSintoma.Ferimentos), // apagar
            new(74, "Fezes com coloração anormal", TiposSintoma.GastroIntestinais),
            new(75, "Dor de cabeça", TiposSintoma.Traumatismo),
            new(76, "TRTS 1-10", TiposSintoma.Irritacao), // apagar
            new(77, "Angústia", TiposSintoma.Irritacao), // apagar
            new(78, "Alto risco de automutilação", TiposSintoma.Neurologico),
            new(79, "Sangue na urina", TiposSintoma.ProblemasNoAparelhoUrinario),
            new(80, "Trauma direto no pescoço", TiposSintoma.Traumatismo),
            new(81, "Dor cardíaca", TiposSintoma.Outros),
            new(82, "Lesão torácica", TiposSintoma.Ferimentos),
            new(83, "Deformidade", TiposSintoma.Traumatismo),
            new(84, "Alta letalidade", TiposSintoma.Ferimentos),
            new(85, "Dor com cólica", TiposSintoma.GastroIntestinais),
            new(86, "Vômito agudo de sangue", TiposSintoma.GastroIntestinais),
            new(87, "Trauma penetrante", TiposSintoma.Traumatismo),
            new(88, "Comprometimento vascular", TiposSintoma.Outros),
            new(89, "Início rápido", TiposSintoma.Irritacao), // apagar
            new(90, "Desordem de sangramento", TiposSintoma.Irritacao), // apagar
            new(91, "Hemorragia exsangüinante", TiposSintoma.Traumatismo),
            new(92, "Dor ao mover as articulações", TiposSintoma.Irritacao),
            new(93, "Celulite escrotal", TiposSintoma.Irritacao),
            new(94, "Sensibilidade do couro cabeludo", TiposSintoma.Irritacao),
            new(95, "Reação alérgica", TiposSintoma.Irritacao),
            new(96, "Nível de consciência alterado não totalmente atribuível ao álcool", TiposSintoma.Neurologico),
            new(97, "Erupção cutânea não reconhecida", TiposSintoma.InfeccaoLocal),
            new(98, "Exaustão", TiposSintoma.Outros),
            new(99, "Perda auditiva aguda", TiposSintoma.OuvidoNarizGarganta),
            new(100, "Trauma vaginal", TiposSintoma.Traumatismo),
            new(101, "Comprometimento vascular distal", TiposSintoma.Outros),
            new(102, "Baixa temperatura corporal", TiposSintoma.Outros),
            new(103, "Comprometimento das vias aéreas", TiposSintoma.OuvidoNarizGarganta),
            new(104, "Trauma direto nas costas", TiposSintoma.Traumatismo),
            new(105, "Risco moderado de automutilação", TiposSintoma.Neurologico),
            new(106, "Perda de função focal ou progressiva", TiposSintoma.Outros),
            new(107, "Início agudo após lesão", TiposSintoma.Irritacao), // apagar
            new(108, "Sangue com vômitos", TiposSintoma.Outros),
            new(109, "Articulação quente", TiposSintoma.Irritacao),
            new(110, "Hiperglicemia com cetose", TiposSintoma.Outros),
            new(111, "Trauma escrotal", TiposSintoma.Irritacao),
            new(112, "Dor forte ou coceira", TiposSintoma.Irritacao),
            new(113, "Histórico de viagens ao exterior", TiposSintoma.Outros),
            new(114, "Babando", TiposSintoma.Traumatismo),
            new(115, "Grande perda de sangue por policitemia vera", TiposSintoma.Outros),
            new(116, "Início abrupto", TiposSintoma.Irritacao), // apagar
            new(117, "Pico de fluxo expiratório muito baixo", TiposSintoma.OuvidoNarizGarganta),
            new(118, "Dor irradiando para o ombro", TiposSintoma.Traumatismo),
            new(119, "Lesão na cabeça", TiposSintoma.Traumatismo),
            new(120, "Floppy", TiposSintoma.Irritacao), // apagar
            new(121, "Lesão química ocular", TiposSintoma.Irritacao),
            new(122, "Hematoma auricular", TiposSintoma.OuvidoNarizGarganta),
            new(123, "Fratura exposta", TiposSintoma.Traumatismo),
            new(124, "Disruptiva", TiposSintoma.Irritacao), // apagar
            new(125, "Histórico de traumatismo craniano", TiposSintoma.Traumatismo),
            new(126, "Vertigem", TiposSintoma.OuvidoNarizGarganta),
            new(127, "Hipoglicemia", TiposSintoma.Outros),
            new(128, "Edema da língua", TiposSintoma.Irritacao),
            new(129, "Histórico médico significativo", TiposSintoma.Irritacao), // retirar
            new(130, "Inalação de fumaça", TiposSintoma.Irritacao),
            new(131, "Dente agudamente avulsionado", TiposSintoma.Traumatismo),
            new(132, "Pico de fluxo expiratório baixo", TiposSintoma.OuvidoNarizGarganta),
            new(133, "Lesão química por inalação", TiposSintoma.Irritacao),
            new(134, "Nível de consciência alterado totalmente atribuível ao álcool", TiposSintoma.Outros),
            new(135, "Queimaduras químicas", TiposSintoma.Irritacao),
            new(136, "Condição cutânea crítica", TiposSintoma.Irritacao),
            new(137, "Incapaz de se alimentar", TiposSintoma.GastroIntestinais),
            new(138, "Dificuldade de andar", TiposSintoma.Ferimentos),
            new(139, "Dor abdominal", TiposSintoma.GastroIntestinais),
            new(140, "Hiperglicêmica com cetose", TiposSintoma.Outros),
            new(141, "Lesão ocular penetrante", TiposSintoma.Ferimentos),
            new(142, "Sem distração", TiposSintoma.Irritacao), // apagar
            new(143, "Incapaz de andar", TiposSintoma.Traumatismo),
            new(144, "Falta de ar aguda", TiposSintoma.Ferimentos),
            new(145, "Histórico de sobredosagem ou intoxicação", TiposSintoma.Outros),
            new(146, "Lesão elétrica", TiposSintoma.Ferimentos),
            new(147, "Perda total aguda de visão", TiposSintoma.Neurologico),
            new(148, "Alto risco de causar danos a outras pessoas", TiposSintoma.Neurologico),
            new(149, "Lesão por inalação", TiposSintoma.Ferimentos),
            new(150, "> 24 semanas de gravidez", TiposSintoma.Outros),
            new(151, "Possível gravidez", TiposSintoma.Outros),
            new(152, "Dor com irradiação para as costas", TiposSintoma.Ferimentos),
            new(153, "Menstruação normal", TiposSintoma.Outros),
            new(154, "Lesão ocular", TiposSintoma.Ferimentos),
            new(155, "Histórico de overdose ou intoxicação", TiposSintoma.Outros),
            new(156, "Grande hemorragia controlável", TiposSintoma.Ferimentos),
        };
    }
}
