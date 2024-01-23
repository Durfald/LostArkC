using Newtonsoft.Json;

namespace LostArkAPI.Models
{
    class EquipEffect
    {
        [JsonProperty("key")]
        public string Key { get; set; } = string.Empty;

        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("val")]
        public string Value { get; set; } = string.Empty;
    }
}
