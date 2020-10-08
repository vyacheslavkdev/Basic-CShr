/*
 * Вячеслав Индорил
 * Задача 1
    Создать программу, которая будет проверять корректность ввода логина. 
    Корректным логином будет строка от 2 до 10 символов, содержащая только 
    буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    а) без использования регулярных выражений;
    б) **с использованием регулярных выражений.
 */
using System;
using System.Text.RegularExpressions;

namespace Ex1
{
    class LoginValidator
    {
        static void Main(string[] args)
        {
            Console.Write("Веедите логин: ");
            string login = Console.ReadLine();
            
            Console.WriteLine("Перебор: " + (IsValidLogin(login) ? "Логин валиден" : "Логин не валиден"));
            Console.WriteLine("Регулярное выражение: " + (IsValidLoginByRegex(login) ? "Логин валиден" : "Логин не валиден"));
        }

        private static bool IsValidLoginByRegex(String s)
        {
            Regex myReg = new Regex(@"/[A-Za-z0-9]{2,8}/g");
            return myReg.IsMatch(s);
        }

        private static bool IsValidLogin(String s)
        {
            if (s.Length >= 2 && s.Length <= 10)
            {
                foreach (char c in s)
                {
                    if (!IsValidCharacter(c))
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        private static bool IsValidCharacter(char c)
        {
            int code = (int) c;
            return (code >= 48 && code <= 58) || (code >= 65 && code <= 91) || (code >= 97 && code <= 123);
        }
    }
}
