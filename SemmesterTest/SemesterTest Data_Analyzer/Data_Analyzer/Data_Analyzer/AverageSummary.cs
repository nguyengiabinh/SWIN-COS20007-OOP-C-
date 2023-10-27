using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Analyzer
{
    public class AverageSummary : SummaryStrategy
    {
        private float Average(List<int> numbers)
        {
            float sum = 0;
            int numCount = numbers.Count();
            foreach ( int i in numbers)
            {
                sum += i;
            }
            float average = sum / numCount;
            return average;

        }
        public override void PrintSummary(List<int> numbers)
        {
            Console.WriteLine("Average number is: " + Average(numbers));
        }
    }
}
