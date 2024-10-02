namespace LicenseGeneration.Iterfaces
{
    interface ILicenseKeyManager
    {
        const int keyParts = 4;
        const int keySymbols = 4;
        const string keySigns = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public string GenerateKey();
        public void ActivateKey(string licenseKey);
        public void CheckKey(string licenseKey);
        public void AddKey(string newKey);
    }
}
