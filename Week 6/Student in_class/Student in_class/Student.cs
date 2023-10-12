using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace week6
{
    public class Student
    {
        private int _id;
        private string _name;
        private DateTime _birth;
        private string _address;

        public Student (string name, DateTime birth, string address)
        {
            _name = name;
            _birth = birth;
            _address = address;
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set 
            {
                _id = value;
            } 
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public DateTime Birth
        {
            get
            {
                return _birth;
            }
            set
            {
                _birth = value;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        public void Display()
        {
            Console.WriteLine("StudentID : " + ID);
            Console.WriteLine("Student Name: " + Name);
            Console.WriteLine("Date of Birth: " + Birth.ToString("dd/MM/yyyy"));
            Console.WriteLine("Address : " + Address);
        }


    }
}


