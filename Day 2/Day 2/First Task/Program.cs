namespace First_Task
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number of values");
            int N = int.Parse(Console.ReadLine());
            
            int[] nummbers = new int[N];
            for (int i = 0; i < nummbers.Length; i++)
            {
                Console.WriteLine($"Enter number {i+1}:");
                nummbers[i] = int.Parse(Console.ReadLine());
            }
            int Distance = 0;
            int FirstIndex = 0, LastIndex = 0;
            for (int i = 0;i < nummbers.Length;i++)
            {
                for (int j = nummbers.Length-1; j >= 0;j--) 
                {
                    if (nummbers[i] == nummbers[j])
                    {
                        int tmp = (j-1) - i;
                        if (Distance < tmp)
                        {
                            Distance = tmp;
                            FirstIndex = i;
                            LastIndex = j;
                        }
                        
                    }
                    break;
                }
            }
            Console.WriteLine($"\nLongest Distance between Number({FirstIndex+1}) and Number({LastIndex+1}) = {Distance}");

        }
    }
}
