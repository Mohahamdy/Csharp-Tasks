using System.IO;
using System.Threading.Channels;
namespace QUIZ
{
    class Question:IComparable<Question>,ICloneable
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public float Mark { get; set; }

        public Question(string header = "",string body = "", float mark = 0)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        public override string ToString()
        {
            return $"{Header}({Mark} marks):\n{Body}\n";
        }

        public override bool Equals(object? obj)
        {
            if(obj is Question q)
                return Header == q.Header && Body == q.Body && Mark == q.Mark;
            else 
                return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;

            hash = hash * 23 + Header.GetHashCode();
            hash = hash * 23 + Body.GetHashCode();
            hash = hash * 23 + Mark.GetHashCode();

            return hash;
        }

        public int CompareTo(Question? other)
        {
            return Header.CompareTo(other.Header);
        }

        public object Clone()
        {
            return new Question();
        }
    }

    class TrueOrFalse : Question
    {
        public TrueOrFalse(string header,string body, float mark) : base(header,body, mark)
        { }
    }

    class ChooseOne : Question
    {
        public ChooseOne(string header, string body, float mark) : base(header, body, mark)
        {

        }
    }

    class ChooseAll : Question
    {
        public ChooseAll(string header, string body, float mark) : base(header, body, mark)
        {

        }
    }

    class QuestionList : List<Question>
    {
        static int counter = 0;
        string FilePath = $"D:\\Technical Materials\\C#\\Mohamed Hamdy\\Day9\\Day 9\\QuestionList\\QuestionList{counter + 1}.txt";

        public QuestionList()
        {
            counter++;
        }
        public new void Add(Question item)
        {
            base.Add(item);
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(item);
            }
        }
    }

    class Answer
    {
        public bool TrueOrFalse { get; set; }

        public string Body { get; set; }

        public Answer(string body = "", bool trueOrFalse = false)
        {
            Body = body;
            TrueOrFalse = trueOrFalse;
        }

        public override string ToString()
        {
            return $"- {Body}";
        }
    }

    class AnswerList : List<Answer>
    {
        static int counter = 0;
        string FilePath = $"D:\\Technical Materials\\C#\\Mohamed Hamdy\\Day9\\Day 9\\AsnwerList\\AsnwerList{counter + 1}.txt";

        public AnswerList()
        {
            counter++;
        }
        public new void Add(Answer item)
        {
            base.Add(item);
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(item);
            }
        }
    }
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Student(int id=0,string name ="")
        {
            ID = id;
            Name = name;
        }

        public void StartExam(object sender, EventArgs e)
        {
            Console.WriteLine($"[------------- Student: {Name} starting his Exam ---------------]\n");
        }

        public void FinsihExam(object sender, EventArgs e)
        {
            Console.WriteLine($"[------------- Student: {Name} finished his Exam ---------------]\n");
        }
    }

    abstract class Exam
    {
        public event EventHandler<EventArgs> ExamMood;

        public virtual void OnExamMood(EventArgs e)
        {
            ExamMood?.Invoke(this, e);
        }

        public Dictionary<Question, List<Answer>> QuestionAnswer { get; set; }
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }

        public Exam(int time,int numberOfQusetions,Dictionary<Question,List<Answer>> qusetionAnswer)
        {
            Time = time;
            NumberOfQuestions = numberOfQusetions;
            QuestionAnswer = qusetionAnswer;
        }

        public abstract void Show();
    }

    class PracticeExam : Exam
    {
        public PracticeExam(int time, int numberOfQusetions, Dictionary<Question, List<Answer>> qusetionAnswer) :base(time,numberOfQusetions,qusetionAnswer)
        {
            
        }
        public override void Show()
        {
            Console.WriteLine($"Exam Time: ({Time})mins\t Number of Questions: {NumberOfQuestions}");
            
            foreach (var item in QuestionAnswer)
            {
                Console.WriteLine(item.Key);
                foreach (var answer in item.Value)
                    Console.WriteLine(answer);
                Console.WriteLine("-----------------------------");
            }

            OnExamMood(new EventArgs());

            Console.WriteLine("\n[ -- The right answer for your Exam -- ]");

            foreach (var item in QuestionAnswer)
            {

                foreach (var answer in item.Value)
                {
                    if (answer.TrueOrFalse)
                    {
                        Console.WriteLine(answer);
                        Console.WriteLine("");
                    }
                }
            }           
        }
    }

    class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQusetions, Dictionary<Question, List<Answer>> qusetionAnswer) : base(time, numberOfQusetions, qusetionAnswer)
        {

        }
        public override void Show()
        {
            Console.WriteLine($"Exam Time: ({Time})mins\t Number of Questions: {NumberOfQuestions}");

            foreach (var item in QuestionAnswer)
            {
                Console.WriteLine(item.Key);
                foreach(var answer in item.Value)
                    Console.WriteLine(answer);
                Console.WriteLine("");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //QuestionList q1 = new QuestionList()
            //{
            //    new TrueOrFalse("Did you play?", 10),
            //    new TrueOrFalse("Are you playing?", 15),
            //    new TrueOrFalse("Did you answer?" , 20),
            //};

            //QuestionList q2 = new QuestionList()
            //{
            //    new ChooseAll("Can you come?",20),
            //    new ChooseAll("could you make me coffe?",20),
            //    new ChooseAll("what is ur fav color?",20)
            //};

            //AnswerList a1 = new AnswerList() { 
            //    new Answer("Yes,i played"),
            //    new Answer("I can come"),
            //    new Answer("I could")
            //};

            //Question q1 = new TrueOrFalse("True or False", "Will You Come?", 15);
            //Question q2 = new TrueOrFalse("True or False", "Will You Come?", 10);

            //if (q1.GetHashCode() == q2.GetHashCode())
            //    Console.WriteLine("Equal");
            //else
            //    Console.WriteLine("NOtequal");


            int exam = 0;
            do
            {
                Console.WriteLine("Choose Your Exam: \n1 for Practice Exam\n2 for Final Exam");
                exam = int.Parse(Console.ReadLine());
            } while (exam < 1 || exam > 2);

            if (exam == 1)
            {
                
                Dictionary<Question, List<Answer>> Q = new Dictionary<Question, List<Answer>>();

                Q.Add(new TrueOrFalse("True or False", "Will You Come?", 10), new List<Answer>()
                {
                    new Answer("Yes i can",true),
                    new Answer("no i can't",false),
                    new Answer("May be",false),
                });
                Q.Add(new TrueOrFalse("True or False", "Will You Come?", 15), new List<Answer>()
                {
                    new Answer("Yes i can",false),
                    new Answer("no i can't",true),
                    new Answer("May be",false),
                });
                Q.Add(new TrueOrFalse("True or False", "Will You Come?", 20), new List<Answer>()
                {
                    new Answer("Yes i can",false),
                    new Answer("no i can't",false),
                    new Answer("May be",true),
                });

                Student s = new Student(1, "ahmed");

                PracticeExam P = new PracticeExam(90, 3, Q);

                P.ExamMood += s.StartExam;
                P.OnExamMood(new EventArgs());

                P.ExamMood -= s.StartExam;
                P.ExamMood += s.FinsihExam;

                P.Show();

            }

            else if (exam == 2)
            {
                Dictionary<Question, List<Answer>> Q = new Dictionary<Question, List<Answer>>();

                Q.Add(new TrueOrFalse("True or False", "Will You Come?", 10), new List<Answer>()
                {
                    new Answer("Yes i can",true),
                    new Answer("no i can't",false),
                    new Answer("May be",false),
                });
                Q.Add(new TrueOrFalse("True or False", "Will You Come?", 15), new List<Answer>()
                {
                    new Answer("Yes i can",false),
                    new Answer("no i can't",true),
                    new Answer("May be",false),
                });
                Q.Add(new TrueOrFalse("True or False", "Will You Come?", 20), new List<Answer>()
                {
                    new Answer("Yes i can",false),
                    new Answer("no i can't",false),
                    new Answer("May be",true),
                });


                FinalExam P = new FinalExam(90, 3, Q);

                Student s = new Student(1, "Hamdy");

                P.ExamMood += s.StartExam;
                P.OnExamMood(new EventArgs());

                P.Show();

                P.ExamMood -= s.StartExam;
                P.ExamMood += s.FinsihExam;
                P.OnExamMood(new EventArgs());
            }
        }
    }
}