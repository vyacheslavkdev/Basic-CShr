/*
 * Вячеслав Индорил
 * Задача 5
    *а) Реализовать библиотеку с классом для работы с двумерным массивом.
        Реализовать конструктор, заполняющий массив случайными числами. Создать методы, 
        которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
        свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, 
        метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
    **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    **в) Обработать возможные исключительные ситуации при работе с файлами.
 */

using System;
using MyMatrixNamespace;

namespace Ex5
{
    class MyMatrixWork
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int rows = rnd.Next(3, 6);
            int cols = rnd.Next(5, 11);
            int initVal = rnd.Next(-10, 11);
            int valStep = rnd.Next(1, 11);
            Console.WriteLine($"Инициализация MyMatrix. " +
                              $"Количество строк = {rows}, Количество столбцов = {cols}, " +
                              $"Начальное значение = {initVal}, Шаг до +- {valStep}");
            
            MyMatrix myMatrix = new MyMatrix(rows, cols, initVal, valStep);
            myMatrix.Show();
            
            Console.WriteLine($"Сумма всех элементов массива = {myMatrix.ElementSum()}");
            Console.WriteLine($"Сумма всех элементов массива больше {valStep / 2} = {myMatrix.ElementSum(valStep / 2)}");
            Console.WriteLine($"Минимальный элемент массива = {myMatrix.MinElement}, " +
                              $"Максимальный элемент = {myMatrix.MaxElement}");
            int maxRowId = 0;
            int maxColId = 0;
            myMatrix.SetMaxElementId(ref maxRowId, ref maxColId);
            Console.WriteLine($"Порядковый номер максимального элемента массива = [{maxRowId}][{maxColId}]");

            Console.WriteLine("\nИнициализация MyMatrix из файла.");
            
            string fileName = "../../matrix.txt";
            MyMatrix myFileMatrix = new MyMatrix(fileName);
            myFileMatrix.Show();
        }
    }
}