using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace setorPortuario.DTOs.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TipoContainer
    {
        [EnumMember(Value = "20")]
        Vinte = 20, 
        [EnumMember(Value = "40")]
        Quarenta = 40
    }
}