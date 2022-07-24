using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSTest
{
    class TestSuite
    {
        IEnumerable<TestCase> Tests { get; set; }

        public TestSuite()
        {
            Tests = new List<TestCase>();
        }

        public void Add(TestCase test)
        {
            Tests = Tests.Append(test).ToList();
        }

        public TestResult Run()
        {
            var result = new TestResult();
            foreach (TestCase test in Tests)
                test.Run(result);

            return result;
        }


    }
}
