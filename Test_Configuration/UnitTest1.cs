using Cy_Configuration;
using NUnit.Framework;

namespace Test_Configuration
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            System.Console.WriteLine("Ö´ÐÐSetup");
        }

        [Test]
        public void Test1()
        {
            var str = Config.GetObj<string>("app.json","Conn");
            //Assert.Fail();
        }
    }
}