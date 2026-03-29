using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    internal class task1
    {
        internal abstract class ExamBase : IComparable
        {
            protected string name;
            protected int score;

            public ExamBase(string name, int score)
            {
                this.name = name;
                this.score = score;
            }

            public int CompareTo(object obj)
            {
                ExamBase temp = (ExamBase)obj;
                if (this.score > temp.score) return 1;
                if (this.score < temp.score) return -1;
                return 0;
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
        }

        internal class Exam : ExamBase
        {
            protected string subject;
            protected int duration;

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

        internal class FinalExam : Exam
        {
            protected bool isStateExam;

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

        internal class Trial : ExamBase
        {
            protected string trialType;

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

        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Демонстрація ієрархії класів (Завдання 1.7) ===");
            Console.WriteLine();

            Test test1 = new Test("Тест з ООП", 88, 25);
            Test test2 = new Test("Тест з Алгоритмів", 70, 15);

            Exam exam1 = new Exam("Іспит з C#", 95, "Програмування", 150);
            Exam exam2 = new Exam("Іспит з Математики", 60, "Вища математика", 120);

            FinalExam final1 = new FinalExam("Випускний іспит", 97, "Інформатика", 180, true);
            FinalExam final2 = new FinalExam("Випускний іспит", 85, "Фізика", 180, false);

            Trial trial1 = new Trial("Практичне випробування", 75, "Виконання проекту");
            Trial trial2 = new Trial("Спробний іспит", 50, "Співбесіда");

            ExamBase[] assessments = new ExamBase[8];
            assessments[0] = test1;
            assessments[1] = test2;
            assessments[2] = exam1;
            assessments[3] = exam2;
            assessments[4] = final1;
            assessments[5] = final2;
            assessments[6] = trial1;
            assessments[7] = trial2;

            Array.Sort(assessments);

            Console.WriteLine("=== Відсортовано за оцінкою (зростання) ===");
            Console.WriteLine();

            for (int i = 0; i < assessments.Length; i++)
            {
                assessments[i].Show();
            }

            Console.WriteLine("Демонстрація завершена.");
        }
    }
}
