namespace LicenseGeneration.Iterfaces
{
    interface ISaveManager
    {
        const string filePath = "license-keys.json";

        public void Save(List<string> list);

        public List<string>? Read();
    }
}
