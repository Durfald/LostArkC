using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class EquipmentEquip : EquipmentItem
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

        [JsonConstructor]
        public EquipmentEquip(string slot, string name, string type, string icon, int grade,
            List<EquipEffect> additional_effects, List<EquipEffect> base_effects,
            string set, int gs, int tier, int quality, int lvl, string rank) : base(slot, name, type, icon, grade)
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
