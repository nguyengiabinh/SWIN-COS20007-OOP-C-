
namespace Data_Analyzer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 0, 4, 2, 1, 9, 4, 2, 8 };
            DataAnalyser data = new DataAnalyser(numbers, new MinMaxSummary());
            data.Summerise();
            data.AddNum(69);
            data.AddNum(420);
            data.AddNum(666);
            data.Strategy = new AverageSummary();
            data.Summerise();

        }
    }
}