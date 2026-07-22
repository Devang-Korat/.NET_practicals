using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_1
{
    internal class Program
    {
        class Student
        {
            public int AdmissionNumber;
            public string StudentName;
            public string Course;
            public int Semester;

            private double _admissionFees;
            private bool _isScholarshipEligible;

            private const double ScholarshipRate = 0.10;

            public Student()
            {
                Console.WriteLine("____________________________");
                Console.WriteLine("STUDENT ADMISSION SYSTEM");
                Console.WriteLine("____________________________");

                Course = "Computer Engineering";
                Semester = 5;

                Console.WriteLine();
            }

            public void AcceptDetails()
            {
                Console.Write("Enter Admission Number: ");
                AdmissionNumber = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student Name: ");
                StudentName = Console.ReadLine();

                Console.Write("Enter Course: ");
                Course = Console.ReadLine();

                Console.Write("Enter Semester: ");
                Semester = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Admission Fees: ");
                _admissionFees = Convert.ToDouble(Console.ReadLine());
            }

            public void CheckScholarshipEligibility()
            {
                if (_admissionFees <= 5000)
                {
                    _isScholarshipEligible = true;
                }
                else
                {
                    _isScholarshipEligible = false;
                }
            }

            public void DisplayDetails()
            {
                double finalFees = _admissionFees;

                if (_isScholarshipEligible)
                {
                    finalFees = _admissionFees - (_admissionFees * ScholarshipRate);
                }

                Console.WriteLine();
                Console.WriteLine("_____________________________");
                Console.WriteLine("STUDENT ADMISSION DETAILS");
                Console.WriteLine("_____________________________");
                Console.WriteLine("Admission Number : " + AdmissionNumber);
                Console.WriteLine("Student Name     : " + StudentName);
                Console.WriteLine("Course           : " + Course);
                Console.WriteLine("Semester         : " + Semester);
                Console.WriteLine("Admission Fees   : " + _admissionFees);
                Console.WriteLine("Scholarship      : " + (_isScholarshipEligible ? "Eligible" : "Not Eligible"));
                Console.WriteLine("Final Fees       : " + finalFees);
                Console.WriteLine("_____________________________");
            }
        }

        static void Main(string[] args)
        {
            Student student = new Student();
            student.AcceptDetails();
            student.CheckScholarshipEligibility();
            student.DisplayDetails();
        }
    }
}
