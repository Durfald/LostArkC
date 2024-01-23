using LostArkAPI.Extensions;
using Newtonsoft.Json;

namespace LostArkAPI.Models
{
    class Character
    {
        [JsonProperty("class")]
        public int Class { get; set; }

        [JsonProperty("date")]
        public int UnixDate { get; set; }

        [JsonProperty("dateupd")]
        public int UnixDateUpdate { get; set; }

        [JsonProperty("gs")]
        public float GearScore { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; } = string.Empty;

        [JsonProperty("old")]
        public List<OldGearScore> OldGS { get; set; } = new();

        [JsonProperty("profile")]
        public Profile Profile { get; set; } = new();

        [JsonProperty("rank")]
        public Dictionary<string, int> Rank { get; set; } = new();

        [JsonProperty("server")]
        public string Server { get; set; } = string.Empty;

        [JsonProperty("skills")]
        [JsonConverter(typeof(CharacterSkillConverter))]
        public Dictionary<string, CharacterSkill> Skills { get; set; } = new();

        
    }
}