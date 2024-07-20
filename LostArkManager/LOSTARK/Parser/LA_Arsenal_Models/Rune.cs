using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkManager.LOSTARK.Parser.LA_Arsenal_Models
{
    public class Rune
    {

        [JsonProperty("icon")]
        public string UrlIcon { get; set; } = null!;

        [JsonProperty("grade")]
        public Grade Grade { get; set; }

        public string Name { get; set; } = null!;

        public string Effect { get; set; } = null!;

        public string Drop { get; set; } = null!;

        [JsonConstructor]
        public Rune(string icon, int grade, string tooltip)
        {
            this.UrlIcon = icon;
            this.Grade = (Grade)grade;
            var Jobject = JObject.Parse(tooltip);
            this.Name = Jobject["Element_000"]["value"].Value<string>().RemoveHTMLCode();
            this.Effect = Jobject["Element_002"]["value"]["Element_001"].Value<string>().RemoveHTMLCode();
            this.Drop = Jobject["Element_004"]["value"].Value<string>().RemoveHTMLCode();
        }
    }
}
