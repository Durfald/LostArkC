using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkManager.LOSTARK.Parser.LA_Arsenal_Models
{
    public class Skill
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("level")]
        public byte Level { get; set; }

        [JsonProperty("selectedTripodTier")]
        public byte[] SelectedTripodTier { get; set; } = new byte[3];

        [JsonProperty("slotIcon")]
        public string UrlIcon { get; set; } = null!;

        [JsonProperty("tripodList")]
        public List<Tripod> Tripods { get; set; } = new();

        [JsonProperty("rune")]
        public Rune Rune {  get; set; }

        /// <summary>
        /// Пробужденный скилл (Ульта ли)
        /// </summary>
        [JsonProperty("awakening")]
        public bool isAwakening { get; set; }

        public Tripod[] SelectedTripods
        {
            get 
            {
                Tripod[] tripods = new Tripod[3];
                if (SelectedTripodTier[0] == 0)
                    tripods[0] = null;
                else
                    tripods[0] = Tripods[SelectedTripodTier[0] - 1]; 
                if (SelectedTripodTier[1] == 0)
                    tripods[1] = null;
                else
                    tripods[1] = Tripods[SelectedTripodTier[1] + 2];
                if (SelectedTripodTier[2] == 0)
                    tripods[2] = null;
                else
                    tripods[2] = Tripods[SelectedTripodTier[0] + 5];
                return tripods;
            }
        }

        //public Tripod? FirstSelectedTripode { 
        //    get 
        //    {
        //        if (SelectedTripodTier[0] == 0)
        //            return null;
        //        return this.Tripods[SelectedTripodTier[0]-1];
        //    }
        //}
        //public Tripod? SecondSelectedTripode
        //{
        //    get
        //    {
        //        if (SelectedTripodTier[1] == 0)
        //            return null;
        //        return this.Tripods[SelectedTripodTier[1] +2];
        //    }
        //}
        //public Tripod? ThirdSelectedTripode
        //{
        //    get
        //    {
        //        if (SelectedTripodTier[2] == 0)
        //            return null;
        //        return this.Tripods[SelectedTripodTier[0] + 5];
        //    }
        //}
    }
}
