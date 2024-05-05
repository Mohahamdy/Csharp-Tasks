using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.IO;
namespace TaskEmployee
{
    /// <summary>
    /// /This struct represents a hiring date of an employee in a form of dd/mm/yyyy
    /// </summary>
    class HireDate:IComparable
    {
        
        private int day, month, year;

        public int Day
        {

            set
            {
                if (value <= 31 && value > 0) day = value;
                else throw new Exception("Day must be between 1 and 31");
            }

            get
            {
                if (day <= 31 && day > 0) return day;
                else throw new Exception("Day must be between 1 and 31");
            }
        }

        public int Month
        {
            set
            {
                if (value <= 12 && value > 0) month = value;
                else throw new Exception("Month must be between 1 and 12");
            }
            get
            {
                if (month <= 30 && month > 0) return month;
                else throw new Exception("Month must be between 1 and 12");
            }
        }

        public int Year
        {
            set
            {
                if (value > 1990 && value < 2060) year = value;
                else throw new Exception("Year must be between 1990 and 2060");
            }

            get
            {
                if (year > 1990 && year < 2060) return year;
                else throw new Exception("Year must be between 1990 and 2060");
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
            else throw new Exception("Day must be between 1 and 31");

            if (_month <= 12 && _month > 0) month = _month;
            else throw new Exception("Month must be between 1 and 12");

            if (_year > 1990 && _year < 2060) year = _year;
            else throw new Exception("Year must be between 1990 and 2060");
        }

        public override string ToString()
        {
            return $"{day.ToString()}/{month.ToString()}/{Year.ToString()}";
        }

        public int CompareTo(object? obj)
        {
            HireDate d = obj as HireDate;
            
            if (Year != d.Year)
                return Year.CompareTo(d.Year);
            if (Month != d.Month)
                return Month.CompareTo(d.Month);
            return Day.CompareTo(d.Day);

        }
    }

    /// <summary>
    /// Enum represents gender (male or female)
    /// </summary>
    public enum Gender
    {
        M ,F
    }

    /// <summary>
    /// Enum represents security level of your employee
    /// </summary>
    public enum SecurityLevel : byte
    {
        Guest, Developer, Secretary, DBA
    }

    /// <summary>
    /// Eunm repersents premession of your employee depends on his security level
    /// </summary>
    [Flags]
    public enum Permission : byte
    {
        read = 1, write = 2, update = 4, delete = 8
    }

    /// <summary>
    /// struct Employee represent an employee of your compant with id,salary,gender,hiring date,security level and his permisiion
    /// </summary>
    class Employee:IComparable
    {
        int id;
        decimal salary;
        Gender gender;
        SecurityLevel securityLevel;
        Permission permission;
        public HireDate HiringDate;

        public int ID
        {
            set
            {
                if (value > 0) id = value;
                else throw new Exception("ID must be greater than 0");
            }

            get
            {
                if (id > 0) return id;
                else throw new Exception("ID must be greater than 0");
            }
        }

        public decimal Salary
        {
            set
            {
                if (value > 0) salary = value;
                else throw new Exception("Salary must be greater than 0");
            }

            get
            {
                if (salary > 0) return salary;
                else throw new Exception("Salary must be greater than 0");
            }
        }

        public Gender Gender
        {
            set
            {
                if (value == Gender.M) { gender = Gender.M; }
                else if (value == Gender.F) { gender = Gender.M; }
                else throw new Exception("Gender Must be M or F");

            }

            get
            {
                return gender;
            }
        }

        public Permission Permission
        {
            set
            {
                if (value == Permission.read) { permission = Permission.read; }
                else if (value == Permission.write) { permission = Permission.write; }
                else if (value == Permission.update) { permission = Permission.update; }
                else if (value == Permission.delete) { permission = Permission.delete; }
                else throw new InvalidDataException(); 
            }
            get
            {
                if (permission == Permission.read) return permission;
                else if (permission == Permission.write) return permission;
                else if (permission == Permission.update) return permission;
                else if (permission == Permission.delete) return permission;
                else throw new InvalidDataException();
            }
        }

