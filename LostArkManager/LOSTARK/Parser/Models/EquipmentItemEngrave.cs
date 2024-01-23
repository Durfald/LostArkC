using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class EquipmentItemEngrave
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("lvl")]
        public string Level { get; set; } = string.Empty;

        [JsonProperty("val")]
        public string Value { get; set; } = string.Empty;

        [JsonConstructor]
        public EquipmentItemEngrave(string val, string lvl, string id)
        {
            Level = lvl;
            Value = val.RemoveHTMLCode();
            Id = id;
        }
    }
}