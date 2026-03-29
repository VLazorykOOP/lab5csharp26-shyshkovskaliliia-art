using System;
using System.Text;

namespace lab5
{
    internal class task2
    {
        internal abstract class ExamBase
        {
            protected string name;
            protected int score;

            // Конструктор 1: без параметрів
            public ExamBase()
            {
                name = "Без назви";
                score = 0;
                Console.WriteLine("[ExamBase] Конструктор за замовчуванням");
            }

            // Конструктор 2: з параметрами
            public ExamBase(string name, int score)
            {
                this.name = name;
                this.score = score;
                Console.WriteLine("[ExamBase] Конструктор з параметрами: " + name);
            }

            // Конструктор 3: копіювальний
            public ExamBase(ExamBase other)
            {
                this.name = other.name;
                this.score = other.score;
                Console.WriteLine("[ExamBase] Копіювальний конструктор");
            }

            ~ExamBase()
            {
                Console.WriteLine("[~ExamBase] Деструктор: " + name);
            }

            public virtual void Show()
            {
                Console.WriteLine("Назва: " + name);
                Console.WriteLine("Оцінка: " + score);
            }
        }

        internal class Test : ExamBase
        {
            protected int questionsCount;

            public Test() : base()
            {
                questionsCount = 10;
                Console.WriteLine("[Test] Конструктор за замовчуванням");
            }

            public Test(string name, int score, int questionsCount) : base(name, score)
            {
                this.questionsCount = questionsCount;
                Console.WriteLine("[Test] Конструктор з параметрами, питань: " + questionsCount);
            }

            public Test(Test other) : base(other)
            {
                this.questionsCount = other.questionsCount;
                Console.WriteLine("[Test] Копіювальний конструктор");
            }

            ~Test()
            {
                Console.WriteLine("[~Test] Деструктор: " + name);
            }

            public override void Show()
            {
                base.Show();
                Console.WriteLine("Кількість питань: " + questionsCount);
                Console.WriteLine("----------------------------------------");
            }
        }

        internal class Exam : ExamBase
        {
            protected string subject;
            protected int duration;

            public Exam() : base()
            {
                subject = "Невідомий предмет";
                duration = 90;
                Console.WriteLine("[Exam] Конструктор за замовчуванням");
            }

            public Exam(string name, int score, string subject, int duration) : base(name, score)
            {
                this.subject = subject;
                this.duration = duration;
                Console.WriteLine("[Exam] Конструктор з параметрами, предмет: " + subject);
            }

            public Exam(Exam other) : base(other)
            {
                this.subject = other.subject;
                this.duration = other.duration;
                Console.WriteLine("[Exam] Копіювальний конструктор");
            }

            ~Exam()
            {
                Console.WriteLine("[~Exam] Деструктор: " + name);
            }

            public override void Show()
            {
                base.Show();
                Console.WriteLine("Предмет: " + subject);
                Console.WriteLine("Тривалість: " + duration + " хв.");
                Console.WriteLine("----------------------------------------");
            }
        }

        internal class FinalExam : Exam
        {
            protected bool isStateExam;

            public FinalExam() : base()
            {
                isStateExam = false;
                Console.WriteLine("[FinalExam] Конструктор за замовчуванням");
            }

            public FinalExam(string name, int score, string subject, int duration, bool isState)
                : base(name, score, subject, duration)
            {
                this.isStateExam = isState;
                Console.WriteLine("[FinalExam] Конструктор з параметрами, державний: " + isState);
            }

            public FinalExam(FinalExam other) : base(other)
            {
                this.isStateExam = other.isStateExam;
                Console.WriteLine("[FinalExam] Копіювальний конструктор");
            }

            ~FinalExam()
            {
                Console.WriteLine("[~FinalExam] Деструктор: " + name);
            }

            public override void Show()
            {
                base.Show();
                if (isStateExam)
                    Console.WriteLine("Тип: Державний випускний");
                else
                    Console.WriteLine("Тип: Випускний");
            }
        }

        internal class Trial : ExamBase
        {
            protected string trialType;

            public Trial() : base()
            {
                trialType = "Стандартне";
                Console.WriteLine("[Trial] Конструктор за замовчуванням");
            }

            public Trial(string name, int score, string trialType) : base(name, score)
            {
                this.trialType = trialType;
                Console.WriteLine("[Trial] Конструктор з параметрами, тип: " + trialType);
            }

            public Trial(Trial other) : base(other)
            {
                this.trialType = other.trialType;
                Console.WriteLine("[Trial] Копіювальний конструктор");
            }

            ~Trial()
            {
                Console.WriteLine("[~Trial] Деструктор: " + name);
            }

            public override void Show()
            {
                base.Show();
                Console.WriteLine("Тип випробування: " + trialType);
                Console.WriteLine("----------------------------------------");
            }
        }

        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Лабораторна робота №5");
            Console.WriteLine("Завдання 2: Конструктори та деструктори");
            Console.WriteLine("Варіант 2.7: Тест, іспит, випускний іспит, випробування");
            Console.WriteLine();

            Console.WriteLine("=== Частина 1: Створення об'єктів (конструктори) ===");
            Console.WriteLine();

            Console.WriteLine("1. Створення Test: ");
            Test t1 = new Test("Тест з ООП", 85, 30);
            Console.WriteLine();

            Console.WriteLine("2. Створення Exam: ");
            Exam e1 = new Exam("Іспит з C#", 92, "Програмування", 120);
            Console.WriteLine();

            Console.WriteLine("3. Створення FinalExam: ");
            FinalExam f1 = new FinalExam("Випускний іспит", 98, "Інформатика", 180, true);
            Console.WriteLine();

            Console.WriteLine("4. Створення Trial: ");
            Trial tr1 = new Trial("Практичне випробування", 78, "Виконання проєкту");
            Console.WriteLine();

            Console.WriteLine("=== Частина 2: Копіювальні конструктори ===");
            Console.WriteLine();
            Console.WriteLine("Копіювання Test: ");
            Test t2 = new Test(t1);
            Console.WriteLine();

            Console.WriteLine("=== Частина 3: Виведення даних (метод Show) ===");
            Console.WriteLine();
            t1.Show();
            e1.Show();
            f1.Show();
            tr1.Show();

            Console.WriteLine("=== Частина 4: Виклик деструкторів ===");
            Console.WriteLine("(об'єкти знищуються при виході з області видимості)");
            Console.WriteLine();

            t1 = null;
            e1 = null;
            f1 = null;
            tr1 = null;
            t2 = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine();
            Console.WriteLine("=== Роботу завершено ===");
        }
    }
}