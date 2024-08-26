using TestConsole;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAdd()
        {
            MathOperation obj = new MathOperation();
            int a = obj.Add(10, 10);
            Assert.AreEqual(20, a);

        }
    }
}