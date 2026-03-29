using System;

namespace lab5
{
    internal class task3
    {
        internal abstract class Function : IComparable
        {
            protected string name;

            public Function(string name)
            {
                this.name = name;
                Console.WriteLine("[Function] Конструктор: {0}", name);
            }

            public abstract double Calculate(double x);
            public abstract void Show();

            public virtual int CompareTo(object obj)
            {
                if (obj == null)
                {
                    return 1;
                }

                Function other = obj as Function;
                if (other != null)
                {
                    double thisValue = this.Calculate(1.0);
                    double otherValue = other.Calculate(1.0);

                    if (thisValue > otherValue)
                    {
                        return 1;
                    }
                    else if (thisValue < otherValue)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    throw new ArgumentException("Об'єкт не є функцією");
                }
            }

            ~Function()
            {
                Console.WriteLine("[~Function] Деструктор: {0}", name);
            }
        }

        internal class Line : Function
        {
            protected double a;
            protected double b;

            public Line(double a, double b)
                : base("Лінійна функція")
            {
                this.a = a;
                this.b = b;
                Console.WriteLine("[Line] Конструктор: y = {0}x + {1}", a, b);
            }

            public override double Calculate(double x)
            {
                return a * x + b;
            }

            public override void Show()
            {
                Console.WriteLine("Функція: {0}", name);
                Console.WriteLine("Формула: y = {0}x + {1}", a, b);
                Console.WriteLine("----------------------------------------");
            }
        }

        internal class Quadratic : Function
        {
            protected double a;
            protected double b;
            protected double c;

            public Quadratic(double a, double b, double c)
                : base("Квадратична функція")
            {
                this.a = a;
                this.b = b;
                this.c = c;
                Console.WriteLine("[Quadratic] Конструктор: y = {0}x² + {1}x + {2}", a, b, c);
            }

            public override double Calculate(double x)
            {
                return a * x * x + b * x + c;
            }

            public override void Show()
            {
                Console.WriteLine("Функція: {0}", name);
                Console.WriteLine("Формула: y = {0}x² + {1}x + {2}", a, b, c);
            }
        }

        internal class Hyperbola : Function
        {
            protected double k;

            public Hyperbola(double k)
                : base("Гіпербола")
            {
                this.k = k;
                Console.WriteLine("[Hyperbola] Конструктор: y = {0}/x", k);
            }

            public override double Calculate(double x)
            {
                if (x == 0)
                {
                    Console.WriteLine("[Помилка] Ділення на нуль!");
                    return double.NaN;
                }
                return k / x;
            }

            public override void Show()
            {
                Console.WriteLine("Функція: {0}", name);
                Console.WriteLine("Формула: y = {0}/x", k);
                Console.WriteLine("----------------------------------------");
            }
        }

        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Лабораторна робота №5");
            Console.WriteLine("Завдання 3: Абстрактні класи та функції");
            Console.WriteLine("Варіант 3.2: Function, Line, Quadratic, Hyperbola");

            Console.WriteLine("Частина 1: Створення масиву функцій");
            Console.WriteLine();

            Function[] functions = new Function[5];

            functions[0] = new Line(2, 3);
            functions[1] = new Line(-1, 5);
            functions[2] = new Quadratic(1, -2, 1);
            functions[3] = new Quadratic(2, 0, -3);
            functions[4] = new Hyperbola(10);

            Console.WriteLine();
            Console.WriteLine("Створено масив з {0} функцій", functions.Length);
            Console.WriteLine();

            Console.WriteLine("Частина 2: Інформація про функції");
            Console.WriteLine();

            for (int i = 0; i < functions.Length; i++)
            {
                functions[i].Show();
            }

            Console.WriteLine("Частина 3: Обчислення значень у точці x");
            Console.WriteLine();

            double x = 2.0;
            Console.WriteLine("Точка обчислення: x = {0}", x);
            Console.WriteLine();

            for (int i = 0; i < functions.Length; i++)
            {
                Console.WriteLine("[Функція {0}]", i + 1);
                functions[i].Show();
                double y = functions[i].Calculate(x);

                if (double.IsNaN(y))
                {
                    Console.WriteLine("Результат: невизначено (x = {0})", x);
                }
                else
                {
                    Console.WriteLine("Результат: y = {0:F2} при x = {1}", y, x);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Частина 4: Порівняння функцій (IComparable)");
            Console.WriteLine();

            Console.WriteLine("Порівняння функцій за значенням у точці x = 1:");
            Console.WriteLine();

            for (int i = 0; i < functions.Length; i++)
            {
                for (int j = i + 1; j < functions.Length; j++)
                {
                    int result = functions[i].CompareTo(functions[j]);
                    string comparison = "";

                    if (result > 0)
                    {
                        comparison = ">";
                    }
                    else if (result < 0)
                    {
                        comparison = "<";
                    }
                    else
                    {
                        comparison = "=";
                    }

                    Console.WriteLine("Функція {0} {1} Функція {2}",
                        i + 1, comparison, j + 1);
                }
            }

            Console.WriteLine();

            Console.WriteLine("Частина 5: Сортування масиву функцій");
            Console.WriteLine();

            Console.WriteLine("Сортування масиву за зростанням значення у точці x = 1:");
            Console.WriteLine();

            Array.Sort(functions);

            for (int i = 0; i < functions.Length; i++)
            {
                double value = functions[i].Calculate(1.0);
                Console.WriteLine("Позиція {0}: {1} (y(1) = {2:F2})",
                    i + 1, functions[i].GetType().Name, value);
            }

            Console.WriteLine();

            Console.WriteLine("Частина 6: Обчислення у точці x = 0");
            Console.WriteLine("(демонстрація обробки ділення на нуль для гіперболи)");
            Console.WriteLine();

            x = 0.0;
            Console.WriteLine("Точка обчислення: x = {0}", x);
            Console.WriteLine();

            for (int i = 0; i < functions.Length; i++)
            {
                double y = functions[i].Calculate(x);
                if (double.IsNaN(y))
                {
                    Console.WriteLine("{0}: невизначено", functions[i].GetType().Name);
                }
                else
                {
                    Console.WriteLine("{0}: y = {1:F2}", functions[i].GetType().Name, y);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Частина 7: Виклик деструкторів");
            Console.WriteLine();

            functions = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine();
            Console.WriteLine("Роботу завершено");
        }
    }
}