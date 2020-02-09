using System.Runtime.Serialization;

namespace Feefo.Core.Responses
{
    public enum Rating
    {
        [EnumMember(Value = "")]
        Unknown = 0,
        [EnumMember(Value = "--")]
        Bad = 1,
        [EnumMember(Value = "-")]
        Poor = 2,
        [EnumMember(Value = "+")]
        Good = 4,
        [EnumMember(Value = "++")]
        Excellent = 5,
        [EnumMember(Value = "W")]
        Withdrawn = int.MaxValue
    }
}