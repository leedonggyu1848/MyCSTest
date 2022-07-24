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

        public static void Equal(Object obj1, Object obj2)
        {
            if (!obj1.Equals(obj2))
                throw new FailureTestException(
                    "Expected: " + obj1.ToString  +
                    " but Result: " + obj2.ToString);   
        }
    }
}
