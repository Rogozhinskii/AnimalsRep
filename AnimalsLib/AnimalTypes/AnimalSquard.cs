using System.ComponentModel;
using System.Runtime.Serialization;

namespace AnimalsLib
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum AnimalSquard
    {
        [Description("Млекопитающие")]
        [EnumMember(Value= "Mammals")]
        Mammals,
        [Description("Птичьи")]
        [EnumMember(Value = "Birds")]
        Birds,
        [EnumMember(Value = "Amphibians")]
        [Description("Амфибии")]
        Amphibians,
        [EnumMember(Value = "Unknown")]
        Unknown
    }
}
