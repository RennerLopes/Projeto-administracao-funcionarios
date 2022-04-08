using System.Runtime.Serialization;

namespace SixConsult.Funcionarios.Classes
{
    public enum TipoTelefone
    {
        [EnumMember(Value = "Fixo")]
        Fixo,
        [EnumMember(Value = "Celular")]
        Celular
    }
}