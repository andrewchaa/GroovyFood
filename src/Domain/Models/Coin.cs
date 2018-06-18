using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Domain.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Coin
    {
        BTC,
        ETH,
        LTC
    }
}