/*
 * Вячеслав Индорил
 * Задача 3
    а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив 
    определенного размера и заполняющий массив числами от начального значения с заданным шагом. 
    Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, 
    возвращающий новый массив с измененными знаками у всех элементов массива 
    (старый массив, остается без изменений),  метод Multi, умножающий каждый элемент массива на 
    определённое число, свойство MaxCount, возвращающее количество максимальных элементов. 
    б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
    е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
 */

using System;
using System.Collections.Generic;
using MyArrayNamespace;

namespace Ex3
{
    class MyArrayWork
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int length = rnd.Next(10, 20);
            int initVal = rnd.Next(-10, 10);
            int valStep = rnd.Next(1, 10);
            Console.WriteLine($"Инициализация MyArray. Длинна = {length}, " +
                              $"Начальное значение = {initVal}, Шаг = {valStep}");

            MyArray myArray = new MyArray(length, initVal, valStep);
            myArray.Show();

            Console.WriteLine($"Сумма элементов массива = {myArray.Sum}\n");

            Console.WriteLine("Инвертированный массив: ");
            MyArray.Show(myArray.Inverse());

            int multi = rnd.Next(-99, 99);
            Console.WriteLine($"Умножаем все элементы массива на {multi}. Наш массив:");
            myArray.Multi(multi);
            myArray.Show();

            Console.WriteLine($"Инициализация MyArray. Длинна = {length}, " +
                              $"Начальное значение элемента = {initVal}, Шаг +- {valStep}");

            MyArray myRandomArray = new MyArray(length, initVal, valStep, true);
            myRandomArray.Show();

            Console.WriteLine($"Максимальный элементы {myRandomArray.MaxElem}. " +
                              $"Встречается {myRandomArray.ArrayMax} раз.\n");

            Dictionary<int, int> entryFrequency = myRandomArray.EntryFrequency();
            MyArray.ShowEntryFrequency(entryFrequency);
        }
    }
}