using System.Runtime.Serialization;

namespace Feefo.Responses
{
    public enum Mode
    {
        Unknown,
        [EnumMember(Value = "product")]
        Product,
        [EnumMember(Value = "service")]
        Service
    }
}