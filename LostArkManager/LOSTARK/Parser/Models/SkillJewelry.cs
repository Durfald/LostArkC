using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class SkillJewelry
    {
        [JsonProperty("desc")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("grade")]
        public int Grade { get; set; }

        [JsonProperty("icon")]
        public string UrlIcon { get; set; } = String.Empty;

        [JsonProperty("lvl")]
        public string Level { get; set; } = String.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonConstructor]
        public SkillJewelry(string desc, int grade, string icon, string lvl, string type)
        {
            Description = desc.RemoveHTMLCode();
            Grade = grade;
            UrlIcon = icon;
            Level = lvl;
            Type = type;
        }
    }
}
