using System.Diagnostics;
namespace MyCSTest
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Test");
            Type testType = typeof(TestCaseTest);
            var suite = new TestSuite();
            foreach(var testCase in testType.GetMethods())
                if (testCase.Name.StartsWith("Test"))
                    suite.Add(new TestCaseTest(testCase.Name));
            Console.WriteLine(suite.Run().Summary());
        }
    }

    class TestCaseTest : TestCase
    {
        public TestCaseTest(string name) : base(name) { }
        public RunTester Test { get; set; }

        public void TestTemplateMethod()
        {
            Test = new RunTester("TestMethod");
            Test.Run();
            Assert.Equal("SetUp TestMethod TearDown ", Test.Log);
        }

        public void TestResult()
        {
            Test = new RunTester("TestMethod");
            TestResult result = Test.Run();
            Assert.Equal("1 run, 0 failed", result.Summary());
        }

        public void TestFailedResult()
        {
            Test = new RunTester("TestBrokenMethod");
            TestResult result = Test.Run();
            Assert.Equal("1 run, 1 filed", result.Summary());
        }

        public void TestClassSuite()
        {
            var testSuite = new TestSuite();
            testSuite.Add(new RunTester("TestMethod"));
            testSuite.Add(new RunTester("TestBrokenMethod"));
            var result = testSuite.Run();
            Assert.Equal("2 run, 1 filed", result.Summary());
        }

    }


    class RunTester:TestCase
    {
        public bool WasRun { get; set; }
        public bool WasSetUp { get; set; }
        public string Log { get; set; }
        public RunTester(string name):base(name)
        {
            WasRun = default;
            WasSetUp = default;
            Log = "";
        }

        public void TestMethod()
        {
            WasRun = true;
            Log += "TestMethod ";
        }

        public override void SetUp() 
        {
            WasRun = false;
            WasSetUp = true;
            Log = "SetUp ";
        }
        public void TestBrokenMethod()
        {
            throw new Exception();
        }

        public override void TearDown()
        {
            Log += "TearDown ";
        }
    }
}