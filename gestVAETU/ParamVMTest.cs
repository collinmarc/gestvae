using System;
using GestVAE.VM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class ParamTest
    {
        [TestMethod]
        public void TestIncrementNumLivret()
        {
            Int32 nNumLivret = ParamVM.incrementLivret();
            Int32 nNumLivret2 = ParamVM.incrementLivret();

            Assert.AreEqual(nNumLivret + 1, nNumLivret2);
            nNumLivret = ParamVM.incrementLivret();
            Assert.AreEqual(nNumLivret2 + 1, nNumLivret);
        }
    }
}
