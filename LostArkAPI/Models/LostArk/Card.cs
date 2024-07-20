using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class Card
    {
        [JsonProperty("awake_count")]
        public int AwakeCount { get; set; }

        [JsonProperty("awake_total")]
        public int AwakeTotal { get; set; }

        [JsonProperty("grade")]
        public int Grade { get; set; }

        [JsonProperty("icon")]
        public string UrlIcon { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
    }
}