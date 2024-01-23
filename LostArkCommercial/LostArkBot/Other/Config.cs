using Newtonsoft.Json;
using System.Reflection;

namespace LostArkCommercial.LostArkBot.Other
{
    public struct Config
    {
        [JsonProperty("Token")]
        public string Token { get;private set; }

        [JsonProperty("BlackListGuildID")]
        public ulong[] BlackListGuildID { get; private set; }

        [JsonProperty("Prefixes")]
        public string[] Prefixes { get; private set; }

        public static Config Load()
        {
            if (!File.Exists("config.json"))
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(new Config(), Formatting.Indented));
                Console.WriteLine("Please fill config.json");
                Console.ReadKey();
                Environment.Exit(0);
            }
            var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
            Type type = config.GetType();
            PropertyInfo[] properties = type.GetProperties();
            List<string> PropertyNames = new();
            foreach (PropertyInfo property in properties)
            {
                if (!IsDefault(property.GetValue(config, null))) continue;
                PropertyNames.Add(property.Name);
            }
            if(PropertyNames.Count>0)
            {
                foreach(var name in PropertyNames)
                    Console.WriteLine($"Please fill {name} in config.json");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return config;
        }

        static bool IsDefault<T>(T o)
        {
            if (o == null) // => ссылочный тип или nullable
                return true;
            if (Nullable.GetUnderlyingType(typeof(T)) != null) // nullable, не null
                return false;
            var type = o.GetType();
            if (type.IsClass)
                return false;
            else           // => тип-значение, есть конструктор по умолчанию
                return Activator.CreateInstance(type).Equals(o);
        }
    }
}
