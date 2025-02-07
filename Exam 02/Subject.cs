namespace Exam_02
{
    class Subject : ICloneable, IComparable<Subject>
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int id, string name, Exam exam)
        {
            SubjectId = id;
            SubjectName = name;
            Exam = exam;
        }
        public Subject(int id, string name) : this(id, name, null) { }

        public void CreateExam(Exam exam)
        {
            Exam = exam;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(Subject other)
        {
            return SubjectId.CompareTo(other.SubjectId);
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Subject Name: {SubjectName}";
        }
        public static void CreateExam()
        {
            int subjectId;
            bool idCheck;
            do
            {
                Console.Write("Enter Subject ID: ");
                idCheck = int.TryParse(Console.ReadLine(), out subjectId);

            } while (!idCheck);

            Console.Write("Enter Subject Name: ");
            string subjectName = Console.ReadLine();

            int examTime;
            bool examTimeCheck = false;
            do
            {
                Console.Write("Enter Exam Time (in minutes): ");
                examTimeCheck = int.TryParse(Console.ReadLine(), out examTime);

            } while (!examTimeCheck);

            Console.WriteLine("Choose Exam Type: 1- Final  2- Practical");
            Exam exam = null;

            int choice;
            bool choiceCheck;
            do
            {
                Console.Write("Enter Your Choice: ");
                choiceCheck = int.TryParse(Console.ReadLine(), out choice);

            } while (!choiceCheck);
            if (choice == 1)
                exam = new FinalExam(examTime);
            else
                exam = new PracticalExam(examTime);

            Subject subject = new Subject(subjectId, subjectName, exam);
            Console.WriteLine("\n" + subject.ToString() + "\n");

            exam.SubjectInfo = subject.ToString();

            int numQuestions;
            bool numQuestionsCheck;
            do
            {
                Console.Write("Enter the number of questions: ");
                numQuestionsCheck = int.TryParse(Console.ReadLine(), out numQuestions);

            } while (!numQuestionsCheck);

            for (int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine("\nEntering details for Question " + (i + 1) + ":");

                int qType = 1;
                if (exam is FinalExam)
                {
                    Console.WriteLine("Choose question type: 1- MCQ  2- True/False");
                    int.TryParse(Console.ReadLine(), out qType);
                    if (qType != 1 && qType != 2)
                    {
                        Console.WriteLine("Invalid question type. Defaulting to MCQ.");
                        qType = 1;
                    }
                }

                Console.Write("Enter question text: ");
                string text = Console.ReadLine();



                int mark;
                bool markCheck;
                do
                {
                    Console.Write("Enter question mark: ");
                    markCheck = int.TryParse(Console.ReadLine(), out mark);

                } while (!markCheck);



                int correctAnswerId;
                bool correctAnswerIdCheck;
                do
                {
                    Console.Write("Enter correct answer ID: ");
                    correctAnswerIdCheck = int.TryParse(Console.ReadLine(), out correctAnswerId);

                } while (!correctAnswerIdCheck);

                if (qType == 1)
                {
                    List<Answer> answers = new List<Answer>();
                    for (int j = 1; j <= 3; j++)
                    {
                        Console.Write("Enter option " + j + ": ");
                        string optionText = Console.ReadLine();
                        answers.Add(new Answer(j, optionText));
                    }
                    exam.Questions.Add(new MCQQuestion("MCQ Question", text, mark, answers, correctAnswerId));
                }
                else if (qType == 2)
                {
                    exam.Questions.Add(new TrueFalseQuestion("True/False Question", text, mark, correctAnswerId));
                }
            }

            Console.Write("\nStart Exam? (yes/no): ");
            string startExam = Console.ReadLine().Trim().ToLower();
            if (startExam == "yes")
                exam.ShowExam();
            else
                Console.WriteLine("Exam cancelled.");
        }

    }
}
