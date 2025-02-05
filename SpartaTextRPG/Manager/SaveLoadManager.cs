
using Newtonsoft.Json;
using SpartaTextRPG;
using System.IO;
using System.Text.Json;

namespace SpartaTextRPG
{
    class SaveLoadManager
    {
        private static SaveLoadManager? m_instance = null;

        public static SaveLoadManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new SaveLoadManager();
                }
                return m_instance;
            }
        }

        public string filePath = Directory.GetCurrentDirectory() + ".json";

        public void SaveToJson<T>(T? data) where T : class
        {
            string path = Path.Combine(filePath,typeof(T).Name);

            //string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });

            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }

        public T? LoadFromJson<T>() where T : class
        {
            string path = Path.Combine(filePath,typeof(T).Name);

            if (!File.Exists(path))
            {
                Console.WriteLine("파일이 존재하지 않습니다.");
                return null;
            }

            string json = File.ReadAllText(path);
            //return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { IncludeFields = true });
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
