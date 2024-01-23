using LostArkManager.LOSTARK.Extensions;
using Newtonsoft.Json;

namespace LostArkManager.LOSTARK.Parser.Models
{
    class EquipmentSetEffect
    {
        [JsonProperty("text")]
        public string Text {  get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonConstructor]
        public EquipmentSetEffect(string title, string text)
        {
            Text = text.RemoveHTMLCode();
            Title = title.RemoveHTMLCode();
        }
    }
}
