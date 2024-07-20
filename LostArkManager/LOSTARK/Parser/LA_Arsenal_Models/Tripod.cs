using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkManager.LOSTARK.Parser.LA_Arsenal_Models
{
    public class Tripod
    {
        [JsonProperty("featureLevel")]
        public byte Level { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        [JsonProperty("slotIcon")]
        public string UrlIcon { get; set; } = null!;

        /// <summary>
        /// Какой по счету он идет в тире
        /// </summary>
        [JsonProperty("slot")]
        public byte Slot { get; set; }

        /// <summary>
        /// Какой тир у трипода. Всего их 3
        /// </summary>
        [JsonProperty("level")]
        public byte Layer { get; set; }

        [JsonConstructor]
        public Tripod(byte featureLevel, string name, string description, string slotIcon, byte slot, byte level)
        {
            this.Level = featureLevel;
            this.Name = name;
            this.Description = description;
            this.Slot = slot;
            this.UrlIcon = slotIcon;
            this.Layer = level;
        }
    }
}
