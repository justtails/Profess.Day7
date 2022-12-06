using Microsoft.VisualStudio.TestTools.UnitTesting;
using Profess.Day7;
using System;

namespace Profess.Day7.Tests
{
    [TestClass]
    public class PhoneNumberCorrector_Test
    {
        [TestMethod]
        public void IsRightFormat_True()
        {
            var corrector = new PhoneNumberCorrector("+7 (800) 555-35-35");
            Assert.IsTrue(corrector.IsRightFormat());
        }

        [TestMethod]
        public void IsRightFormat_False()
        {
            var corrector = new PhoneNumberCorrector("+78005553535");
            Assert.IsFalse(corrector.IsRightFormat());
        }

        [TestMethod]
        public void ClearFromAnotherChars_Var1()
        {
            string expected = "78005553535";
            var corrector = new PhoneNumberCorrector("+7800 555-35-35");

            Assert.AreEqual(expected, corrector.ClearFromAnotherChars());
        }

        [TestMethod]
        public void ClearFromAnotherChars_Var2()
        {
            string expected = "78005553535";
            var corrector = new PhoneNumberCorrector("+7(800)555 35 35");

            Assert.AreEqual(expected, corrector.ClearFromAnotherChars());
        }

        [TestMethod]
        public void IsNumberFormatCorrect_True()
        {
            var corrector = new PhoneNumberCorrector("+7(800)555 35 35");
            Assert.IsTrue(corrector.IsNumberFormatCorrect());
        }

        [TestMethod]
        public void IsNumberFormatCorrect_False1()
        {
            var corrector = new PhoneNumberCorrector("+7(800)aaa bb сс");
            Assert.IsFalse(corrector.IsNumberFormatCorrect());
        }

        [TestMethod]
        public void IsNumberFormatCorrect_False2()
        {
            var corrector = new PhoneNumberCorrector("+7(800)555 35");
            Assert.IsFalse(corrector.IsNumberFormatCorrect());
        }

        [TestMethod]
        public void IsNumberFormatCorrect_False3()
        {
            var corrector = new PhoneNumberCorrector("+9(800)555 35 35");
            Assert.IsFalse(corrector.IsNumberFormatCorrect());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Correct_Var1()
        {
            var corrector = new PhoneNumberCorrector("+9(800)555 35 35");
            corrector.Correct();
        }
    }
}
