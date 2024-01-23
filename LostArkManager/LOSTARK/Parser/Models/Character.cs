using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class Character
    {
        [JsonProperty("class")]
        public string Class { get; set; } = string.Empty;

        [JsonProperty("date")]
        public string UnixDate { get; set; } = string.Empty;

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
        public Dictionary<string, string> Rank { get; set; } = new();

        [JsonProperty("server")]
        public string Server { get; set; } = string.Empty;

        [JsonProperty("skills")]
        [JsonConverter(typeof(CharacterSkillConverter))]
        public Dictionary<string, CharacterSkill> Skills { get; set; } = new();
    }
}