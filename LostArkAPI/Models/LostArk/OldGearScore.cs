using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class OldGearScore
    {
        [JsonProperty("date")]
        public int Date { get; set; }

        [JsonProperty("gs")]
        public float GearScore { get; set; }
    }
}
