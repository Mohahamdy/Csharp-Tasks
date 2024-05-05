using System.Linq.Expressions;

namespace Employee_Events
{
    class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }

        public DateTime BirthDate { get; set; }

        public int VacationStock { get; set; }

        public Employee(int employeeID,DateTime birthDate,int vacationStock)
        {
            EmployeeID = employeeID;
            BirthDate = birthDate;
            VacationStock = vacationStock;
        }

        public bool RequestVacation(DateTime From, DateTime To)
        {
            if (From > To)
                throw new Exception("To date must be greater than From date");

            else
            {
                int requstedDays = (int)(To - From).TotalDays;
                if(requstedDays < VacationStock)
                {
                    VacationStock -= requstedDays;
                    return true;
                }
                return false;
            }
        }
        public void EndOfYearOperation()
        {
            DateTime dateTime = DateTime.Now;
            int age = dateTime.Year - BirthDate.Year;

            if (age > 60)
            {
                EmployeeLayOffEventArgs e = new EmployeeLayOffEventArgs(LayOffCause.Age);
                OnEmployeeLayOff(e);
            }
            
            else if(VacationStock < 0)
            {
                EmployeeLayOffEventArgs e = new EmployeeLayOffEventArgs(LayOffCause.Vacation);
                OnEmployeeLayOff(e);
            }
        }
    }
    public enum LayOffCause
    { Vacation, Age }


    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }

        public EmployeeLayOffEventArgs(LayOffCause cause) {  this.Cause = cause; }
    }


    //Department
    //Employee should be removed from Department Staff List in both Cases 
    //If Employee Vacation Stock < 0 
    //If Employee Age > 60 
    class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }

        List<Employee> Staff;

        public Department(int deptID, string deptName)
        { 
            this.DeptID = deptID; this.DeptName = deptName;
        }
        public void AddStaff(Employee E)
        {
            ///Try Register for EmployeeLayOff Event Here 
            Staff = new List<Employee>();
            Staff.Add(E);
            E.EmployeeLayOff += RemoveStaff;
        }

        ///CallBackMethod 
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            Employee emp = sender as Employee;

            if(e.Cause == LayOffCause.Age || e.Cause == LayOffCause.Vacation)
            {
                Staff.Remove(emp);
                Console.WriteLine($"Employee: {emp.EmployeeID} has been removed from Dept: {DeptName} due to {e.Cause}");
            }
        }
    }

    //Club
    //Employee should be removed from Club Member List Only if Employee Vacation Stock < 0. 
    //If Employee Age > 60 will still remain a Member of Company Club 
    class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }

        List<Employee> Members;

        public Club(int clubID,string clubName)
        {
            ClubID = clubID;
            ClubName = clubName;
        }

        public void AddMember(Employee E)
        {
            ///Try Register for EmployeeLayOff Event Here 
            Members = new List<Employee>();
            Members.Add(E);
            E.EmployeeLayOff += RemoveMember;
        }

        //CallBackMethod
        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            
            ///Employee Will not be removed from the Club if Age>60 
            ///Employee will be removed from Club if Vacation Stock < 0  
            Employee E = (Employee)sender;
            if(e.Cause == LayOffCause.Vacation)
            {
                Members.Remove(E);
                Console.WriteLine($"Employee: {E.EmployeeID} has been removed from Club: {ClubName} due to {e.Cause}");
            }

        }

        internal class Program
        {
            static void Main(string[] args)
            {
                //Employee e = new Employee(3,DateTime.Now.AddYears(-15),50);
                //bool b =e.RequestVacation(DateTime.Now,DateTime.Now.AddDays(60));
                //Console.WriteLine(b);
                //Console.WriteLine(e.VacationStock);

                Employee e1 = new Employee(1, new DateTime(1950, 8, 10), 15);
                Employee e2 = new Employee(2, new DateTime(2000, 8, 10), -10);
                Employee e3 = new Employee(3, new DateTime(1940, 8, 10), 20);
                Employee e4 = new Employee(4, new DateTime(1990, 8, 10), 30);

                Department d = new Department(1, "LOL");
                Club c = new Club(1,"HAH");

                d.AddStaff(e1);
                d.AddStaff(e2);
                d.AddStaff(e3);
                d.AddStaff(e4);

                c.AddMember(e1);
                c.AddMember(e2);
                c.AddMember(e3);
                c.AddMember(e4);

                e1.EndOfYearOperation();
                e2.EndOfYearOperation();
                e3.EndOfYearOperation();
                e4.EndOfYearOperation();
            }
        }
    }
 }
