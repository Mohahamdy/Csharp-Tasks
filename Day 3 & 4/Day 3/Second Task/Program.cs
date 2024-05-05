namespace Second_Task
{

    struct HireDate
    {
        private int day, month,year;

        public int Day
        {

            set
            {
                if (value <= 31 && value > 0) day = value;
                else throw new Exception();
            }

            get
            {
                if (day <= 31 && day > 0) return day;
                else throw new Exception();
            }
        }

        public int Month
        {
            set
            {
                if (value <= 12 && value > 0) month = value;
                else throw new Exception();
            }
            get
            {
                if (month <= 30 && month > 0) return day;
                else throw new Exception();
            }
        }

        public int Year
        {
            set
            {
                if (value > 1990 && value < 2060) year = value;
                else throw new Exception(); 
            }

            get
            {
                if (year > 1990 && year < 2060) return year;
                else throw new Exception();
            }
        }

        public HireDate()
        {
            day = DateTime.Now.Day;
            month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
        }

        public HireDate(int _year, int _month, int _day)
        {
            if (_day <= 31 && _day > 0) day = _day;
            else throw new Exception();

            if (_month <= 12 && _month > 0) month = _month;
            else throw new Exception();

            if (_year > 1990 && _year < 2060) year = _year;
            else throw new Exception();
        }

        public override string ToString()
        {
            return $"{day.ToString()}/{month.ToString()}/{Year.ToString()}";
        }

        //public string GetHireData()
        //{
        //    return $"{day.ToString()}/{month.ToString()}/{Year.ToString()}";
        //}

    }

    public enum Gender
    {
        male, female
    }

    struct Employee
    {
        int id;
        decimal salary;
        Gender gender;

        public HireDate HiringDate;

        public int ID
        {
            set
            {
                if (value > 0) id = value;
                else throw new Exception();
            }

            get
            {
                if (id > 0) return id;
                else throw new Exception();
            }
        }

        public decimal Salary
        {
            set
            {
                if (value > 0) salary = value;
                else throw new Exception();
            }

            get
            {
                if (salary > 0) return salary;
                else throw new Exception();
            }
        }

        public Gender Gender
        {
            set
            {
                if (value == Gender.male) { gender = Gender.male; }
                else if (value == Gender.female) { gender = Gender.female; }
                else throw new Exception();

            }

            get
            {
                return gender;
            }
        }
        public Employee()
        {
            HiringDate = new HireDate();
            gender = Gender.male;
        }

        public Employee(int _id, decimal _salary, HireDate _hiringdate, Gender _gender)
        {
            if (_id > 0) id = _id;
            else throw new Exception();

            if (_salary > 0) salary = _salary;
            else throw new Exception();

            HiringDate = _hiringdate;

            if (_gender == Gender.male) { gender = Gender.male; }
            else if (_gender == Gender.female) { gender = Gender.female; }
        }

        public override string ToString()
        {
            return $"ID:{id}, Salary:{salary}, Gender:{gender}, Hiring Date:" + HiringDate.ToString();
        }

        //public string PrintEmployeeData()
        //{
        //    return $"ID:{id}, Salary:{salary}, Hiring Date:" + HiringDate.ToString();
        //}
    }

    struct operation
    {
        public void sort(Employee[] arrOfEmp)
        {
            for (int i = 0; i < arrOfEmp.Length-1; i++)
            {
                for(int j = i+1;j < arrOfEmp.Length-1; j++)
                {
                    if (arrOfEmp[i].ID < arrOfEmp[j].ID)
                    {
                        Employee tmp = arrOfEmp[i];
                        arrOfEmp[i] = arrOfEmp[j];
                        arrOfEmp[j] = tmp;
                    }
                  
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //HireDate hiringdate = new HireDate(2024,12,31);
            //Console.WriteLine(hiringdate.printHireData());

            //Employee employee = new Employee();
            //Console.WriteLine(employee.HiringDate.printHireData());

            //HireDate Hiringdate = new HireDate();

            //Employee employee = new Employee(1, 2000, hiringdate);
            //Console.WriteLine(employee.ID);
            //Console.WriteLine(employee.Salary);
            //Console.WriteLine(employee.HiringDate.printHireData());
            //employee.ID = 5;
            //employee.Salary = 6000;
            //employee.HiringDate = Hiringdate;
            //Console.WriteLine(employee.PrintEmployeeData());

            Employee[] empArr = new Employee[3];

            for (int i = 0; i < empArr.Length; i++)
            {
                Console.WriteLine($"Enter Employee({i + 1}) ID");
                empArr[i].ID = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter Employee({i + 1}) Salary");
                empArr[i].Salary = decimal.Parse(Console.ReadLine());

                Console.WriteLine($"Enter Employee({i + 1}) Hiring Day");
                empArr[i].HiringDate.Day = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter Employee({i + 1}) Hiring Month");
                empArr[i].HiringDate.Month = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter Employee({i + 1}) Hiring Year");
                empArr[i].HiringDate.Year = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter Employee ({i + 1}) Gender [male or female]");
                string G = Console.ReadLine();
                if ((Gender)Enum.Parse(typeof(Gender), G) == Gender.male)
                {
                    empArr[i].Gender = Gender.male;
                }
                else if ((Gender)Enum.Parse(typeof(Gender), G) == Gender.female)
                {
                    empArr[i].Gender = Gender.female;
                }
                else
                {
                    throw new Exception();
                }
            }

            operation O = new operation();

            O.sort(empArr);
            
            for (int i = 0; i < empArr.Length; i++)
            {
                Console.WriteLine($"Employee {i + 1}:");
                Console.WriteLine(empArr[i].ToString());
            }

        }
    }
}
