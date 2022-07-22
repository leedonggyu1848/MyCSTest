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
        public void run()
        {
            SetUp();
            var method = GetType().GetMethod(Name);
            if (method == null) throw new Exception();
            method.Invoke(this,null);
            TearDown();
        }

        public virtual void TearDown() { 
        }
    }
}
