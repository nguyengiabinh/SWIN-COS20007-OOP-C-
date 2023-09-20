using System;

namespace HelloWorld
{
    class MainClass { 
        public static void Main(string[] args)
        {
            Meassage myMeassage;

            myMeassage = new Meassage("Hello World - from Message Object");
            myMeassage.print();

            Console.WriteLine("Enter name: ");
            string name;
            name = Console.ReadLine();
            if (name.ToLower() == "mark")
            {
                Console.Write("Welcome back!");
            }
            else if (name.ToLower() == "fred")
            {
                Console.Write("What a lovely name");
            }
            else if (name.ToLower() == "wilma")
            {
                Console.Write("Great name");
            }
            else if (name.ToLower() == "alice")
            {
                Console.Write("Oh hi!");
            }
            else
            {
                Console.Write("That is a silly name");
            }

        }
    }
}