        public SecurityLevel SecurityLevel
        {
            set
            {
                if (value == SecurityLevel.Guest) { securityLevel = SecurityLevel.Guest;permission = (Permission)1; }
                else if (value == SecurityLevel.Developer) { securityLevel = SecurityLevel.Developer; permission = (Permission)3; }
                else if (value == SecurityLevel.Secretary) { securityLevel = SecurityLevel.Secretary; permission = (Permission)7; }
                else if (value == SecurityLevel.DBA) { securityLevel = SecurityLevel.DBA; permission = (Permission)15; }
                else throw new InvalidDataException();
            }
            get
            {
                if (securityLevel == SecurityLevel.Guest) return securityLevel;
                else if (securityLevel == SecurityLevel.Developer) return securityLevel;
                else if (securityLevel == SecurityLevel.Secretary) return securityLevel;
                else if (securityLevel == SecurityLevel.DBA) return securityLevel;
                else throw new InvalidDataException();
            }
        }
        public Employee()
        {
            HiringDate = new HireDate();
            gender = Gender.M;
            securityLevel  = SecurityLevel.Guest;
            permission = (Permission)1;
        }

        public Employee(int _id, decimal _salary, HireDate _hiringdate, Gender _gender, SecurityLevel _securityLevel)
        {
            if (_id > 0) id = _id;
            else throw new Exception("ID must be greater than 0");

            if (_salary > 0) salary = _salary;
            else throw new Exception("Salary must be greater than 0");

            HiringDate = _hiringdate;

            if (_gender == Gender.M) { gender = Gender.M; }
            else if (_gender == Gender.F) { gender = Gender.F; }
            else { throw new Exception("Gender must be M or F"); }

            if (_securityLevel == SecurityLevel.Guest) { securityLevel = _securityLevel; permission = (Permission)1; }
            else if (_securityLevel == SecurityLevel.Developer) { securityLevel = _securityLevel; permission = (Permission)3; }
            else if (_securityLevel == SecurityLevel.Secretary) { securityLevel = _securityLevel; permission = (Permission)7; }
            else if (_securityLevel == SecurityLevel.DBA) { securityLevel = _securityLevel; permission = (Permission)15; }
            else throw new InvalidDataException();

        }

        public override string ToString()
        {
            return $"ID: {id}\nSalary: {salary}\nGender: {gender}\nSecurity Level: {securityLevel}\nPermessions: {permission}\nHiring Date: " + HiringDate.ToString();                  
        }

        public override bool Equals(object? obj)
        {
            if (obj is Employee e)
                return id == e.ID && salary == e.Salary && gender == e.Gender && securityLevel == e.SecurityLevel && permission == e.Permission; 
            else 
                return false;
        }

        public int CompareTo(object? obj)
        {

            Employee e = obj as Employee;

            //if (HiringDate.Year.CompareTo(e.HiringDate.Year) == 1) return 1;
            //else if (HiringDate.Year.CompareTo(e.HiringDate.Year) == 0)
            //{
            //    if (HiringDate.Month.CompareTo(e.HiringDate.Month) == 1) return 1;
            //    else if (HiringDate.Month.CompareTo(e.HiringDate.Month) == 0)
            //    {
            //        if (HiringDate.Day.CompareTo(e.HiringDate.Day) == 1) return 1;
            //        else if (HiringDate.Day.CompareTo(e.HiringDate.Day) == 0) return 0;
            //        else return -1;
            //    }
            //    else return -1;
            //}
            //else return -1;

            return HiringDate.CompareTo(e.HiringDate);
        }
    }

