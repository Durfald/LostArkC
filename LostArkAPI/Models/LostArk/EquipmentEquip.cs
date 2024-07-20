using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class EquipmentEquip : EquipmentItem
    {
        [JsonProperty("lvl")]
        public int Level { get; set; }

        [JsonProperty("quality")]
        public int Quality { get; set; }

        [JsonProperty("tier")]
        public int Tier { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; } = string.Empty;

        [JsonProperty("gs")]
        public int GearScore { get; set; }

        [JsonProperty("set")]
        public string Set { get; set; } = string.Empty;

        [JsonProperty("base_effects")]
        public List<EquipEffect> BaseEffects { get; set; } = new();

        [JsonProperty("additional_effects")]
        public List<EquipEffect> AdditionalEffects { get; set; } = new();
    }
}
