using LostArkAPI.Models.Base;
using Newtonsoft.Json;
using System.Reflection;

namespace LostArkAPI.DataBase
{
    public static class DataBaseManager
    {
        private static readonly string FileType = ".json";

        /// <summary>
        /// Save object and if file exist dont update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void Save<T>(T obj) where T : BaseModel
        {
            var type = obj.GetType();
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, type.Name)))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, type.Name));

            var files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, type.Name));
            var NewFilePath = Path.Combine(Environment.CurrentDirectory, type.Name, $"{files.Count()}{FileType}");
            if (File.Exists(NewFilePath))
                return;
            File.WriteAllText(NewFilePath, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

        /// <summary>
        /// Remove file by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
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

        /// <summary>
        /// Update file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
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

        /// <summary>
        /// return object by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// return all object by T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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

        /// <summary>
        /// return exist file by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
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
