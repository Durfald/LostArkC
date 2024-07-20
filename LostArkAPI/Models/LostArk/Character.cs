using LostArkAPI.Models.Base;
using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
{
    public class Character : BaseModel
    {
        [JsonProperty("class")]
        public int Class { get; set; }

        [JsonProperty("date")]
        public int UnixDate { get; set; }

        [JsonProperty("dateupd")]
        public int UnixDateUpdate { get; set; }

        [JsonIgnore]
        public DateTime DateUpdate {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(UnixDateUpdate).ToLocalTime();
                return dateTime;
            }
        }

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
        public Dictionary<string, CharacterSkill> Skills { get; set; } = new();

        [JsonProperty("collections")]
        public CollectionsCount Collections { get; set; } = new();
    }
}