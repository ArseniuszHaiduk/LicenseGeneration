using LicenseGeneration.Iterfaces;
using System.IO;
using Newtonsoft.Json;

namespace LicenseGeneration.Classes
{
    class SaveManager : ISaveManager
    {
        const string filePath = "license-keys.json";

        public void Save(List<string> list)
        {
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(list));
            }
            else
            {
                var newFile = File.Create(filePath);
                newFile.Close();
                File.WriteAllText(filePath, JsonConvert.SerializeObject(list));
            }
        }

        public List<string>? Read()
        {
            if (File.Exists(filePath))
            {
                 return JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(filePath));                              
            }
            else
            {
                return null;
            }
        }
    }
}
