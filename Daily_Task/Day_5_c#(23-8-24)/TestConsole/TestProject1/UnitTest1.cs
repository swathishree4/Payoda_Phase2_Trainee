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
        [Test]
        public void TestSub()
        {
            MathOperation obj = new MathOperation();
            int b = obj.Sub(10, 5);
            Assert.AreEqual(5, b);

        }
        [Test]
        public void TestPro()
        {
            MathOperation obj = new MathOperation();
            int b = obj.Pro(10, 5);
            Assert.AreEqual(50, b);

        }
    }
    }