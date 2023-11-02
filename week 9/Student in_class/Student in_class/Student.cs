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
        public enum status { freshman, sophomore, junior, senior}
        private double gpa;
        private string _firstname;
        private string _lastname;
        private string gender;
        private status student_status;

        public Student (string firstname, string lastname, string gender, double gpa, status student_status)
        {
            _firstname = firstname;
            _lastname = lastname;
            this.gender = gender;
            this.gpa = gpa;
            this.student_status = student_status;
        }

        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set 
            {
                _firstname = value;
            } 
        }

        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public status Status
        {
            get
            {
                return student_status;
            }
            set
            {
                student_status = value;
            }
        }

        public double GPA
        {
            get 
            { 
                return gpa;
            }
            set
            { 
                gpa = value; 
            }
        }

        public void show_myself()
        {
            Console.WriteLine("Student Name: " + FirstName + " " + LastName);
            Console.WriteLine("Gender: " + Gender);
            Console.WriteLine("GPA : " + GPA);
            Console.WriteLine("Status : " + Status);
        }

        //public study_time()
        //{
        //    if (gpa > 4.0d) 
        //    {
        //        double gpa = 4.0d;
        //    }
        //}


    }
}


