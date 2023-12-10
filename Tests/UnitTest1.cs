using PostClasses;

namespace Tests
{
    [TestClass]
    public class LClassTest
    {
        [TestMethod]
        public void TestCheckMethod()
        {

            Assert.IsTrue(LClass.Check(MainClass.ParseEval("1100")));
            Assert.IsTrue(LClass.Check(MainClass.ParseEval("11000011")));
            Assert.IsTrue(LClass.Check(MainClass.ParseEval("11111111")));
            Assert.IsFalse(LClass.Check(MainClass.ParseEval("00001000")));
            Assert.IsFalse(LClass.Check(MainClass.ParseEval("00001010")));
            Assert.IsFalse(LClass.Check(MainClass.ParseEval("10001010")));

        }
    }

    [TestClass]
    public class MClassTest
    {
        [TestMethod]
        public void TestCheckMethod()
        {

            Assert.IsFalse(MClass.Check(MainClass.ParseEval("1100")));
            Assert.IsFalse(MClass.Check(MainClass.ParseEval("11000011")));
            Assert.IsTrue(MClass.Check(MainClass.ParseEval("11111111")));
            Assert.IsFalse(MClass.Check(MainClass.ParseEval("00001000")));
            Assert.IsTrue(MClass.Check(MainClass.ParseEval("00111111")));
            Assert.IsTrue(MClass.Check(MainClass.ParseEval("00001111")));


        }
    }

    [TestClass]
    public class SClassTest
    {
        [TestMethod]
        public void TestCheckMethod()
        {

            Assert.IsTrue(SClass.Check(MainClass.ParseEval("1100")));
            Assert.IsTrue(SClass.Check(MainClass.ParseEval("00001111")));
            Assert.IsTrue(SClass.Check(MainClass.ParseEval("01001101")));
            Assert.IsFalse(SClass.Check(MainClass.ParseEval("11000011")));
            Assert.IsFalse(SClass.Check(MainClass.ParseEval("11111111")));
            Assert.IsFalse(SClass.Check(MainClass.ParseEval("00001000")));
            

        }
    }
}