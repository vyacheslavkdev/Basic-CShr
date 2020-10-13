/*
 * Вячеслав Индорил
 * Задача 3
    Переделать программу Пример использования коллекций для решения следующих задач:
    а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
    в) отсортировать список по возрасту студента;
    г) *отсортировать список по курсу и возрасту студента;
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Ex3
{
    class Student
    {
        public string LastName;
        public string FirstName;
        public string University;
        public string Faculty;
        public int Course;
        public string Department;
        public int Group;
        public string City;
        public int Age;

        public Student(
            string firstName, string lastName, string university, string faculty,
            string department, int course, int age, int group, string city)
        {
            LastName = lastName;
            FirstName = firstName;
            University = university;
            Faculty = faculty;
            Department = department;
            Course = course;
            Age = age;
            Group = group;
            City = city;
        }
    }

    class CollectionsWork
    {
        private const string FileName = "../../students.csv";
        private const int MinAge = 18;
        private const int MaxAge = 20;

        private static List<Student> _students = new List<Student>();

        private static List<Function> _functions = new List<Function>()
            {SetFifthCourseCount, SetSixthCourseCount, SetCourseFrequency};

        private static int _fifthCourseCount = 0;
        private static int _sixthCourseCount = 0;
        private static Dictionary<int, int> _courceFrequensy = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            GenerateStudentsData();
            ParseStudents(_functions);

            foreach (Student student in _students)
            {
                Console.WriteLine($"{student.LastName +" "+ student.FirstName, -20} {student.Course} курс {student.Age} лет");
            }
        }

        delegate void Function(Student student);

        private static void IncCountOfCourse(Student student, int course, ref int counter)
        {
            if (student.Course == course)
            {
                counter++;
            }
        }

        private static void SetFifthCourseCount(Student student)
        {
            IncCountOfCourse(student, 5, ref _fifthCourseCount);
        }

        private static void SetSixthCourseCount(Student student)
        {
            IncCountOfCourse(student, 6, ref _sixthCourseCount);
        }

        private static void SetCourseFrequency(Student student)
        {
            if (student.Age >= MinAge && student.Age <= MaxAge)
            {
                bool tryAdd = _courceFrequensy.TryAdd(student.Age, 1);
                if (!tryAdd)
                {
                    _courceFrequensy[student.Age]++;
                }
            }
        }

        private static int StudentsSort(Student student1, Student student2)
        {
            int res = 0;

            if (student1.Course != student2.Course)
            {
                res = student1.Course > student2.Course ? 1 : -1;
            }
            else if (student1.Age != student2.Age)
            {
                res = student1.Age > student2.Age ? 1 : -1;
            }

            return res;
        }

        private static void ParseStudents(List<Function> functions)
        {
            try
            {
                FileStream fileStream = new FileStream(FileName, FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);

                while (!streamReader.EndOfStream)
                {
                    string[] line = streamReader.ReadLine().Split(" ");
                    Student student = new Student(line[1], line[0],
                        line[2], line[3], line[4],
                        int.Parse(line[5]), int.Parse(line[8]),
                        int.Parse(line[6]), line[7]);
                    _students.Add(student);

                    foreach (Function function in functions)
                    {
                        function(student);
                    }
                }

                streamReader.Close();
                fileStream.Close();

                _students.Sort(new Comparison<Student>(StudentsSort));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void GenerateStudentsData()
        {
            try
            {
                FileStream fileStream = new FileStream(FileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                for (int i = 0; i < new Random().Next(20, 51); i++)
                {
                    streamWriter.WriteLine(GenerateStudent());
                }

                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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

            res += $" {_universities[rnd.Next(0, _universities.Length)]} ";
            res += $"Факультет_{rnd.Next(1, 5)} ";

            string suff = rnd.Next(0, 2) > 0 ? "О" : "Зао";
            res += $"{suff}чное ";

            int course = rnd.Next(1, 7);
            res += $"{course} ";

            res += $"{rnd.Next(1, 5)} ";

            res += $"{_cities[rnd.Next(0, _cities.Length)]} ";

            int age = rnd.Next(17, 21) + course;
            res += age;

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

        private static string[] _universities =
        {
            "MIT", "МГУ", "Hogwarts"
        };

        private static string[] _cities =
        {
            "Москва", "Санкт-Петербург", "Новосибирск", "Пенза", "Крыжополь"
        };
    }
}