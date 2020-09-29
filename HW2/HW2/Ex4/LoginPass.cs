/*
 * Вячеслав Индорил
 
 4)Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
     На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
     Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
     программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками
 */

using System;

namespace Ex4
{
    class LoginPass
    {
        private const string Login = "root";
        private const string Password = "GeekBrains";
        private const int MaxTryCount = 3;

        static void Main(string[] args)
        {
            int loginTry = 0;
            bool isLogin = false;
            Console.WriteLine("Добро пожаловать.");
            do
            {
                Console.Write("Введите логин: ");
                string inputLogin = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string inputPassword = Console.ReadLine();

                isLogin = IsUser(inputLogin, inputPassword);

                if (!isLogin)
                {
                    loginTry++;
                    Console.WriteLine("Неправильный логин или пароль.");
                }
            } while (!isLogin && loginTry < MaxTryCount);

            if (isLogin)
            {
                Console.WriteLine("Вы успешно авториловались.");
            }
            else
            {
                Console.WriteLine("Доступ запрещен.");
            }
        }

        private static bool IsUser(string inputLogin, string inputPassword)
        {
            return Login.Equals(inputLogin) && Password.Equals(inputPassword);
        }
    }
}