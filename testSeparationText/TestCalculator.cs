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
        public void SeparationText_setExample_getAnswer(string firstStr, double expectedResult)
        {
            MainFunc.ProcessingFirstStr workWIthFirstString = new MainFunc.ProcessingFirstStr();
            List<string> separatedStr = workWIthFirstString.SeparationText(firstStr);
            var calculator = new MainFunc.Calculate();
            double actualResult = calculator.CalculateExample(separatedStr);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
