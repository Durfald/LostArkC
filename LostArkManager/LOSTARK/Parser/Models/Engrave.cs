using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class Engrave
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("lvl")]
        public string Level { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

    }
}