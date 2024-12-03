using LicenseGeneration.Classes;
using LicenseGeneration.Iterfaces;

namespace LicenseGeneration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConsoleManager consoleManager = new ConsoleManager();
            IUserChoice userChoice = new UserChoice();
            string text = "hello";
            text = "hi";
            Console.WriteLine(text);

            consoleManager.WriteLine("CODE ACTIVATION SYSTEM \n 1)Generate License Key \n 2)Activate License Key \n 3)Check License Key \n 4)admin \n 5)Exit");

            while (true)
            {
                consoleManager.WriteLine("Choose action:");
                var userInput = consoleManager.GetLine();

                if (userInput == "5")
                {
                    break;
                }

                userChoice.MakeChoice(userInput);
            }
        }
    }
}
