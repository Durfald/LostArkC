using Newtonsoft.Json;

namespace LostArkAPI.Models
{
    class OldGearScore
    {
        [JsonProperty("date")]
        public int Date {  get; set; }

        [JsonProperty("gs")]
        public float GearScore { get; set; }
    }
}
