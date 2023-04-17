using Database;

namespace Login
{
    public class LoginPage
    {
        Func<String> _getPassword;
        IRepository _repository;

        /// <summary>
        /// It is a contructor for this class.
        /// </summary>
        public LoginPage(Func<String> getPassword, IRepository Repository)
        {
            _getPassword = getPassword;
            _repository = Repository;
        }

        /// <summary>
        /// The method prompts a user to sign in.
        /// </summary>
        public bool SignIn(out String login)
        {
            Boolean result = false;

            String password = String.Empty;

            Console.WriteLine();
            Console.WriteLine("Sign in");

            do
            {
                Console.Write("Login: ");

                login = Console.ReadLine()!;

                if (String.IsNullOrEmpty(login))
                    continue;

                login = login.Trim();
            } while (String.IsNullOrEmpty(login));

            do
            {
                Console.Write("Password: ");
                password = _getPassword();
                Console.WriteLine();

            } while (String.IsNullOrEmpty(password));

            User user = new User();
            user.Login = login;
            user.Password = password;

            if (_repository.Login(user))
                result = true;

            return result;
        }
    }
}
