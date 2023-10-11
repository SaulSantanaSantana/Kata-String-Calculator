using NUnit.Framework;

namespace StringCalculator.Test {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Test1() {
            Assert.Pass();
        }

        public void Returned0OnEmptyStringTest(){
            StringCalculator calculator = new StringCalculator();
            int res = calculator.add("");
            Assert.AreEqual(res, 0);
        }

        public void ReturnedSameNumberOnOneNumberTest(){
            StringCalculator calculator = new StringCalculator();
            int res = calculator.add("1");
            Assert.AreEqual(res,1);
        }

        public void ReturnedSumOnTwoValuesTest(){
            StringCalculator calculator = new StringCalculator();
            int res = calculator.add("1,2");
            Assert.AreEqual(res,3);
        }
    }
}