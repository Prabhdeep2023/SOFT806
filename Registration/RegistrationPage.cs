using Database;

namespace Registration
{
    public class RegistrationPage
    {
        Func<String> _getPassword;
        IRepository _rep;

        public RegistrationPage(Func<String> getPassword, IRepository Repository)
        {
            _getPassword = getPassword;
            _rep = Repository;
        }

        public void Register()
        {
            String? login;
            String password = String.Empty;
            String confirmpassword = String.Empty;

            Console.WriteLine();
            Console.WriteLine("Registration");

            do
            {
                Console.Write("Login: ");

                login = Console.ReadLine();

                if (String.IsNullOrEmpty(login))
                    continue;

                login = login.Trim();

                User? existingUser = _rep.getUserByLogin(login);
                if (existingUser is not null)
                {
                    Console.WriteLine(@$"{login} is already taken!");

                    login = String.Empty;
                }

            } while (String.IsNullOrEmpty(login));

            do
            {
                Console.Write("Password: ");
                password = _getPassword();
                Console.WriteLine();

                Console.Write("Confirm Password: ");
                confirmpassword = _getPassword();
                Console.WriteLine();
            } while (!(password == confirmpassword & !String.IsNullOrEmpty(password) & !String.IsNullOrEmpty(confirmpassword)));

            User user = new User();
            user.Login = login;
            user.Password = password;
            _rep.addUser(user);



        }
    }
}
