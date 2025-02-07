using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    abstract class Exam
    {
        public int Time { get; set; }
        public List<Question> Questions { get; set; }
        public string SubjectInfo { get; set; }

        public Exam(int time)
        {
            Time = time;
            Questions = new List<Question>();
        }
        public abstract void ShowExam();

        protected void PrintHeader(DateTime examEnd, string examType)
        {
            TimeSpan remaining = examEnd - DateTime.Now;
            if (remaining.TotalSeconds < 0)
                remaining = TimeSpan.Zero;

            Console.WriteLine(SubjectInfo);
            Console.WriteLine("Exam Type: " + examType);
            Console.WriteLine("Allocated Time: " + Time + " minutes");
            Console.WriteLine("Time Remaining: {0} minutes {1} seconds", remaining.Minutes, remaining.Seconds);
            Console.WriteLine(new string('-', 50));
        }
    }
}
