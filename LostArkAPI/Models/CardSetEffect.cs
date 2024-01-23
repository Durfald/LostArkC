using Newtonsoft.Json;

namespace LostArkAPI.Models
{
    class CardSetEffect
    {
        [JsonProperty("desc")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;
    }
}
