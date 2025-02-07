namespace Exam_02
{
    class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, List<Answer> answers, int correctAnswerId)
            : base(header, body, mark)
        {
            AnswerList = answers;
            CorrectAnswerId = correctAnswerId;
        }
        public override void Display()
        {
            Console.WriteLine(Header + " (Mark: " + Mark + ")");
            Console.WriteLine(Body);
            for (int i = 0; i < AnswerList.Count; i++)
            {
                Console.WriteLine(AnswerList[i].AnswerId + ". " + AnswerList[i].AnswerText);
            }
        }
    }
}
