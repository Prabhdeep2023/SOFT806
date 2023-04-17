﻿using Database;

namespace Login
{
    public class LoginPage
    {
        Func<String> _getpassword;
        IRepository _r;

        public LoginPage(Func<String> getPassword, IRepository Repository)
        {
            _getpassword = getPassword;
            _r = Repository;
        }

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
                password = _getpassword();
                Console.WriteLine();

            } while (String.IsNullOrEmpty(password));

            User user = new User();
            user.Login = login;
            user.Password = password;

            if (_r.Login(user))
                result = true;

            return result;
        }
    }
}
