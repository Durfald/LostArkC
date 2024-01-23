using Newtonsoft.Json;

namespace LostArkAPI.Models
{
    class EquipmentEngrave : EquipmentItem
    {
        [JsonConstructor]
        public EquipmentEngrave(string slot, string name, string type, string icon, int grade,
            string engrave_lvl) : base(slot, name, type, icon, grade)
        {
            EngraveLevel = engrave_lvl;
        }

        [JsonProperty("engrave_lvl")]
        public string EngraveLevel { get; set; } = string.Empty;
    }
}
