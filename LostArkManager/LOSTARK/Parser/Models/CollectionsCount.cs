using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    public class CollectionsCount
    {
        /// <summary>
        /// Сердца великанов
        /// </summary>
        [JsonProperty("heart")]
        public int Heart { get; set; }

        /// <summary>
        /// Души островов
        /// </summary>
        [JsonProperty("island")]
        public int Island { get; set; }

        /// <summary>
        /// Семена мококо
        /// </summary>
        [JsonProperty("mococo")]
        public int Mococo { get; set; }

        /// <summary>
        /// Шедевры живописи
        /// </summary>
        [JsonProperty("masterpiece")]
        public int Masterpiece { get; set; }

        /// <summary>
        /// Морские приключения
        /// </summary>
        [JsonProperty("sea_adventure")]
        public int SeaAdventures { get; set; }

        /// <summary>
        /// Листья Мирового древа
        /// </summary>
        [JsonProperty("world_tree")]
        public int WorldTree { get; set; }

        /// <summary>
        /// Знаки Искателя
        /// </summary>
        [JsonProperty("ignea_token")]
        public int IgneaToken { get; set; }

        /// <summary>
        /// Звёзды Альбиона
        /// </summary>
        [JsonProperty("orpheus_star")]
        public int OrpheusStar { get; set; }

        /// <summary>
        /// Шкатулка памяти
        /// </summary>
        [JsonProperty("orgel")]
        public int Orgel { get; set; }
    }
}
