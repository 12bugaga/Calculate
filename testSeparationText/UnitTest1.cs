using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testSeparationText
{
    [TestClass]
    public class Test_Calculator
    {
        [DataRow("5+2", 7)]
        [DataRow("-2+5", 3)]
        [DataRow("(2+5)", 7)]
        [DataRow("(-2)+5", 3)]
        [DataRow("+2+(-5)", -3)]
        [DataRow("(-10)+2", -8)]
        [DataRow("10*2", 20)]
        [DataRow("(-10)*2", -20)]
        [DataRow("(-10)2", -20)]
        [DataRow("2(15-15)", 0)]
        [DataRow("2*(51*(-10))", -1020)]
        [DataRow("-15/5-3", -6)]
        [DataRow("-60/30*5*10+1", -99)]
        [DataRow("(10*2/10)+98-100", 0)]
        [DataRow("10/3", 3.33)]
        [DataRow("(5.5+9.2*4.8)/10/3.2-9-(6.5+2.4)", -16.35)]
        [DataTestMethod]
        public void SeparationText_setExample_getExample(string firstStr, double expectedResult)
        {
            List<string> separatedStr = MainFunc.ProcessingFirstStr.SeparationText(firstStr);
            double actualResult = MainFunc.Calculate.CalculateExample(separatedStr);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataRow("5^1")]
        [DataRow("(5+6))")]
        [DataRow("5*/5")]
        [DataRow("5+-6")]
        [DataTestMethod]
        [ExpectedException(typeof(Exception))]
        public void SeparationText_setExample_getException(string firstStr)
        {
            List<string> separatedStr = MainFunc.ProcessingFirstStr.SeparationText(firstStr);
            MainFunc.Calculate.CalculateExample(separatedStr);
        }

        [DataRow("5/0")]
        [DataRow("(5+6)/(10-5*2)")]
        [DataRow("(591*21)/0*1")]
        [DataTestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void SeparationText_setExample_getDivideByZeroException(string firstStr)
        {
            List<string> separatedStr = MainFunc.ProcessingFirstStr.SeparationText(firstStr);
            MainFunc.Calculate.CalculateExample(separatedStr);
        }

        [DataRow(".5/10")]
        [DataRow("(5+6)/(.10-5*2)")]
        [DataRow("521*.")]
        [DataTestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SeparationText_setExample_getFormatException(string firstStr)
        {
            List<string> separatedStr = MainFunc.ProcessingFirstStr.SeparationText(firstStr);
            MainFunc.Calculate.CalculateExample(separatedStr);
        }
    }
}