    /// <summary>
    /// operation struct represents sorting of your employess using id and hiring date 
    /// </summary>
    struct operation
    {
        public void SwapEmployees(ref Employee employee1,ref Employee employee2)
        {
            Employee tmp = employee1;
            employee1 = employee2;
            employee2 = tmp;
        }
        public void sortByID(ref Employee[] arrOfEmp)
        {
            for (int i = 0; i < arrOfEmp.Length - 1 ; i++)
            {
                for (int j = i + 1; j < arrOfEmp.Length ; j++)
                {
                    if (arrOfEmp[i].ID < arrOfEmp[j].ID)
                    {
                        SwapEmployees(ref arrOfEmp[i],ref arrOfEmp[j]);
                    }
                }
            }
        }
        public void sortByHiringDate(ref Employee[] arrOfEmp)
        {
            for (int i = 0; i < arrOfEmp.Length - 1; i++)
            {
                for (int j = i + 1; j < arrOfEmp.Length; j++)
                {
                    if (arrOfEmp[i].HiringDate.Year < arrOfEmp[j].HiringDate.Year)
                    {
                        SwapEmployees(ref arrOfEmp[i],ref arrOfEmp[j]);
                    }
                    else if (arrOfEmp[i].HiringDate.Year == arrOfEmp[j].HiringDate.Year)
                    {
                        if (arrOfEmp[i].HiringDate.Month < arrOfEmp[j].HiringDate.Month)
                        {
                            SwapEmployees(ref arrOfEmp[i],ref arrOfEmp[j]);
                        }
                        else if(arrOfEmp[i].HiringDate.Month == arrOfEmp[j].HiringDate.Month)
                        {
                            if (arrOfEmp[i].HiringDate.Day < arrOfEmp[j].HiringDate.Day)
                            {
                                SwapEmployees(ref arrOfEmp[i],ref arrOfEmp[j]);
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// class log to log errors in a file with all data
    /// </summary>
    class loggingFile
    {
        public static void LogException(Exception ex)
        {
            string logFilePath = @"D:\C#\Mohamed Hamdy\Day 5\Day 5\Employee\ExceptionsData\ExceptionData.txt";

            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine($"Time of Exception: {DateTime.Now}");
                sw.WriteLine($"Exception Message: {ex.Message}");
                sw.WriteLine($"Stack Trace:\n{ex.StackTrace}");
                sw.WriteLine($"Exception Target: {ex.TargetSite}");
                sw.WriteLine($"Exception Source: {ex.Source}");
                sw.WriteLine("");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] empArr = new Employee[3];

            for (int i = 0; i < empArr.Length; i++)
            {
                try
                {
                    empArr[i] = new Employee();

                    //Console.WriteLine($"Enter Employee({i + 1}) ID");
                    //empArr[i].ID = int.Parse(Console.ReadLine());

                    //Console.WriteLine($"Enter Employee({i + 1}) Salary");
                    //empArr[i].Salary = decimal.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter Employee({i + 1}) Hiring Day");
                    empArr[i].HiringDate.Day = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter Employee({i + 1}) Hiring Month");
                    empArr[i].HiringDate.Month = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter Employee({i + 1}) Hiring Year");
                    empArr[i].HiringDate.Year = int.Parse(Console.ReadLine());

                    //Console.WriteLine($"Enter Employee ({i + 1}) Gender [M fo male or F for female]");
                    //string G = Console.ReadLine();
                    //if ((Gender)Enum.Parse(typeof(Gender), G) == Gender.M)
                    //{
                    //    empArr[i].Gender = Gender.M;
                    //}
                    //else if ((Gender)Enum.Parse(typeof(Gender), G) == Gender.F)
                    //{
                    //    empArr[i].Gender = Gender.F;
                    //}
                    //else
                    //{
                    //    throw new Exception("Gender Must be M or F");
                    //}

                    //Console.WriteLine($"Enter Employee ({i + 1}) Security [Guest, Developer, Secretary, DBA]");
                    //string Security = Console.ReadLine();
                    //if ((SecurityLevel)Enum.Parse(typeof(SecurityLevel), Security) == SecurityLevel.Guest)
                    //{
                    //    empArr[i].SecurityLevel = SecurityLevel.Guest;
                    //}
                    //else if ((SecurityLevel)Enum.Parse(typeof(SecurityLevel), Security) == SecurityLevel.Developer)
                    //{
                    //    empArr[i].SecurityLevel = SecurityLevel.Developer;
                    //}
                    //else if ((SecurityLevel)Enum.Parse(typeof(SecurityLevel), Security) == SecurityLevel.Secretary)
                    //{
                    //    empArr[i].SecurityLevel = SecurityLevel.Secretary;
                    //}
                    //else if ((SecurityLevel)Enum.Parse(typeof(SecurityLevel), Security) == SecurityLevel.DBA)
                    //{
                    //    empArr[i].SecurityLevel = SecurityLevel.DBA;
                    //}
                    //else throw new Exception("Invalid Security Level");
                }
                catch(Exception ex)
                { 
                    loggingFile.LogException(ex);
                    Console.WriteLine("Please Enter 'AGAIN' your ALL Data Coreectly");
                    --i;
                }

            }

            //operation O = new operation();

            //O.sortByID(ref empArr);
            //O.sortByHiringDate(ref empArr);

            Array.Sort(empArr);

            for (int i = 0; i < empArr.Length; i++)
            {
                Console.WriteLine($"\n-Employee {i + 1}");
                Console.WriteLine(empArr[i].ToString());
                
            }

        }
    }
}
