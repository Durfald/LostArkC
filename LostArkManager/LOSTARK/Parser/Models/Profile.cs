using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class Profile
    {
        [JsonProperty("another_profile")]
        public object? another_profile { get; set; }

        [JsonProperty("build")]
        public string Build { get; set; } = string.Empty;

        [JsonProperty("cards")]
        public List<Card> Cards { get; set; } = new();

        [JsonProperty("cards_set")]
        public List<CardSet> CardsSet { get; set; } = new();

        [JsonProperty("class")]
        public string Class { get; set; } = string.Empty;

        [JsonProperty("class_no")]
        public string ClassNo { get; set; } = string.Empty;

        [JsonProperty("dateupd")]
        public int UnixDateUpdate { get; set; }

        [JsonProperty("engrave")]
        public List<Engrave> Engraves { get; set; } = new();

        [JsonProperty("equip")]
        public Equip Equip { get; set; } = new();

        [JsonProperty("expedition")]
        public string Expedition { get; set; } = string.Empty;

        [JsonProperty("gs")]
        public float GearScore { get; set; }

        [JsonProperty("guild")]
        public string GuildName { get; set; } = string.Empty;

        [JsonProperty("lvl")]
        public string Level { get; set; } = string.Empty;

        [JsonProperty("memberNo")]
        public string MemberNo { get; set; } = string.Empty;

        [JsonProperty("nick")]
        public string Nickname { get; set; } = string.Empty;

        [JsonProperty("pcId")]
        public string PcId { get; set; } = string.Empty;

        [JsonProperty("point")]
        public string Point { get; set; } = string.Empty;

        [JsonProperty("point_all")]
        public string PointAll { get; set; } = string.Empty;

        [JsonProperty("pvp")]
        public string PVPRank { get; set; } = string.Empty;

        [JsonProperty("server")]
        public string ServerName { get; set; } = string.Empty;

        [JsonProperty("server_human")]
        public string ServerNameHuman { get; set; } = string.Empty;

        [JsonProperty("skill")]
        public List<EquipmentSkill> Skills { get; set; } = new();

        [JsonProperty("stats")]
        public Dictionary<string, string> Stats { get; set; } = new();

        [JsonProperty("stats_desc")]
        public Dictionary<string, string> StatsDescription { get; set; } = new();

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("worldNo")]
        public string WorldNo { get; set; } = string.Empty;
    }
}
