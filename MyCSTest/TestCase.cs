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
        public void run()
        {
            var method = this.GetType().GetMethod(Name);
            method.Invoke(this,null);
        }
    }
}
