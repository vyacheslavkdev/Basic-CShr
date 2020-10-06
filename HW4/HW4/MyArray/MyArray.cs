using System;
using System.Collections.Generic;
using System.Linq;

namespace MyArrayNamespace
{
    public class MyArray
    {
        private int[] _array = null;

        public MyArray(int length, int initValue, int valueStep, bool random = false)
        {
            if (random)
            {
                InitRandom(length, initValue, valueStep);
            }
            else
            {
                InitArray(length, initValue, valueStep);
            }
        }

        public int[] Inverse()
        {
            int[] inverseArray = new int[ArrayLength];
            for (int i = 0; i < ArrayLength; i++)
            {
                inverseArray[i] = -_array[i];
            }

            return inverseArray;
        }

        public void Multi(int m)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                _array[i] *= m;
            }
        }

        public Dictionary<int, int> EntryFrequency()
        {
            Dictionary<int, int> res = new Dictionary<int, int>();

            foreach (int val in _array)
            {
                if (res.TryGetValue(val, out int outVal))
                {
                    res.Remove(val);
                    res.TryAdd(val, outVal + 1);
                }
                else
                {
                    res.TryAdd(val, 1);
                }
            }

            return res;
        }

        public void Show()
        {
            Show(_array);
        }

        public static void Show(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0 && i % 10 == 0)
                {
                    Console.WriteLine();
                }

                Console.Write("{0, 7}", array[i]);
            }

            Console.WriteLine("\n");
        }

        public static void ShowEntryFrequency(Dictionary<int, int> entryFrequency)
        {
            Console.WriteLine("Частота вхождения элементов в массив: ");
            int count = 0;
            foreach (var (key, value) in entryFrequency)
            {
                Console.Write($"[{key,5} : {value,2}] ");
                count++;

                if (count % 5 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public int Sum => _array.Sum();

        public int ArrayMax
        {
            get
            {
                int count = 0;
                int max = MaxElem;
                foreach (int val in _array)
                {
                    if (val == max)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public int MaxElem => _array.Max();

        private void InitArray(int length, int initValue, int valueStep)
        {
            _array = new int[length];
            _array[0] = initValue;
            for (int i = 1; i < length; i++)
            {
                _array[i] = _array[i - 1] + valueStep;
            }
        }

        private void InitRandom(int length, int initValue, int valueStep)
        {
            _array = new int[length];
            _array[0] = initValue;
            Random rnd = new Random();
            for (int i = 1; i < length; i++)
            {
                _array[i] = rnd.Next(initValue - valueStep, initValue + valueStep);
            }
        }

        private int ArrayLength => _array.Length;

        public static void Main()
        {
        }
    }
}