using System;
using GestVAE.VM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class Livret1VMTest

    {
        [TestMethod]
        public void TestAdd()
        {

            Livret1VM oL1 = new Livret1VM();
            Assert.AreNotEqual("", oL1.Numero);
            Livret1VM oL2 = new Livret1VM();
            Assert.AreNotEqual(oL2.Numero, oL1.Numero);

        }
    }
}
