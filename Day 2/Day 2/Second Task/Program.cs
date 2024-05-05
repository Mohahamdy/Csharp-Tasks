namespace Second_Task
{
    internal class Program
    {
        static void Main()
        {
            //Console.WriteLine("Enter a string");
            //string[] str = Console.ReadLine().Split(" ");
            //string sentence = "";
            //for (int i = (str.Length - 1); i >=0 ; i--)
            //{
            //    sentence += str[i] + " ";
            //}
            //Console.WriteLine(sentence);

            Console.WriteLine("Enter a string");
            string str = Console.ReadLine();
            
            string sentence = "";
            string word = "";
            
            for (int i = 0;i<str.Length;i++)
            {
                if (str[i] == ' ')
                {
                    sentence = word + " " + sentence;
                    word = "";
                }
                else
                {
                    word += str[i];
                }
            }
            sentence = word + " " + sentence;

            Console.WriteLine(sentence);

        }

    }
}
