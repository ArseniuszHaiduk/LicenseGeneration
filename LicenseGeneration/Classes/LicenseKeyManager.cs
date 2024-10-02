using LicenseGeneration.Data_Classes;
using LicenseGeneration.Iterfaces;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Nodes;

namespace LicenseGeneration.Classes
{
    class LicenseKeyManager : ILicenseKeyManager
    {
        const int keyParts = 4;
        const int keySymbols = 4;
        const string keySigns = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        Random random = new Random();

        IConsoleManager consoleManager = new ConsoleManager();
        ISaveManager saveManager = new SaveManager();
        LicenseKeysStorage licenseKeysStorage = new LicenseKeysStorage();


        public string GenerateKey()
        {
            var stringBuilder = new StringBuilder();

            for (int p = 0; p < keyParts; p++)
            {
                for (int s = 0; s < keySymbols; s++)
                {
                    stringBuilder.Append(keySigns[random.Next(0, 61)]);
                }
                if (p != keyParts - 1)
                {
                    stringBuilder.Append("-");
                }
            }
            return stringBuilder.ToString();
        }

        public void ActivateKey(string licenseKey)
        {
            bool keyFound = false;

            licenseKeysStorage.Keys = saveManager.Read();

            if (licenseKeysStorage.Keys is not null && licenseKeysStorage.Keys.Count != 0)
            {
                foreach (string key in licenseKeysStorage.Keys)
                {
                    if (key == licenseKey)
                    {
                        keyFound = true;

                        Console.WriteLine("Key is activated!");

                        licenseKeysStorage.Keys.Remove(key);
                        saveManager.Save(licenseKeysStorage.Keys);

                        break;
                    }
                }
                if (keyFound == false)
                {
                    Console.WriteLine("Key is not found");
                }
            }
            else
            {
                Console.WriteLine("File is missing or there are no keys available");
            }
        }

        public void CheckKey(string licenseKey)
        {
            bool keyFound = false;

            List<string>? keyList = saveManager.Read();

            if (keyList is not null && keyList.Count != 0)
            {
                foreach (string key in keyList)
                {
                    if (key == licenseKey)
                    {
                        keyFound = true;
                        Console.WriteLine("Key is free to use");
                        break;
                    }
                }
                if (keyFound == false)
                {
                    Console.WriteLine("Key is not found");
                }
            }
            else
            {
                Console.WriteLine("File is missing or there are no keys available");
            }
        }

        public void AddKey(string newKey)
        {
            licenseKeysStorage.Keys.Add(newKey);
            saveManager.Save(licenseKeysStorage.Keys);

            Console.WriteLine("Free keys:");

            foreach (string key in licenseKeysStorage.Keys)
            {
                Console.WriteLine(key);
            }
        }
    }
}
