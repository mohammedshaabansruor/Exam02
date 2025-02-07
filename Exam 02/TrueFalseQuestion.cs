namespace Exam_02
{
    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, int correctAnswerId)
            : base(header, body, mark)
        {
            AnswerList.Add(new Answer(1, "True"));
            AnswerList.Add(new Answer(2, "False"));
            CorrectAnswerId = correctAnswerId;
        }
        public override void Display()
        {
            Console.WriteLine(Header + " (Mark: " + Mark + ")");
            Console.WriteLine(Body);
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
    }
}
