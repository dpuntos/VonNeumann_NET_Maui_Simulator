
namespace VonNeumann.Computer.Tests
{
    [TestClass()]
    public class ArithmeticLogicUnitTests
    {
        private ArithmeticLogicUnit _alu;

        [TestMethod]
        public void Setup()
        {
            _alu = new ArithmeticLogicUnit();
        }

        [TestMethod]
        public void TestAdd()
        {
            //2 + 5 = 7
            _alu = new ArithmeticLogicUnit();
            _alu.Register = 0x02;
            _alu.Add();
            _alu.Register = 0x05;
            _alu.Add();
            Assert.AreEqual(0x07, _alu.Accumulator);
        }

        [TestMethod]
        public void TestSubstract()
        {
            //5 - 3 = 2
            _alu = new ArithmeticLogicUnit();
            _alu.Register = 0x05;
            _alu.Add();
            _alu.Register = 0x03;
            _alu.Substract();
            Assert.AreEqual(0x02, _alu.Accumulator);
        }

        [TestMethod]
        public void TestMultiply()
        {
            //2 * 4 = 8
            _alu = new ArithmeticLogicUnit();
            _alu.Register = 0x02;
            _alu.Add();
            _alu.Register = 0x04;
            _alu.Multiply();
            Assert.AreEqual(0x08, _alu.Accumulator);
        }

        [TestMethod]
        public void TestPower()
        {
            //11 ^ 2 = 121
            _alu = new ArithmeticLogicUnit();
            _alu.Register = 0x0B;
            _alu.Add();
            _alu.Register = 0x02;
            _alu.Power();
            Assert.AreEqual(0x79, _alu.Accumulator);
        }

        [TestMethod]
        public void TestAnd()
        {
            //10001111 & 10100000 = 10000000 
            _alu = new ArithmeticLogicUnit();
            _alu.Register = 0x8F;
            _alu.Add();
            _alu.Register = 0xA0;
            _alu.And();
            Assert.AreEqual(0x80, _alu.Accumulator);
        }

        [TestMethod]
        public void TestOr()
        {
            //10001111 | 10100000 = 10101111
            _alu = new ArithmeticLogicUnit();
            _alu.Register = 0x8F;
            _alu.Add();
            _alu.Register = 0xA0;
            _alu.Or();
            Assert.AreEqual(0xAF, _alu.Accumulator);
        }
    }
}
