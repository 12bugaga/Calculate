using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProcessingWithFirstStr
{
    [TestClass]
    public class TestSeparationText
    {
        
        [DataRow("5^1")]
        [DataRow("(5+6))")]
        [DataRow("5*/5")]
        [DataRow("5+-6")]
        [DataTestMethod]
        [ExpectedException(typeof(Exception))]
        public void SeparationText_setExample_getException(string firstStr)
        {
            MainFunc.ProcessingFirstStr workWIthFirstString = new MainFunc.ProcessingFirstStr();
            List<string> separatedStr = workWIthFirstString.SeparationText(firstStr);
            var calculator = new MainFunc.Calculate();
            calculator.CalculateExample(separatedStr);
        }

        [DataRow("5/0")]
        [DataRow("(5+6)/(10-5*2)")]
        [DataRow("(591*21)/0*1")]
        [DataTestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void SeparationText_setExample_getDivideByZeroException(string firstStr)
        {
            MainFunc.ProcessingFirstStr workWIthFirstString = new MainFunc.ProcessingFirstStr();
            List<string> separatedStr = workWIthFirstString.SeparationText(firstStr);
            var calculator = new MainFunc.Calculate();
            calculator.CalculateExample(separatedStr);
        }

        [DataRow(".5/10")]
        [DataRow("(5+6)/(.10-5*2)")]
        [DataRow("521*.")]
        [DataTestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SeparationText_setExample_getFormatException(string firstStr)
        {
            MainFunc.ProcessingFirstStr workWIthFirstString = new MainFunc.ProcessingFirstStr();
            List<string> separatedStr = workWIthFirstString.SeparationText(firstStr);
            var calculator = new MainFunc.Calculate();
            calculator.CalculateExample(separatedStr);
        }
        
    }
}
