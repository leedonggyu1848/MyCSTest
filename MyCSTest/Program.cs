using System.Diagnostics;
namespace MyCSTest
{
    class MainClass
    {
        static void Main(string[] args)
        {
            new TestCaseTest("TestTemplateMethod").run();
        }
    }

    class TestCaseTest : TestCase
    {
        public TestCaseTest(string name) : base(name) { }
        public RunTester Test { get; set; }

        public override void SetUp()
        {
            Test = new RunTester("TestMethod");
        }

        public void TestTemplateMethod()
        {
            Test.run();
            Assert.True("SetUp TestMethod TearDown " == Test.Log);
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

        public override void TearDown()
        {
            Log += "TearDown ";
        }
    }
}