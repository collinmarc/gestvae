using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfMDS1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Student oSt = new Student();

            oSt.test(null);
        }
    }
}
