using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models
{
    class EquipmentSet
    {
        [JsonProperty("set_effects")]
        public List<EquipmentSetEffect> Effects { get; set; } = new();
        [JsonProperty("set_lvl")]
        public string Level { get; set; } = String.Empty;

        [JsonProperty("set_name")]
        public string SetName { get; set; } = String.Empty;

        [JsonConstructor]
        public EquipmentSet(string set_name, string set_lvl, List<EquipmentSetEffect> set_effects)
        {
            SetName = set_name.RemoveHTMLCode();
            Level = set_lvl;
            Effects = set_effects;
        }
    }
}
