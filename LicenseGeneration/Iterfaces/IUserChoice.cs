namespace LicenseGeneration.Iterfaces
{
    interface IUserChoice
    {
        string UserInput { get; set; }

        public void MakeChoice(string input);
    }
}
