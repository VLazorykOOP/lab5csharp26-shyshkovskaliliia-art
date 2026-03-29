#nullable disable
using System;
using lab5.task4;

namespace lab5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine("           ЛАБОРАТОРНА РОБОТА №5");
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("Оберіть завдання для виконання:");
                Console.WriteLine();
                Console.WriteLine("  1. Завдання 1: Ієрархія класів");
                Console.WriteLine("  2. Завдання 2: Конструктори та деструктори");
                Console.WriteLine("  3. Завдання 3: Абстрактні класи та функції");
                Console.WriteLine("  4. Завдання 4: Часткові класи (partial)");
                Console.WriteLine();
                Console.WriteLine("  0. Вихід з програми");
                Console.WriteLine();
                Console.WriteLine("───────────────────────────────────────────────────────");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Запуск Завдання 1...\n");
                        task1.Run();
                        WaitForEnter();
                        break;

                    case "2":
                        Console.WriteLine("Запуск Завдання 2...\n");
                        task2.Run();
                        WaitForEnter();
                        break;

                    case "3":
                        Console.WriteLine("Запуск Завдання 3...\n");
                        task3.Run();
                        WaitForEnter();
                        break;

                    case "4":
                        Console.WriteLine("Запуск Завдання 4...\n");
                        global::lab5.task4.task4.Run(); WaitForEnter();
                        break;

                    case "0":
                        Console.WriteLine("Вихід з програми...");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір! Натисніть Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void WaitForEnter()
        {
            Console.WriteLine();
            Console.WriteLine("Натисніть Enter для повернення в меню...");
            Console.ReadLine();
        }
    }
}