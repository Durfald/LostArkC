using Newtonsoft.Json;

namespace LostArkAPI.Models
{
    class CardSet
    {
        [JsonProperty("effects")]
        public List<CardSetEffect> Effects { get; set; } = new();

        [JsonProperty("items")]
        public List<int> Items { get; set; } = new();
    }
}
