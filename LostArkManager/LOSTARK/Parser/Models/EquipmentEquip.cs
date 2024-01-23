using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class EquipmentEquip : EquipmentItem
    {
        [JsonProperty("lvl")]
        public string Level { get; set; } = string.Empty;

        [JsonProperty("quality")]
        public int Quality { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; } = string.Empty;

        [JsonProperty("rank")]
        public string Rank { get; set; } = string.Empty;

        [JsonProperty("gs")]
        public string GearScore { get; set; } = string.Empty;

        [JsonProperty("set")]
        public string Set { get; set; } = string.Empty;

        [JsonProperty("base_effects")]
        public List<EquipEffect> BaseEffects { get; set; } = new();

        [JsonProperty("additional_effects")]
        public List<EquipEffect> AdditionalEffects { get; set; } = new();

        [JsonConstructor]
        public EquipmentEquip(string slot, string name, string type, string icon, int grade,
            List<EquipEffect> additional_effects, List<EquipEffect> base_effects, string set, string gs, string tier, int quality, string lvl,string rank) : base(slot, name, type, icon, grade)
        {
            AdditionalEffects = additional_effects;
            BaseEffects = base_effects;
            Set = set;
            GearScore = gs;
            Tier = tier;
            Quality = quality;
            Level = lvl;
            Rank = rank.RemoveHTMLCode();
        }
    }
}
