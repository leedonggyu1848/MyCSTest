using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSTest
{   class FailureTestException: Exception
    {
        public FailureTestException() { }
        public FailureTestException(string message): base(message) { }

    }

    static class Assert
    {
        public static void True(bool result)
        {
            if (!result) throw new FailureTestException();
        }
    }
}
