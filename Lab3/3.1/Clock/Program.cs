namespace Clock
{
    class Program
    {
        static void Main()
        {
            Clock clock = new();

            for (int i = 0; i < 86400; i++)
            {
                Thread.Sleep(0);
                clock.Tick();
                Console.WriteLine(clock.Time());
            }
        }
    }
}