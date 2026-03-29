using System;
using System.Text;

namespace lab5.task4
{
    internal abstract class ExamBase
    {
        protected string name;
        protected int score;

        public ExamBase(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public virtual void Show()
        {
            Console.WriteLine("Назва: " + name);
            Console.WriteLine("Оцінка: " + score);
        }
    }

    internal sealed partial class Test : ExamBase
    {
        private int questionsCount;

        public Test(string name, int score, int questionsCount)
            : base(name, score)
        {
            this.questionsCount = questionsCount;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Кількість питань: " + questionsCount);
            Console.WriteLine(new string('-', 40));
        }

        public void ShowDetails()
        {
            Console.WriteLine("=== Деталі тесту ===");
            Console.WriteLine("Назва: " + name);
            Console.WriteLine("Оцінка: " + score);
            Console.WriteLine("Питань: " + questionsCount);
            Console.WriteLine(new string('-', 40));
        }
    }

    internal partial class Exam : ExamBase
    {
        private string subject;
        private int duration;

        public Exam(string name, int score, string subject, int duration)
            : base(name, score)
        {
            this.subject = subject;
            this.duration = duration;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Предмет: " + subject);
            Console.WriteLine("Тривалість: " + duration + " хв.");
            Console.WriteLine(new string('-', 40));
        }
    }

    internal sealed partial class FinalExam : Exam
    {
        private bool isStateExam;

        public FinalExam(string name, int score, string subject, int duration, bool isStateExam)
            : base(name, score, subject, duration)
        {
            this.isStateExam = isStateExam;
        }

        public override void Show()
        {
            base.Show();
            if (isStateExam)
                Console.WriteLine("Тип: Державний випускний іспит");
            else
                Console.WriteLine("Тип: Випускний іспит");
            Console.WriteLine(new string('-', 40));
        }
    }

    internal sealed partial class Trial : ExamBase
    {
        private string trialType;

        public Trial(string name, int score, string trialType)
            : base(name, score)
        {
            this.trialType = trialType;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Тип випробування: " + trialType);
            Console.WriteLine(new string('-', 40));
        }
    }

    internal class task4
    {
        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Завдання 4: Частковий клас (partial) ===");
            Console.WriteLine();

            Console.WriteLine("1. Створення об'єкта Test (partial sealed):");
            Test test1 = new Test("Тест з ООП", 88, 25);
            Console.WriteLine();

            Console.WriteLine("2. Виклик методу Show() (з файлу 1):");
            test1.Show();
            Console.WriteLine();

            Console.WriteLine("3. Виклик методу ShowDetails() (з файлу 1):");
            test1.ShowDetails();
            Console.WriteLine();

            Console.WriteLine("4. Методи з файлу 2:");
            int count = test1.GetQuestionsCount();
            Console.WriteLine("Кількість питань: " + count);
            Console.WriteLine();

            test1.SetQuestionsCount(30);
            Console.WriteLine();

            Console.WriteLine("5. Перевірка після зміни:");
            test1.Show();
            Console.WriteLine();

            Console.WriteLine("6. Інші класи ієрархії:");
            Exam exam1 = new Exam("Іспит з C#", 95, "Програмування", 150);
            exam1.Show();

            FinalExam final1 = new FinalExam("Випускний іспит", 97, "Інформатика", 180, true);
            final1.Show();

            Trial trial1 = new Trial("Практичне випробування", 75, "Виконання проекту");
            trial1.Show();

            Console.WriteLine();
            Console.WriteLine("=== Демонстрація завершена ===");
        }
    }
}
