internal class Program
{
    private static void Main(string[] args)
    {
        string name;
        int birth;
 
        try 
        {
            while(true)
            {
                Console.WriteLine("Enter your name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter your year of birth");
                string temp = Console.ReadLine();
                int isNumber = 1;
                for (int i = 0; i < temp.Length; i++)
                {
                    if ((temp[i] >= '0') && (temp[i] <= '9')) { }
                    else
                    {
                        isNumber = 0;
                    }
                }

                if (isNumber == 1)
                {
                    birth = int.Parse(temp);

                    Console.Write(2023 - birth);
                    break;
                }
                else
                {
                    Console.WriteLine("Not number");
                }
                
            }
            
        } 
        catch 
        {
            Console.WriteLine("Error cuz u entered not number");
        }
        
        Console.ReadKey();
    }
}