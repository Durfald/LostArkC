using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class SkillJewelry
    {
        [JsonProperty("desc")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("grade")]
        public int Grade { get; set; }

        [JsonProperty("icon")]
        public string UrlIcon { get; set; } = string.Empty;

        [JsonProperty("lvl")]
        public int Level { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
    }
}