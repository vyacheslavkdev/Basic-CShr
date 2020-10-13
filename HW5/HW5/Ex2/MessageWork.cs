/*
 * Вячеслав Индорил
 * Задача 2
    Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
    а) Вывести только те слова сообщения,  которые содержат не более n букв.
    б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    в) Найти самое длинное слово сообщения.
    г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается 
    массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива 
    входит в этот текст. Здесь требуется использовать класс Dictionary.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex2
{
    class MessageWork
    {
        public static void Main()
        {
            string text =
                "Как составляется такой шаблон? Для этого используются " +
                "специальные символы, метасимволы и классы (наборы) символов. " +
                "Регулярное выражение - это простая строка и любые символы в этой строке, " +
                "которые не являются специальными (), считаются обычными символами.\n";
            Console.WriteLine(text);

            Random rnd = new Random();
            int n = rnd.Next(6, 10);
            Console.WriteLine($"Слова содержащие не более {n} букв:");
            Message.NSymbolsWords(text, n);

            char symbol = GetRandomSymbol();
            Console.WriteLine($"Сообщение без слов заканчивающихся на \"{symbol}\":");
            Message.DeleteWordsEndsOn(text, symbol);

            Console.WriteLine($"\nСамое длинное слово в тексте: \"{Message.LongestWord(text)}\"");

            Console.WriteLine($"\nСамые длинные (+-1 символ) слова в тексте: {Message.LongestWords(text)}\n");

            string[] words = new[] {"шаблон", "символы", "и"};
            Message.WordsFrequency(words, text, true);
        }

        private static char GetRandomSymbol()
        {
            string symbols = "яыие";
            Random rnd = new Random();
            return symbols[rnd.Next(0, symbols.Length)];
        }
    }

    static class Message
    {
        public static void NSymbolsWords(String text, int symbolsCount)
        {
            string pattern = @"\b\w{1," + symbolsCount + "}\\b";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Console.Write($"{match.Value} ");
            }

            Console.WriteLine("\n");
        }

        public static void DeleteWordsEndsOn(String text, char symbol)
        {
            string pattern = @"\b\w*" + symbol + "\\b";
            Regex regex = new Regex(pattern);
            string deleteWords = regex.Replace(text, "");

            pattern = @"\s+";
            regex = new Regex(pattern);
            string deleteWhitespaces = regex.Replace(deleteWords, " ");

            Console.WriteLine(deleteWhitespaces);
        }

        public static string LongestWord(string text)
        {
            string longestWord = "";
            foreach (Match match in SplitText(text))
            {
                if (match.Value.Length > longestWord.Length)
                {
                    longestWord = match.Value;
                }
            }

            return longestWord;
        }

        public static string LongestWords(string text)
        {
            int longestWordLength = LongestWord(text).Length;
            StringBuilder sb = new StringBuilder();

            foreach (Match match in SplitText(text))
            {
                if (match.Value.Length + 1 >= longestWordLength)
                {
                    sb.Append("\"");
                    sb.Append(match.Value);
                    sb.Append("\" ");
                }
            }

            return sb.ToString();
        }

        public static Dictionary<string, int> WordsFrequency(string[] words, string text, bool show = false)
        {
            Dictionary<string, int> frequency = new Dictionary<string, int>();

            MatchCollection splitText = SplitText(text);

            foreach (string word in words)
            {
                foreach (Match match in splitText)
                {
                    if (match.Value.Equals(word))
                    {
                        if (!frequency.TryAdd(word, 1))
                        {
                            frequency[word]++;
                        }
                    }
                }
            }

            if (show)
            {
                Console.WriteLine("Частотный массив: ");
                foreach (string key in frequency.Keys)
                {
                    Console.WriteLine($"{key,-10} : {frequency[key]}");
                }
            }

            return frequency;
        }

        private static MatchCollection SplitText(String text)
        {
            string pattern = @"\b\w+\b";
            Regex regex = new Regex(pattern);

            return regex.Matches(text);
        }
    }
}