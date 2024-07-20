using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class EquipmentEngrave : EquipmentItem
    {
        [JsonProperty("engrave_lvl")]
        public string EngraveLevel { get; set; } = string.Empty;
    }
}
