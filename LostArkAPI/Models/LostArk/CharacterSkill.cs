using LostArkAPI.Models.Base;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class CharacterSkill : BaseModel
    {
        [JsonProperty("icon")]
        public string UrlIcon { get; set; } = string.Empty;

        [JsonProperty("tripodList")]
        public List<string> UrlTripodList { get; set; } = new();
    }
}