using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class EquipmentBracelet : EquipmentItem
    {
        [JsonProperty("rank")]
        public string Rank { get; set; } = string.Empty;

        [JsonProperty("quality")]
        public int Quality { get; set; }

        [JsonProperty("bracelet_effect")]
        public List<EquipEffect> BraceletEffects { get; set; } = new();
    }
}