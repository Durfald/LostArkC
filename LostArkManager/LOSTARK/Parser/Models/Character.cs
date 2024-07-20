using LostArkManager.LOSTARK.Extensions;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class Character
    {
        [JsonProperty("class")]
        public int Class { get; set; }

        /// <summary>
        /// дата получения актуального гс-а
        /// </summary>
        [JsonProperty("date")]
        public int UnixDate { get; set; }

        //public DateTime date {
        //    get
        //    {
        //        return new DateTime().UnixTimeConvert(UnixDate);
        //    }
        //}

        /// <summary>
        /// дата обновления информации
        /// </summary>
        [JsonProperty("dateupd")]
        private int UnixDateUpdate { get; set; }

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

        [JsonProperty("collections")]
        public CollectionsCount Collections { get; set; } = new();
    }
}