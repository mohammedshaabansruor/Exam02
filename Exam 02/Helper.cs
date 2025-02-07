namespace Exam_02
{
    internal class Helper
    {
        public static string GetAnswerText(List<Answer> answers, int answerId)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].AnswerId == answerId)
                    return answers[i].AnswerText;
            }
            return "Not Found";
        }
    }
}
