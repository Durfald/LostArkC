using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{/* 0-5 шмотки 1
  * 6-10 бижа 2
  * 11 фетр 3
  * 12 браслет 4
  * и 2 последние это гравы 5
  */
    public class EquipmentItem
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("slot")]
        public string Slot { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("icon")]
        public string UrlIcon { get; set; } = string.Empty;

        [JsonProperty("grade")]
        public int Grade { get; set; }

        public override string ToString()
        {
            return $"{Type}     {Name}";
        }
    }
}
