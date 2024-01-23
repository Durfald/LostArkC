using LostArkManager.LOSTARK.Parser.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LostArkManager.LOSTARK.Extensions
{
    class CharacterSkillConverter : JsonConverter<Dictionary<string, CharacterSkill>>
    {
#pragma warning disable CS8765 // Допустимость значений NULL для типа параметра не соответствует переопределенному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public override Dictionary<string, CharacterSkill> ReadJson(JsonReader reader, Type objectType, Dictionary<string, CharacterSkill> existingValue, bool hasExistingValue, JsonSerializer serializer)
#pragma warning restore CS8765 // Допустимость значений NULL для типа параметра не соответствует переопределенному элементу (возможно, из-за атрибутов допустимости значений NULL).
        {
            //JObject jsonObject = JObject.Load(reader);
            //Dictionary<string, CharacterSkill> result = new Dictionary<string, CharacterSkill>();

            //foreach (JProperty property in jsonObject.Properties())
            //{
            //    if (property.Value.Type == JTokenType.Array)
            //    {
            //        // Обработка пустого массива
            //        result.Add(property.Name, new CharacterSkill());
            //    }
            //    else
            //    {
            //        // Обработка объекта
            //        CharacterSkill skill = property.Value.ToObject<CharacterSkill>(serializer);
            //        result.Add(property.Name, skill);
            //    }
            //}

            //return result;


            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                //В случае массива, возвращаем пустой словарь
                return new Dictionary<string, CharacterSkill>();
            }
            else if (token.Type == JTokenType.Object)
            {
                //В случае объекта, десериализуем словарь
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
                return token.ToObject<Dictionary<string, CharacterSkill>>(serializer);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            }
            else
            {
                throw new JsonSerializationException($"Unexpected token type: {token.Type}");
            }
        }

#pragma warning disable CS8765 // Допустимость значений NULL для типа параметра не соответствует переопределенному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public override void WriteJson(JsonWriter writer, Dictionary<string, CharacterSkill> value, JsonSerializer serializer)
#pragma warning restore CS8765 // Допустимость значений NULL для типа параметра не соответствует переопределенному элементу (возможно, из-за атрибутов допустимости значений NULL).
        {
            throw new NotImplementedException();
        }
    }
}
