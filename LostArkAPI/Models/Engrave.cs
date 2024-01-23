using Newtonsoft.Json;

namespace LostArkAPI.Models
{
    class Engrave
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("lvl")]
        public int Level { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

    }
}