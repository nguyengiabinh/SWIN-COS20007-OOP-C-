using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Analyzer
{
    public class DataAnalyser
    {
        private List<int> _numbers;
        //private AverageSummary _avgsummariser;
        //private MinMaxSummary _minMaxSummariser;
        private SummaryStrategy _strategy;

        public SummaryStrategy Strategy
        {
            get
            {
                return _strategy;
            }

            set
            {
                _strategy = value;
            }
        }

        public DataAnalyser(List<int> numbers, SummaryStrategy strategy)
        {
            _numbers = numbers;
            _strategy = strategy;
        }

        public DataAnalyser() : this(new List<int> (), new AverageSummary())
        {
        }

        public void AddNum (int num)
        {
            _numbers.Add(num);
        }
        public void Summerise ()
        {
            _strategy.PrintSummary(_numbers);
        }
    }
}
