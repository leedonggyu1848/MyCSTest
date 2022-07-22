using System.Diagnostics;
namespace MyCSTest
{
    class MainClass
    {
        static void Main(string[] args)
        {
            new TestCaseTest("testRunning").run();
        }
    }

    class TestCaseTest : TestCase
    {
        public TestCaseTest(string name) : base(name) { }
        public void testRunning()
        {
             var test = new WasRun("testMethod");
            Assert.True(test.RunCount == 0);
            test.run();
            Assert.True(test.RunCount == 1);
        }
    }


    class WasRun:TestCase
    {
        public int RunCount { get; set; }
        public WasRun(string name):base(name)
        {
            RunCount = default;
        }

        public void testMethod()
        {
            RunCount = 1;
        }

        

    }
}