using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace TaxCalculator.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VatInputType
    {
        Net = 0,
        Gross = 1,
        Vat = 2
    }
}
