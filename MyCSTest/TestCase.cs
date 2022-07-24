using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSTest
{
    class TestCase
    {
        public string Name { get; set; }
        public TestCase(string name)
        {
            Name = name;
        }

        public virtual void SetUp() { }
        public TestResult Run(TestResult result)
        {
            result.Teststarted();
            SetUp();
            var method = GetType().GetMethod(Name);
            try
            {
                if (method == null) throw new Exception();
                method.Invoke(this, null);
            }
            catch
            {
                result.TestFailed();
            }
            TearDown();
            return result;
        }

        public TestResult Run()
        {
            TestResult result = new TestResult();
            return Run(result);
        }

        public virtual void TearDown() { 
        }
    }
}
