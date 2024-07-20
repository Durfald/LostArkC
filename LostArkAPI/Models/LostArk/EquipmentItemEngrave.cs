using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class EquipmentItemEngrave
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("lvl")]
        public string Level { get; set; } = string.Empty;

        [JsonProperty("val")]
        public string Value { get; set; } = string.Empty;
    }
}