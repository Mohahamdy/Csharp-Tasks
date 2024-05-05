using System.Reflection.Metadata;

namespace Third_Task
{
    class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public int TotalSeconds
        {
            get { return (Hours*3600) + (Minutes*60) + Seconds;}
        }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
        }
    

        public override string ToString()
        {
            if (Hours == 0 && Minutes == 0) return $"Seconds:{Seconds}";
            else if (Hours == 0) return $"Minutes:{Minutes}, Seconds:{Seconds}";
            else
                return $"Hours:{Hours}, Minutes:{Minutes}, Seconds:{Seconds}";
        }

        public override bool Equals(object? obj)
        {
            if(obj is Duration d)
                return Hours == d.Hours && Minutes == d.Minutes && Seconds == d.Seconds;
            else return false ;
        }

        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.TotalSeconds + d2.TotalSeconds);
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            return new Duration(d1.TotalSeconds - d2.TotalSeconds);
        }
        public static Duration operator +(Duration d1,int seconds)
        {
            return new Duration(d1.TotalSeconds + seconds);
        }

        public static Duration operator +(int seconds, Duration d1)
        {
            return new Duration(d1.TotalSeconds + seconds);
        }

        public static Duration operator ++(Duration d1)
        {
            return new Duration(d1.TotalSeconds + 60);
        }

        public static Duration operator --(Duration d1)
        {
            return new Duration(d1.TotalSeconds - 60);
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            if (d1.Hours > d2.Hours) return true;
            else if (d1.Hours == d2.Hours)
            {
                if (d1.Minutes > d2.Minutes) return true;
                else if (d1.Minutes == d2.Minutes)
                {
                    if (d1.Seconds > d2.Seconds) return true;
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            if (d1.Hours < d2.Hours) return true;
            else if (d1.Hours == d2.Hours)
            {
                if (d1.Minutes < d2.Minutes) return true;
                else if (d1.Minutes == d2.Minutes)
                {
                    if (d1.Seconds < d2.Seconds) return true;
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.TotalSeconds <= d2.TotalSeconds;
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.TotalSeconds == d2.TotalSeconds;
        }

        public static bool operator ==(Duration d1, Duration d2)
        {
            return d1.TotalSeconds == d2.TotalSeconds;
        }

        public static bool operator !=(Duration d1, Duration d2)
        {
            return d1.TotalSeconds != d2.TotalSeconds;
        }

        public static explicit operator DateTime(Duration d)
        {
            return new DateTime(1,1,1,d.Hours,d.Minutes,d.Seconds);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Duration D1 = new Duration(1,20,30);
            //Console.WriteLine(D1.ToString()); 

            //Duration D2 = new Duration(3600);
            //Console.WriteLine(D2);

            //Duration D3 = new Duration(7800);
            //Console.WriteLine(D3);

            //Duration D4 = new Duration(666);
            //Console.WriteLine(D4);

            //Duration D5 = new Duration(45);
            //Console.WriteLine(D5);

            //Duration D6 = new Duration(45);
            //Console.WriteLine(D6);

            //if (D5.Equals(D6))
            //{
            //    Console.WriteLine("Equal");
            //}
            //else { Console.WriteLine("NotEqual"); }

            //Duration D1 = new Duration(1, 20, 30);
            //Duration D2 = new Duration(3600);

            Duration D1 = new Duration(7800);
            //Console.WriteLine(D1);
            Duration D2 = new Duration(666);
            //Console.WriteLine(D2);

            Duration D3 = D1 + D2;
            //Console.WriteLine(D3);

            Duration D4 = D2 + 7800;
            //Console.WriteLine(D4);

            //D4 = 666 + D1;
            //Console.WriteLine(D4);

            //D3 = 666 + D3;
            //Console.WriteLine(D3);

            //D3 = ++D3;
            //Console.WriteLine(D3);

            //D3 = --D3;
            //Console.WriteLine(D3);

            //D4 = D1 - D2;
            //Console.WriteLine(D4);

            //if(D2 > D1)
            //{
            //    Console.WriteLine("Greater");
            //}
            //else
            //{
            //    Console.WriteLine("notGreater");
            //}

            //if (D2 < D1)
            //{
            //    Console.WriteLine("Smaller");
            //}
            //else
            //{
            //    Console.WriteLine("notSmaller");
            //}

            DateTime obj = (DateTime)D1;
            Console.WriteLine(obj);

        }
    }
}
