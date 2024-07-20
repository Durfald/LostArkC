using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class EquipmentSet
    {
        [JsonProperty("set_effects")]
        public List<EquipmentSetEffect> Effects { get; set; } = new();
        [JsonProperty("set_lvl")]
        public string Level { get; set; } = string.Empty;

        [JsonProperty("set_name")]
        public string SetName { get; set; } = string.Empty;
    }
}
