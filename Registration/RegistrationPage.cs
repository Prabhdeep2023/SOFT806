using Database;

namespace Registration
{
    public class RegistrationPage
    {
        Func<String> _getPassword;
        IRepository _repository;

        /// <summary>
        /// It is a constructor for this class.
        /// </summary>
        public RegistrationPage(Func<String> getPassword, IRepository Repository)
        {
            _getPassword = getPassword;
            _repository = Repository;
        }

        /// <summary>
        /// The method prompts a new user to register.
        /// </summary>
        public void Register()
        {
            String? login;
            String password = String.Empty;
            String confirmPassword = String.Empty;

            Console.WriteLine();
            Console.WriteLine("Registration");

            do
            {
                Console.Write("Login: ");

                login = Console.ReadLine();

                if (String.IsNullOrEmpty(login))
                    continue;

                login = login.Trim();

                User? existingUser = _repository.GetUserByLogin(login);
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
                confirmPassword = _getPassword();
                Console.WriteLine();
            } while (!(password == confirmPassword & !String.IsNullOrEmpty(password)));

            User user = new User();
            user.Login = login;
            user.Password = password;
            _repository.AddUser(user);



        }
    }
}
