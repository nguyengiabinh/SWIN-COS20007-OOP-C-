using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Analyzer
{
    public class MinMaxSummary : SummaryStrategy
    {
        private int Minimum (List<int> numbers)
        {
            int smallest = numbers[0];
            foreach (int i in numbers)
            {
                if (smallest > i)
                {
                    smallest = i;
                }
            }
            return smallest;
        }

        private int Maximum(List<int> numbers)
        {
            int biggest = numbers[0];
            foreach (int i in numbers)
            {
                if (biggest < i)
                {
                    biggest = i;
                }
            }
            return biggest;
        }

        public override void PrintSummary(List<int> numbers)
        {
            Console.WriteLine("Smallest number is: " + Minimum(numbers));
            Console.WriteLine("Biggest number is: " + Maximum(numbers));
        }
    }
}
