namespace First_Task
{
    public class Point3D:ICloneable,IComparable<Point3D>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D()
        {
            
        }

        public Point3D(int x)
        { 
            X = x;
        }

        public Point3D(int x, int y) : this(x)
        {
            Y = y;
        }

        public Point3D(int x, int y, int z) : this(x, y)
        {
            Z = z;
        }

        public override string ToString()
        {
            return $"Point Coordinates: ({X},{Y},{Z})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Point3D p) 
            {
                return X==p.X && Y==p.Y && Z==p.Z;
            }
            else
            {
                return false;
            }
        }

        //public int CompareTo(object? obj)
        //{
        //    Point3D p = obj as Point3D;

        //    if (X.CompareTo(p.X) == 1) return 1;
        //    else if (X.CompareTo(p.X) == 1)
        //    {
        //        if (Y.CompareTo(p.Y) == 1) return 1;
        //        else if (Y.CompareTo(p.Y) == 0)
        //        {
        //            if (Z.CompareTo(p.Z) == 1) return 1;
        //            else if (Z.CompareTo(p.Z) == 0) return 0;
        //            else return -1;
        //        }
        //        else return -1;
        //    }
        //    else return -1;
        //}

        public object Clone()
        {
            return new Point3D(X, Y, Z);
        }

        public int CompareTo(Point3D? other)
        {
            if (X != other.X)
                return X.CompareTo(other.X);
            if (Y != other.Y)
                return Y.CompareTo(other.Y);
            return Z.CompareTo(other.Z);
        }

        public static explicit operator string (Point3D p)
        {
            return $"X:{p.X},Y:{p.Y},Z:{p.Z}";
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Point3D point = new Point3D(1);
            //Console.WriteLine(point);

            //string txt = (string) point;
            //Console.WriteLine(txt);

            /*Point3D p1 = new Point3D();
            Point3D p2 = new Point3D();

            try
            {
                Console.WriteLine("Enter point1 Coordinates:");
                Console.WriteLine("X:");
                p1.X = int.Parse(Console.ReadLine());

                Console.WriteLine("Y:");
                p1.Y = int.Parse(Console.ReadLine());

                Console.WriteLine("Z:");
                p1.Z = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter point2 Coordinates:");
                Console.WriteLine("X:");
                p1.X = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Y:");
                int y;
                int.TryParse(Console.ReadLine(), out y);
                p1.Y = y;

                Console.WriteLine("Z:");
                int z;
                int.TryParse(Console.ReadLine(), out z);
                p1.Z = z;
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid Data");
            }*/

            //Point3D point1 = new Point3D(1, 2, 3);
            //Point3D point2 = new Point3D(1, 2, 3);

            //if(point1.Equals(point2))
            //{
            //    Console.WriteLine("equal");
            //}
            //else
            //{
            //    Console.WriteLine("notEqual");
            //}

            //Console.WriteLine("Enter Number of Points: ");
            //int points = int.Parse(Console.ReadLine());
            //Point3D[] pointsArr = new Point3D[points];

            //for (int i = 0; i < pointsArr.Length; i++)
            //{
            //    Console.WriteLine($"Enter points({i+1}) Coordinates:");

            //    pointsArr[i] = new Point3D();
            //    Console.WriteLine("X: ");
            //    pointsArr[i].X = int.Parse(Console.ReadLine());

            //    Console.WriteLine("Y: ");
            //    pointsArr[i].Y = int.Parse(Console.ReadLine());

            //    Console.WriteLine("Z: ");
            //    pointsArr[i].Z = int.Parse(Console.ReadLine());
            //}

            //Array.Sort(pointsArr);

            //{
            //    int counter = 0;
            //    foreach (Point3D p in pointsArr)
            //    {
            //        Console.WriteLine($"Point({counter+1}): ");
            //        Console.WriteLine(p);
            //        counter++;
            //    }
            //}

            //Point3D p = new Point3D(1, 2, 3);
            //Point3D p1 = (Point3D) p.Clone();
            //Console.WriteLine(p1);

            Point3D[] arr = {
                new Point3D(1, 3, 5),
                new Point3D(1, 1, 4),
                new Point3D(4, 2, 3),
                new Point3D(2, 4, 6)
            };

            Array.Sort(arr);
            {
                int counter = 0;
                foreach (Point3D p in arr)
                {
                    Console.WriteLine($"Point({counter + 1}): ");
                    Console.WriteLine(p);
                    counter++;
                }
            }
        }
        }
}
