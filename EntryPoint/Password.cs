using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public static class Password
    {
        /// <summary>
        /// The method prompts a user to enter a password while hiding the value on screen.
        /// </summary>
        public static string GetPassword()
        {
            var password = string.Empty;
            ConsoleKey consoleKey;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                consoleKey = keyInfo.Key;

                if (consoleKey == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (consoleKey != ConsoleKey.Enter);

            return password;
        }
    }
}