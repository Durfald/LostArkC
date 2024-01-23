using Newtonsoft.Json;
namespace LostArkManager.LOSTARK.Parser.Models
{
    class Equip
    {
        [JsonProperty("list")]
        public Dictionary<string, EquipmentItem> EquipmentList { get; set; } = new();

        [JsonProperty("sets")]
        public Dictionary<string, EquipmentSet> EquipmentSets { get; set; } = new();
    }
}
