/*
 * Вячеслав Индорил
 
 3) *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
     Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
     Написать программу, демонстрирующую все разработанные элементы класса.
    * Добавить свойства типа int для доступа к числителю и знаменателю;
    * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
    ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
       ArgumentException("Знаменатель не может быть равен 0");
    *** Добавить упрощение дробей.
 */

using System;

namespace Ex3
{
    class Fraction
    {
        private int _numerator;
        private int _denominator;

        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        public static Fraction Sum(Fraction a, Fraction b)
        {
            if (a.Denominator == b.Denominator)
            {
                return new Fraction(a.Numerator + b.Numerator, a.Denominator);
            }

            return Simplification(new Fraction(
                a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                a.Denominator * b.Denominator));
        }

        public static Fraction Diff(Fraction a, Fraction b)
        {
            if (a.Denominator == b.Denominator)
            {
                return new Fraction(a.Numerator - b.Numerator, a.Denominator);
            }

            return Simplification(new Fraction(
                a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                a.Denominator * b.Denominator));
        }

        public static Fraction Mult(Fraction a, Fraction b)
        {
            return Simplification(new Fraction(
                a.Numerator * b.Numerator,
                a.Denominator * b.Denominator));
        }

        public static Fraction Div(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new AggregateException("Ошибка деления на 0.");
            }

            return Mult(a, new Fraction(b.Denominator, b.Numerator));
        }

        public static Fraction Simplification(Fraction f)
        {
            Fraction simple = f;
            for (int i = 10; i > 1; i--)
            {
                if (f.Numerator % i == 0 && f.Denominator % i == 0)
                {
                    simple = Simplification(new Fraction(f.Numerator / i, f.Denominator / i));
                    break;
                }
            }

            return simple;
        }

        public static string ToString(Fraction f)
        {
            if (f.Numerator == f.Denominator)
            {
                return f.Numerator.ToString();
            }

            if (f.Numerator / f.Denominator > 0)
            {
                int res = f.Numerator / f.Denominator;
                int div = f.Numerator % f.Denominator;
                return $"{res}+{div}/{f.Denominator}";
            }

            return $"{f.Numerator}/{f.Denominator}";
        }

        public int Numerator
        {
            get => _numerator;
            set => _numerator = value;
        }

        public int Denominator
        {
            get => _denominator;
            set => _denominator = value;
        }

        public double Decimal => (double) Numerator / Denominator;

    }

    class FractionsCalc
    {
        private static Fraction f1 = null;
        private static Fraction f2 = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор дробей");

            Console.Write("Выберите операцию: \"+\", \"-\", \"*\", \"/\", \"S(Упрощение)\" , \"D(Демонстрация)\" : ");
            string operation = Console.ReadLine().ToLower();

            if (operation != "+" && operation != "-" && operation != "*" 
                && operation != "/" && operation != "s" && operation != "d")
            {
                Console.WriteLine("Сначала нужно выбрать операцию.");
            }


            switch (operation)
            {
                case "d":
                    Demo();
                    break;
                case "s":
                    Console.WriteLine("Введите первую дробь для упрощения в формате \"a/b\"");
                    f1 = ReadFraction(Console.ReadLine());
                    Console.WriteLine($"Результат упрощения: {Fraction.Simplification(f1)}");
                    break;
                case "+":
                    Input();
                    Fraction sum = Fraction.Sum(f1, f2);
                    Console.WriteLine($"Сумма дробей: {Fraction.ToString(sum)}. В десятичном виде: {sum.Decimal:F}");
                    break;
                case "-":
                    Input();
                    Fraction diff = Fraction.Diff(f1, f2);
                    Console.WriteLine($"Разность дробей: {Fraction.ToString(diff)}. В десятичном виде: {diff.Decimal:F}");
                    break;
                case "*":
                    Input();
                    Fraction mult = Fraction.Mult(f1, f2);
                    Console.WriteLine($"Произведение дробей: {Fraction.ToString(mult)}. В десятичном виде: {mult.Decimal:F}");
                    break;
                case "/":
                    Input();
                    Fraction div = Fraction.Div(f1, f2);
                    Console.WriteLine($"Частное дробей: {Fraction.ToString(div)}. В десятичном виде: {div.Decimal:F}");
                    break;
            }
        }

        private static void Input()
        {
            Console.WriteLine("Введите первую дробь в формате \"a/b\"");
            f1 = ReadFraction(Console.ReadLine());

            Console.WriteLine("Введите вторую дробь в формате \"a/b\"");
            f2 = ReadFraction(Console.ReadLine());
        }
        
        private static void Demo()
        {
            Input();
            
            Fraction sum = Fraction.Sum(f1, f2);
            Console.WriteLine($"Сумма дробей: {Fraction.ToString(sum)}. В десятичном виде: {sum.Decimal:F}");
            
            Fraction diff = Fraction.Diff(f1, f2);
            Console.WriteLine($"Разность дробей: {Fraction.ToString(diff)}. В десятичном виде: {diff.Decimal:F}");
            
            Fraction mult = Fraction.Mult(f1, f2);
            Console.WriteLine($"Произведение дробей: {Fraction.ToString(mult)}. В десятичном виде: {mult.Decimal:F}");
            
            Fraction div = Fraction.Div(f1, f2);
            Console.WriteLine($"Частное дробей: {Fraction.ToString(div)}. В десятичном виде: {div.Decimal:F}");
        }


        private static Fraction ReadFraction(string input)
        {
            string[] split = input.Split("/");
            if (split.Length < 2)
            {
                throw new ArgumentException($"Ошибка ввода. {input}");
            }

            if (int.TryParse(split[0], out var numerator)
                && int.TryParse(split[1], out var denominator))
            {
                if (denominator == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }

                return new Fraction(numerator, denominator);
            }

            throw new ArgumentException($"Ошибка ввода. {input}");
        }
    }
}