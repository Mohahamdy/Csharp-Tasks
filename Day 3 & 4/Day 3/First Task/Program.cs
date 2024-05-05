namespace First_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Enter number of student");
            int studentNums = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of Subject");
            int subjectNums = int.Parse(Console.ReadLine());

            float[,] grades = new float[studentNums,subjectNums];

            for (int i = 0; i < grades.GetLength(0); i++)
            {
                Console.WriteLine($"Student {i+1}");
                for(int j = 0;  j < grades.GetLength(1); j++)
                {
                    Console.WriteLine($"Enter subject {j+1} grade");
                    grades[i,j] = float.Parse(Console.ReadLine());
                }
            }

            for (int i = 0;i < studentNums;i++)
            {
                float sumOfStudentGrades = 0;
                
                Console.WriteLine($"Student {i + 1}");

                for (int j = 0;j < subjectNums;j++) 
                {
                    Console.WriteLine($"Grade for subject {j+1} = {grades[i,j]}");
                    sumOfStudentGrades += grades[i, j];
                }

                Console.WriteLine($"Sum of grades for student {i+1} = {sumOfStudentGrades}");
            }

            for(int i = 0;i <subjectNums;i++)
            {
                float sumOfSubjectGrades = 0;

                Console.WriteLine($"Subject {i + 1}");

                for (int j = 0;j<studentNums;j++)
                {
                    sumOfSubjectGrades += grades[j,i];
                }

                Console.WriteLine($"Avg of grades for subject {i + 1} = {sumOfSubjectGrades / subjectNums}");
            }*/

            int maxNumOfsubject = 0;

            Console.WriteLine("Enter number of student");
            int studentNums = int.Parse(Console.ReadLine());

            float[][] grades = new float[studentNums][];

            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine($"Enter number of Subject for student {i+1}");
                int subjectNums = int.Parse(Console.ReadLine());
                if(subjectNums > maxNumOfsubject)
                {
                    maxNumOfsubject = subjectNums;
                }

                grades[i] = new float[subjectNums];

                for (int j = 0; j < subjectNums; j++)
                {
                    Console.WriteLine($"Enter subject {j + 1} grade");
                    grades[i][j] = float.Parse(Console.ReadLine());
                }
            }

            for (int i = 0;i < grades.Length; i++)
            {
                float sumOfStudentGrades = 0;

                Console.WriteLine($"Student ({i + 1})");

                for (int j = 0; j < grades[i].Length; j++)
                {
                    Console.WriteLine($"Grade for subject {j + 1} = {grades[i][j]}");
                    sumOfStudentGrades += grades[i][j];
                }

                Console.WriteLine($"Sum of grades for student ({i + 1}) = {sumOfStudentGrades}");
            }

            Console.WriteLine("Average of Subject:-");
            for (int i = 0; i < maxNumOfsubject; i++)
            {
                float sumOfSubjectGrades = 0;
                int numberOfstudent = 0;

                for (int j = 0; j < studentNums; j++)
                {
                    if (i < grades[j].Length)
                    {
                        sumOfSubjectGrades += grades[j][i];
                        numberOfstudent++;
                    }
                }

                Console.WriteLine($"Avg of grades for subject ({i + 1}) = {sumOfSubjectGrades / numberOfstudent}");
            }

        }
    }
}
