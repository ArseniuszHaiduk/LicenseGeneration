using LicenseGeneration.Iterfaces;

namespace LicenseGeneration.Classes
{
    class ConsoleManager : IConsoleManager
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string GetLine()
        {
            while (true)
            {
                string? userInput = Console.ReadLine();

                if (userInput != null)
                {
                    return userInput;
                }
            }
        }
    }
}
