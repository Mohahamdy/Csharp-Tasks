namespace Second_Task
{
    class Math
    {
        public double add(double x, double y)
        {
            return x + y;
        }

        public double subtract(double x, double y)
        {
            return x - y;
        }

        public double multiply(double x, double y)
        {
            return x * y;
        }

        public double divide(double x, double y)
        {
            return x / y;
        }
    }

    static class math
    {
        public static double add(double x, double y)
        {
            return x + y;
        }

        public static double subtract(double x, double y)
        {
            return x - y;
        }

        public static double multiply(double x, double y)
        {
            return x * y;
        }

        public static double divide(double x, double y)
        {
            return x / y;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = 2.5, y = 2;

            Math m = new Math();
            Console.WriteLine($"Add= {m.add(x, y)}"); ;
            Console.WriteLine($"Sub= {m.subtract(x,y)}");
            Console.WriteLine($"Div= {m.divide(x, y)}");
            Console.WriteLine($"Mul= {m.multiply(x, y)}");

            Console.WriteLine("\nUsing static methods");
            Console.WriteLine($"Add= {math.add(x, y)}"); ;
            Console.WriteLine($"Sub= {math.subtract(x, y)}");
            Console.WriteLine($"Div= {math.divide(x, y)}");
            Console.WriteLine($"Mul= {math.multiply(x, y)}");

        }
    }
}
