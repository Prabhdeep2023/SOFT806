using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public static class Password
    {
        public static string GetPassword()
        {
            var password = string.Empty;
            ConsoleKey consolekey;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                consolekey = keyInfo.Key;

                if (consolekey == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (consolekey != ConsoleKey.Enter);

            return password;
        }
    }
}