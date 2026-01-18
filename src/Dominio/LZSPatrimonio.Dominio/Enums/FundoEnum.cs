using System.ComponentModel;

namespace LZSPatrimonio.Dominio.Enums;

public enum FundoEnum
{
    [Description("PM")]
    PM = 0,
    [Description("CM")]
    CM = 1,
    [Description("FUNDO SAUDE")]
    FSAUDE = 2,
    [Description("FUNDO EDUCAÇÃO")]
    FEDUCACAO = 3,
    [Description("FUNDO ESPORTE")]
    FESPORTE = 4,
    [Description("FUNDO INFRAESTRUTURA")]
    FINFRA = 5,
}
