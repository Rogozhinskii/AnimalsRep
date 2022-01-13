using System.Runtime.Serialization;

namespace AnimalsLib
{
    public enum AnimalSquard
    {
        [EnumMember(Value= "Mammals")]
        Mammals,
        [EnumMember(Value = "Birds")]
        Birds,
        [EnumMember(Value = "Amphibians")]
        Amphibians,
        [EnumMember(Value = "Unknown")]
        Unknown
    }
}
