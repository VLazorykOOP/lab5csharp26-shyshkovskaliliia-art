using System;
using System.Text;

namespace lab5.task4
{
    internal sealed partial class Test
    {
        public int GetQuestionsCount()
        {
            return questionsCount;
        }

        public void SetQuestionsCount(int count)
        {
            if (count > 0)
            {
                questionsCount = count;
                Console.WriteLine("Кількість питань оновлено: " + count);
            }
            else
            {
                Console.WriteLine("Помилка: кількість питань має бути > 0");
            }
        }
    }

    internal partial class Exam
    {
        public string GetSubject()
        {
            return subject;
        }

        public int GetDuration()
        {
            return duration;
        }
    }

    internal sealed partial class FinalExam
    {
        public bool IsState()
        {
            return isStateExam;
        }
    }

    internal sealed partial class Trial
    {
        public string GetTrialType()
        {
            return trialType;
        }
    }
}