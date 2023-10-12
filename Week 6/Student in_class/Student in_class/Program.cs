using System.Net;
using System.Xml.Linq;

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
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Student();
                        break;
                    case 2:
                        //StudentSearch();
                        return;
                }
            }
        }

        public static void Student()
        {
            string name = Console.ReadLine();
            DateTime birth = DateTime.Parse(Console.ReadLine());
            string address = Console.ReadLine();
            Student student = new Student(name, birth, address);
            student.ID = StudentList.Count + 1;
            StudentList.Add(student.ID, student);
            student.Display();
        }
    }
}