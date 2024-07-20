using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class EquipmentSkill
    {
        [JsonProperty("dataItem")]
        public string DataItem { get; set; } = string.Empty;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("jew")]
        public List<string> Jew { get; set; } = new();

        [JsonProperty("jews")]
        public List<SkillJewelry> Jewelries { get; set; } = new();

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("rune")]
        public string Rune { get; set; } = string.Empty;

        [JsonProperty("runeGrade")]
        public int? RuneGrade { get; set; }
        [JsonProperty("runeId")]
        public string RuneId { get; set; } = string.Empty;
        [JsonProperty("selectedTripodTier")]
        public List<int> SelectedTripodTier { get; set; } = new();

        [JsonProperty("tripodLvl")]
        public List<int> TripodLevel { get; set; } = new();
    }
}
