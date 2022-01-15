using System.ComponentModel;

namespace AnimalsLib
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SaveOptions
    {
        [Description("Json")]
        SaveToJson,
        [Description("Текстовый файл")]
        SaveToTxt,
        [Description("Excel")]
        SaveToExcel
    }
}
