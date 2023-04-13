using L = Login;
using R = Registration;
using M = MainForm;
using Registration;
using Database;
using System.Configuration;
using MainForm;

namespace EntryPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welocome to 'SOFT806 Continuous Integration and Continuous Deployment' course");

            Repository repository = new Repository(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);

            Boolean isNewUser = IsNewUser();

            if (isNewUser)
            {
                R.RegistrationPage registrationPage = new R.RegistrationPage(Password.GetPassword, repository);
                registrationPage.Register();
            }
            else
            {
                L.LoginPage loginPage = new L.LoginPage(Password.GetPassword, repository);
                Boolean successfulLogin = loginPage.SignIn(out String login);

                if (successfulLogin)
                {
                    MainPage mainPage = new MainPage();
                    mainPage.Open(login);
                }
            }
        }

        private static Boolean IsNewUser()
        {
            while (true)
            {
                Console.WriteLine("Are you a new user? (Yes/No)");

                string? inputText = Console.ReadLine();

                if (inputText is not null && inputText.ToLower() == "yes")
                {
                    return true;
                }
                else if (inputText is not null && inputText.ToLower() == "no")
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
