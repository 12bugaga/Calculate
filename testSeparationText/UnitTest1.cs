using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testSeparationText
{
    [TestClass]
    public class Test_Calculator
    {
        [DataRow("5+2", "5+2")]
        [DataRow("532+550", "532+550")]
        [DataRow("-9+10", "+0-9+10")]
        [DataRow("(10+6)-5", "(10+6)+0-5")]
        [DataTestMethod]
        public void SeparationText_setExample_getExample(string firstStr, string expectedStr)
        {
            string actualStr= MainFunc.Calculator.SeparationText(firstStr);

            Assert.AreEqual(expectedStr, actualStr);
        }
    }
}
