using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class OldGearScore
    {
        [JsonProperty("date")]
        public string Date {  get; set; } = string.Empty;

        [JsonProperty("gs")]
        public string GearScore { get; set; } = string.Empty;
    }
}
