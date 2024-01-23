using LostArkAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LostArkAPI.Extensions
{
    class HTMLcodeConverter : JsonConverter<Dictionary<string, string>>
    {

        public override Dictionary<string, string>? ReadJson(JsonReader reader, Type objectType, Dictionary<string, string>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            Dictionary<string, string>? dictionary = jObject?.ToObject<Dictionary<string, string>>();
            dictionary = dictionary?.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.RemoveHTMLCode()
            );
            return dictionary;
        }

        public override void WriteJson(JsonWriter writer, Dictionary<string, string>? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    class CharacterSkillConverter : JsonConverter<Dictionary<string, CharacterSkill>>
    {
        public override Dictionary<string, CharacterSkill>? ReadJson(JsonReader reader, Type objectType, Dictionary<string, CharacterSkill>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return new Dictionary<string, CharacterSkill>();
            }
            else if (token.Type == JTokenType.Object)
            {
                return token.ToObject<Dictionary<string, CharacterSkill>>(serializer);
            }
            else
            {
                throw new JsonSerializationException($"Unexpected token type: {token.Type}");
            }
        }

        public override void WriteJson(JsonWriter writer, Dictionary<string, CharacterSkill>? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
