using System;
using System.Net;
using System.Xml.Linq;
using static week6.Student;

namespace week6
{
    public class Program
    {
        static Dictionary<int, Student> StudentList = new Dictionary<int, Student>();
        private static void Main(string[] args)
        {
          while (true) 
            { 
                Start_program();
            }
        }

        public static void Start_program() 
        {
            while (true)
            {
                Console.WriteLine("pls enter a number choice: 1 or 2");
                int choice = int.Parse(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                        InsertStudent();
                        break;
                    case 2:
                        //StudentSearch();
                        return;
                }
            }
        }

        public static void InsertStudent()
        {
            Console.WriteLine("pls enter firstname");
            string firstname = Console.ReadLine();
            Console.WriteLine("pls enter lastname");
            string lastname = Console.ReadLine();
            Console.WriteLine("pls enter gender");
            string gender = Console.ReadLine().ToLower();
            check_gender_input();
            void check_gender_input()
            {
                if (gender != "male" && gender != "female")
                {
                    gender = "LGBTQ+";
                }
                else
                {
                    return;
                }
            }
            Console.WriteLine("pls enter the student gpa");
            string student_gpa = Console.ReadLine();
            double gpa = double.Parse(student_gpa);
            Console.WriteLine("pls enter one of the follow: freshman, sophomore, junior, senior");
            string enter_status = Console.ReadLine().ToLower();
            if (Enum.TryParse(enter_status, true, out status student_status))
            {
                Console.WriteLine("Insert complete");
            }
            else
            {
                Console.WriteLine("Invalid input. valid input are: freshman, sophomore, junior, senior");
            }
            Student student = new Student( firstname, lastname, gender, gpa, student_status);
            student.show_myself();
        }

    }
}