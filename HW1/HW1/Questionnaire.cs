/*
    Вячеслав Индорил

    1) Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
    В результате вся информация выводится в одну строчку:
        а) используя  склеивание;
	    б) используя форматированный вывод;
	    в) используя вывод со знаком $.

    2) Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) 
    по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
*/

using System;

namespace HW1
{
    class Questionnaire
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Поджалуйста заполните анкету.");

            Console.Write("Ваше имя: ");
            string name = Console.ReadLine();

            Console.Write("Ваша фамилия: ");
            string surname = Console.ReadLine();

            Console.Write("Ваш возраст: ");
            string age = Console.ReadLine();

            Console.Write("Ваш рост в сантиметрах: ");
            string height = Console.ReadLine();

            Console.Write("Ваш вес в килограммах: ");
            string weight = Console.ReadLine();

            Console.WriteLine("\nВаши данные: ");

            //Склеивание
            Console.WriteLine("Вас зовут " + name + " " + surname +
                ".\nВам " + age + " лет. Ваш рост " + height + "см и вес " + weight + "кг\n");

            //Форматирование
            Console.WriteLine(
                "Вас зовут {0} {1}. \nВам {2} лет. Ваш рост {3}см и вес {4}кг.\n",
                name, surname, age, height, weight);

            //Со знаком $
            Console.WriteLine($"Вас зовут {name} {surname}. " +
                $"\nВам {age} лет. Ваш рост {height}см и вес {weight}кг.\n");

            //ИМТ
            Console.WriteLine($"Индекс массы тела: {GetIMT(height, weight):F2}");

            Console.ReadKey();
        }

        private static double GetIMT(string h, string w) {
            double height = Convert.ToDouble(h) / 100;
            double weight = Convert.ToDouble(w);

            return weight / (height * height);
        }
    }
}
