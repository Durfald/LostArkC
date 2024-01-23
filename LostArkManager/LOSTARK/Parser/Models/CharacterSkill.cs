using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class CharacterSkill
    {
        [JsonProperty("icon")]
        public string UrlIcon { get; set; } = string.Empty;

        [JsonProperty("tripodList")]
        public List<string> UrlTripodList { get; set; } = new();
    }
}