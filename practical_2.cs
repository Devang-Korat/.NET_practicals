using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_2
{
    interface IPayroll
    {
        void CalcSal();
    }

    class Employee
    {
        public int empid;
        public string name;
        public double b_salary;
        public int leave;

        public Employee()
        {
            Console.WriteLine("Employee Payroll System");
            Console.WriteLine("-----------------------");
        }

        public void AcceptDet()
        {
            Console.Write("Enter Employee ID: ");
            empid = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            name = Console.ReadLine();

            Console.Write("Enter Basic Salary: ");
            b_salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Number of Leaves: ");
            leave = Convert.ToInt32(Console.ReadLine());
        }

        public double Leave()
        {
            return leave * 500;
        }
        public void DisplayDet()
        {
            Console.WriteLine("\nEmployee Details");
            Console.WriteLine("----------------");
            Console.WriteLine("Employee ID: " + empid);
            Console.WriteLine("Employee Name: " + name);
            Console.WriteLine("Basic Salary: " + b_salary);
            Console.WriteLine("Number of Leaves: " + leave);
        }
    }

    class FullTime : Employee, IPayroll
    {
        public void CalcSal()
        {
            double hra = b_salary * 0.20;
            double ma = b_salary * 0.10;
            double da = b_salary * 0.12;
            double pf = 2500;
            double leavededuction = Leave();

            double netSalary = (b_salary + hra + ma + da) - pf - leavededuction;

            Console.WriteLine("Employee Type: Full Time");
            Console.WriteLine("Leave Deduction: " + leavededuction);
            Console.WriteLine("Net Salary: " + netSalary);
        }
    }

    class PartTime : Employee, IPayroll
    {
        public void CalcSal()
        {
            double leavededuction = Leave();
            double netSalary = b_salary - leavededuction;

            Console.WriteLine("Employee Type: Part Time");
            Console.WriteLine("Leave Deduction: " + leavededuction);
            Console.WriteLine("Net Salary: " + netSalary);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Employee Type");
            Console.WriteLine("1. Full Time");
            Console.WriteLine("2. Part Time");
            Console.Write("Enter Choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                FullTime f = new FullTime();
                f.AcceptDet();
                f.DisplayDet();
                f.CalcSal();
            }
            else if (choice == 2)
            {
                PartTime p = new PartTime();
                p.AcceptDet();
                p.DisplayDet();
                p.CalcSal();
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
            }

            Console.ReadLine();
        }
    }
}
