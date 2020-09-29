using System;
using System.Collections.Generic;

namespace MySupport
{
    public class Support
    {
        public static void Main(string[] args)
        {
        }

        public static void WriteNumbers(List<double> numbers)
        {
            string text = "";

            for (int i = 0; i < numbers.Count; i++)
            {
                text += numbers[i].ToString() + " ";
            }

            Console.WriteLine(text);
        }

        public static double ReadNumber(string input) {
            return ReadNumbers(input)[0];
        }

        public static List<double> ReadNumbers(string input)
        {
            List<double> result = new List<double>();
            double parseRes = 0;

            string[] splitNumbers = input.Replace(".", ",").Split(" ");

            for (int i = 0; i < splitNumbers.Length; i++)
            {
                if (double.TryParse(splitNumbers[i], out parseRes))
                {
                    result.Add(parseRes);
                }
            }

            return result;
        }
    }
}
