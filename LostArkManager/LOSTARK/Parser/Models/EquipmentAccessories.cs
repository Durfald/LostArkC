using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class EquipmentAccessories : EquipmentItem
    {
        [JsonConstructor]
        public EquipmentAccessories(string slot, string name, string type, string icon, int grade,
            string rank, int quality, int tier, List<EquipEffect> base_effects,
            List<EquipEffect> additional_effects, List<EquipmentItemEngrave> engraves) : base(slot, name, type, icon, grade)
        {
            Rank = rank.RemoveHTMLCode();
            Quality = quality;
            Tier = tier;
            BaseEffects = base_effects;
            AdditionalEffects = additional_effects;
            Engraves = engraves;
        }

        [JsonProperty("rank")]
        public string Rank { get; set; } = string.Empty;

        [JsonProperty("quality")]
        public int Quality { get; set; }

        [JsonProperty("tier")]
        public int Tier { get; set; }

        [JsonProperty("base_effects")]
        public List<EquipEffect> BaseEffects { get; set; } = new();

        [JsonProperty("additional_effects")]
        public List<EquipEffect> AdditionalEffects { get; set; } = new();

        [JsonProperty("engraves")]
        public List<EquipmentItemEngrave> Engraves { get; set; } = new();
    }
}
