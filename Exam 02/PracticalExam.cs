namespace Exam_02
{
    class PracticalExam : Exam
    {
        public PracticalExam(int time) : base(time) { }
        public override void ShowExam()
        {
            DateTime examStart = DateTime.Now;
            DateTime examEnd = examStart.AddMinutes(Time);

            List<int> userAnswers = new List<int>();
            int totalMarks = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                totalMarks += Questions[i].Mark;
                Console.Clear();
                PrintHeader(examEnd, "Practical Exam");
                Console.WriteLine("Question " + (i + 1) + ":");
                Questions[i].Display();
                Console.Write("Your answer: ");
                int answer;
                bool ansCheck;
                do
                {
                    Console.Write("Your answer: ");
                    ansCheck = int.TryParse(Console.ReadLine(), out answer);

                } while (!ansCheck);
                userAnswers.Add(answer);
            }


            int score = 0;
            for (int i = 0; i < Questions.Count; i++)
            {
                if (userAnswers[i] == Questions[i].CorrectAnswerId)
                    score += Questions[i].Mark;
            }

            Console.Clear();
            TimeSpan elapsed = DateTime.Now - examStart;
            Console.WriteLine("Final Score: " + score + "/" + totalMarks);
            Console.WriteLine("Time Taken: " + elapsed.TotalSeconds + " seconds");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("----- Exam Summary -----");
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine("\nQuestion " + (i + 1) + ": " + Questions[i].Body);
                Console.WriteLine("Options:");
                foreach (Answer ans in Questions[i].AnswerList)
                {
                    Console.WriteLine(ans.AnswerId + ". " + ans.AnswerText);
                }
                Console.WriteLine("Your Answer: " + userAnswers[i]);
                Console.WriteLine("Correct Answer: " + Helper.GetAnswerText(Questions[i].AnswerList, Questions[i].CorrectAnswerId));
            }
        }
    }
}
