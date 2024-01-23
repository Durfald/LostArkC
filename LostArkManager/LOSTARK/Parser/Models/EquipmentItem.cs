using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{/* 0-5 шмотки 1
  * 6-10 бижа 2
  * 11 фетр 3
  * 12 браслет 4
  * и 2 последние это гравы 5
  */
    class EquipmentItem
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

        [JsonConstructor]
        public EquipmentItem(string slot, string name, string type, string icon, int grade)
        {
            Name = name.RemoveHTMLCode();
            Slot = slot;
            Type = type;
            UrlIcon = icon;
            Grade = grade;
        }
    }
}
