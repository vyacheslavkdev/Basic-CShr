/*
 * Вячеслав Индорил
 * Задача 1
    С помощью рефлексии выведите все свойства структуры DateTime
 */

using System;
using System.Reflection;

namespace Ex1
{
    class Reflex
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime();

            Type type = dateTime.GetType();

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                Console.WriteLine($"{propertyInfo.Name}: {propertyInfo.GetValue(dateTime, null)}");
            }
        }
    }
}