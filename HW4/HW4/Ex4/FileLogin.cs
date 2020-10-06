/*
 * Вячеслав Индорил
 * Задание 4
    Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. 
    Создайте структуру Account, содержащую Login и Password.
 */

using System;
using System.IO;

namespace Ex4
{
    class Account
    {
        private string _login = null;
        private string _password = null;

        public Account(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public string Login
        {
            get => _login;
            set => _login = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var inputAccount = (Account) obj;
            return Login.Equals(inputAccount.Login) && Password.Equals(inputAccount.Password);
        }
    }

    class FileLogin
    {
        static void Main(string[] args)
        {
            Account root = new Account("root", "GeekBrains");

            Account userAccount = ReadAccount("../../account.txt");

            Console.WriteLine(root.Equals(userAccount) ? "Вы успешно авторизовались." : "Доступ запрещён.");
        }

        private static Account ReadAccount(string fileName)
        {
            try
            {
                string[] userData = new string[2];
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    for (int i = 0; i < 2; i++)
                    {
                        userData[i] = streamReader.ReadLine();
                    }
                }

                return new Account(userData[0], userData[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось прочитать файл авторизации!");
                Console.WriteLine(e);
                return null;
            }
        }
    }
}