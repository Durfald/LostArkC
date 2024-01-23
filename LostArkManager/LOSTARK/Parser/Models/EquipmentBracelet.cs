using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class EquipmentBracelet : EquipmentItem
    {
        [JsonConstructor]
        public EquipmentBracelet(string slot, string name, string type, string icon, int grade,
            string rank, int quality, List<EquipEffect> bracelet_effect) : base(slot, name, type, icon, grade)
        {
            Rank = rank.RemoveHTMLCode();
            Quality = quality;
            BraceletEffects = bracelet_effect;
        }

        [JsonProperty("rank")]
        public string Rank { get; set; } = string.Empty;

        [JsonProperty("quality")]
        public int Quality { get; set; }

        [JsonProperty("bracelet_effect")]
        public List<EquipEffect> BraceletEffects { get; set; } = new();
    }
}