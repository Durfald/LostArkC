using Newtonsoft.Json;

namespace LostArkAPI.Models.LostArk
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
        [JsonProperty("sea-adventure")]
        public int SeaAdventures { get; set; }

        /// <summary>
        /// Листья Мирового древа
        /// </summary>
        [JsonProperty("world-tree")]
        public int WorldTree { get; set; }

        /// <summary>
        /// Знаки Искателя
        /// </summary>
        [JsonProperty("ignea-token")]
        public int IgneaToken { get; set; }

        /// <summary>
        /// Звёзды Альбиона
        /// </summary>
        [JsonProperty("orpheus-star")]
        public int OrpheusStar { get; set; }

        /// <summary>
        /// Шкатулка памяти
        /// </summary>
        [JsonProperty("orgel")]
        public int Orgel { get; set; }
    }
}
