using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AnimalsLib
{    
    public enum AnimalType
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
