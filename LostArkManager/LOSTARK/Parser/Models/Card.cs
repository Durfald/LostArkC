using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class Card
    {
        [JsonProperty("awake_count")]
        public int AwakeCount {  get; set; }

        [JsonProperty("awake_total")]
        public int AwakeTotal { get; set; }

        [JsonProperty("grade")]
        public int Grade { get; set; }

        [JsonProperty("icon")]
        public string UrlIcon { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonConstructor]
        public Card(string name, string icon, int grade, int awake_total, int awake_count)
        {
            Name = name.RemoveHTMLCode();
            UrlIcon = icon;
            Grade = grade;
            AwakeCount = awake_count;
            AwakeTotal = awake_total;
        }
    }
}