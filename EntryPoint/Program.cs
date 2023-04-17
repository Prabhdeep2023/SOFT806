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
        /// <summary>
        /// This method is the entry point for the application to start operation.
        /// </summary>
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

        /// <summary>
        /// The method returns the result of answering the question "Are you a new user?".
        /// </summary>
        private static Boolean IsNewUser()
        {
            while (true)
            {
                Console.WriteLine("Are you a new user? (Yes/No)");
                
                string? inputText = Console.ReadLine();

                if (inputText is not null && inputText.ToLower().Trim() == "yes")
                {
                    return true;
                }
                else if (inputText is not null && inputText.ToLower().Trim() == "no")
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
