using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class EquipmentAbilityStone : EquipmentItem
    {
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
