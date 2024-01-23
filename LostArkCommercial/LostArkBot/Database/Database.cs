using LostArkCommercial.LostArkBot.Database.Models;
using LostArkCommercial.LostArkBot.Other;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LostArkCommercial.LostArkBot.Database
{
    public static class LADataBase
    {
        private static readonly string FileType = ".json";
        public static void Save<T>(T obj) where T : BaseModel
        {
            var type = obj.GetType();
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, type.Name)))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, type.Name));

            var filesLenght = (ulong)Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, type.Name)).LongLength;
            var NewFilePath = Path.Combine(Environment.CurrentDirectory, type.Name, $"{filesLenght}{FileType}");
            if (File.Exists(NewFilePath))
                return;
            File.WriteAllText(NewFilePath, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

        public static void Delete<T>(long id) where T : BaseModel
        {
            var type = typeof(T);
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, type.Name)))
                return;
            var FilePath = Path.Combine(Environment.CurrentDirectory, type.Name, $"{id}{FileType}");
            if (!File.Exists(FilePath))
                return;
            File.Delete(FilePath);
        }

        public static void Update<T>(T obj) where T : BaseModel
        {
            var type = typeof(T);
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, type.Name)))
                return;
            var FilePath = Path.Combine(Environment.CurrentDirectory, type.Name, $"{obj.id}{FileType}");
            if (!File.Exists(FilePath))
                return;
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

        public static T? Get<T>(long id) where T : BaseModel
        {
            var type = typeof(T);
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, type.Name)))
                return null;
            var FilePath = Path.Combine(Environment.CurrentDirectory, type.Name, $"{id}{FileType}");
            if (!File.Exists(FilePath))
                return null;
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(FilePath));
        }

        public static List<T> Get<T>() where T : BaseModel
        {
            List<T> values = new List<T>();
            var type = typeof(T);
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, type.Name)))
                return values;
            var files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, type.Name));
            foreach (var file in files)
                values.Add(JsonConvert.DeserializeObject<T>(File.ReadAllText(file)));
            return values;
        }

        public static bool Exist<T>(long id) where T : BaseModel
        {
            var q = Assembly.GetExecutingAssembly().Location;
            var type = typeof(T);
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, type.Name)))
                return false;
            var FilePath = Path.Combine(Environment.CurrentDirectory, type.Name, $"{id}{FileType}");
            if (!File.Exists(FilePath))
                return false;
            return true;
        }
    }
}
