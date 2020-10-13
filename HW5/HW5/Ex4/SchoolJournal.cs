/*
 * Вячеслав Индорил
 * Задача 4
     *Задача ЕГЭ.
    На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. 
    В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
    каждая из следующих N строк имеет следующий формат:
    <Фамилия> <Имя> <оценки>,
    где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем 
    из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
    <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
    Иванов Петр 4 5 3
    Требуется написать как можно более эффективную программу, которая будет выводить на экран 
    фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, 
    набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex4
{
    class SchoolJournal
    {
        private const int MinScore = 2;
        private const int MaxScore = 5;
        private const string FullNamePattern = @"\b\w{2,20}\b\s\b\w{2,15}\b";
        private const string ScoresPattern = @"(\s\d{1,2}){3}";

        private static Dictionary<string, double> _studentsMap = null;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rnd.Next(10, 101); i++)
            {
                string student = GenerateStudent();
                Console.WriteLine(student);
                sb.Append($"{student} ");
            }

            ParseStudents(sb.ToString());
            ShowWorstStudents();
        }

        static void ShowWorstStudents()
        {
            if (_studentsMap == null)
            {
                return;
            }

            double[] worstScores = GetWorstScore();
            foreach (double worstScore in worstScores)
            {
                Console.WriteLine($"\nУченики со средним балом {Math.Round(worstScore, 1)}:");
                foreach (string key in _studentsMap.Keys)
                {
                    _studentsMap.TryGetValue(key, out double score);
                    if (Math.Round(worstScore, 1) == Math.Round(score, 1))
                    {
                        Console.WriteLine(key);
                    }
                }
            }
        }

        static double[] GetWorstScore()
        {
            double[] worstScores = {MaxScore, MaxScore, MaxScore};
            foreach (double value in _studentsMap.Values)
            {
                if (value < worstScores[0])
                {
                    worstScores[2] = worstScores[1];
                    worstScores[1] = worstScores[0];
                    worstScores[0] = value;
                }

                if (value < worstScores[1] && value > worstScores[0])
                {
                    worstScores[2] = worstScores[1];
                    worstScores[1] = value;
                }

                if (value < worstScores[2] && value > worstScores[1])
                {
                    worstScores[2] = value;
                }
            }

            return worstScores;
        }

        static void ParseStudents(string studentsText)
        {
            string pattern = FullNamePattern + ScoresPattern;
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(studentsText);

            _studentsMap = new Dictionary<string, double>();
            foreach (Match match in matches)
            {
                _studentsMap.TryAdd(ParseFullName(match.Value),
                    Math.Round(ParseAverageScore(match.Value), 1));
            }
        }

        static string ParseFullName(string text)
        {
            Regex regex = new Regex(FullNamePattern);
            return regex.Match(text).Value;
        }

        static double ParseAverageScore(string text)
        {
            Regex regex = new Regex(ScoresPattern);
            string scores = regex.Match(text).Value;

            int res = 0;
            MatchCollection matches = new Regex(@"\d{1,2}").Matches(scores);
            foreach (Match match in matches)
            {
                int.TryParse(match.Value, out var score);
                res += score;
            }

            return (double) res / matches.Count;
        }

        static string GenerateStudent()
        {
            string res = "";
            Random rnd = new Random();

            switch (rnd.Next(0, 2))
            {
                case 0:
                    res = $"{_surnames[rnd.Next(0, _surnames.Length)]} {_male_names[rnd.Next(0, _male_names.Length)]}";
                    break;
                default:
                    res =
                        $"{_surnames[rnd.Next(0, _surnames.Length)]}a {_female_names[rnd.Next(0, _female_names.Length)]}";
                    break;
            }

            res += $" {rnd.Next(MinScore, MaxScore + 1)} " +
                   $"{rnd.Next(MinScore, MaxScore + 1)} " +
                   $"{rnd.Next(MinScore, MaxScore + 1)}";

            return res;
        }

        private static string[] _male_names =
        {
            "Александр", "Алексей", "Анатолий", "Андрей", "Антон", "Аркадий", "Арсений", "Артём", "Артур", "Борис",
            "Вадим", "Валентин", "Валерий", "Василий", "Виктор", "Виталий", "Владимир", "Владислав", "Вячеслав",
            "Георгий", "Глеб", "Григорий", "Даниил", "Денис", "Дмитрий", "Евгений", "Егор", "Иван", "Игорь", "Илья",
            "Кирилл", "Константин", "Лев", "Леонид", "Максим", "Марк", "Матвей", "Михаил", "Никита", "Николай",
            "Олег", "Павел", "Пётр", "Роман", "Руслан", "Сергей", "Степан", "Тимур", "Фёдор", "Юрий", "Ярослав"
        };

        private static string[] _female_names =
        {
            "Алиса", "Александра", "Алёна", "Алина", "Алла", "Анастасия", "Анжелика",
            "Анна", "Валентина", "Валерия", "Вера", "Вероника", "Виктория", "Галина", "Дарья", "Диана", "Ева", "Ева",
            "Евгения", "Екатерина", "Алёна", "Елена", "Елизавета", "Жанна", "Инна", "Ирина", "Карина", "Кристина",
            "Ксения", "Лариса", "Любовь", "Людмила", "Маргарита", "Марина", "Мария", "Мила", "Милана", "Надежда",
            "Наталья", "Ника", "Нина", "Оксана", "Олеся", "Ольга", "Полина", "Руслана", "Светлана", "София", "Софья",
            "Тамара", "Татьяна", "Юлия", "Яна"
        };

        private static string[] _surnames =
        {
            "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков",
            "Фёдоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Семёнов", "Егоров", "Павлов", "Козлов",
            "Степанов", "Николаев", "Орлов", "Андреев", "Макаров", "Никитин", "Захаров"
        };
    }
}