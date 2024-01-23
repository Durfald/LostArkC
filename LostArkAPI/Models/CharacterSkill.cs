using Newtonsoft.Json;

namespace LostArkAPI.Models
{
    class CharacterSkill
    {
        [JsonProperty("icon")]
        public string UrlIcon { get; set; } = string.Empty;

        [JsonProperty("tripodList")]
        public List<string> UrlTripodList { get; set; } = new();
    }
}