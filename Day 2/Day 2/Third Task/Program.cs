namespace Third_Task;

internal class Program
{
    static void Main()
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        //int occurrence = 0;
        //for (int i = 0; i < 1000000; i++)
        //{
        //    string num = i.ToString();
        //    for (int j = 0; j < num.Length; j++)
        //    {
        //        if (num[j] == '1')
        //        {
        //            occurrence++;
        //        }
        //    }
        //}


        //int digit = Console.ReadLine().Length;
        int digit = 8;
        int occurrence = (digit) * (int)Math.Pow(10,(digit-1));
        Console.WriteLine($"apperance of (1) is {occurrence}");

        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.Elapsed.ToString()} ms");
    }
}
