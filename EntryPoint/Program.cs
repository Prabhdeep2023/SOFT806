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

            Repository repository = new Repository(@"Data Source=localhost\\SQLEXPRESS1;Initial Catalog=SOFT806;Integrated Security=True");

            Boolean isnewuser = IsNewUser();

            if (isnewuser)
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
                
                string? inputText1 = Console.ReadLine();

                if (inputText1 is not null && inputText1.ToLower() == "yes")
                {
                    return true;
                }
                else if (inputText1 is not null && inputText1.ToLower() == "no")
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
