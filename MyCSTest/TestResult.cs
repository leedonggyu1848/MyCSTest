using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSTest
{
    class TestResult
    {
        public int RunCount { get; set; }
        public int FailureCount { get; set; }

        public TestResult()
        {
            RunCount = 0;
            FailureCount = 0;
        }

        public void Teststarted()
        {
            RunCount++;
        }

        public void TestFailed()
        {
            FailureCount++;
        }
        public string Summary()
        {
            return String.Format("{0:d} run, {1:d} failed", RunCount, 0);
        }
    }
}
