using LicenseGeneration.Iterfaces;
using LicenseGeneration.Enums;

namespace LicenseGeneration.Classes
{
    class UserChoice : IUserChoice
    {
        public string UserInput { get; set; }

        ILicenseKeyManager licenseKeyManager = new LicenseKeyManager();
        IConsoleManager consoleManager = new ConsoleManager();

        public void MakeChoice(string input)
        {
            int.TryParse(input, out int choice);

            switch ((MenuActions)choice)
            {
                case MenuActions.Generate:
                    consoleManager.WriteLine("Generating...");
                    consoleManager.WriteLine(licenseKeyManager.GenerateKey());
                    break;

                case MenuActions.Activate:
                    consoleManager.WriteLine("Activating:");
                    licenseKeyManager.ActivateKey(consoleManager.GetLine());
                    break;

                case MenuActions.Check:
                    consoleManager.WriteLine("Checking:");
                    licenseKeyManager.CheckKey(consoleManager.GetLine());
                    break;

                case MenuActions.admin:
                    consoleManager.WriteLine("Password:");
                    if (consoleManager.GetLine() == "1111")
                    {
                        licenseKeyManager.AddKey(consoleManager.GetLine());
                    }
                    else
                    {
                        consoleManager.WriteLine("Incorrect password!");
                    }
                    break;

                default:
                    consoleManager.WriteLine("Incorrect input!");
                    break;

            }
        }
    }
}
