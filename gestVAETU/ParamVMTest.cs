using System;
using GestVAE.VM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class ParamTest:RootTest
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
        [TestMethod]
        public void TestIncrementNumCandidat()
        {
            Int32 nNumCand = ParamVM.incrementCandidat();
            Int32 nNumCand2 = ParamVM.incrementCandidat();

            Assert.AreEqual(nNumCand + 1, nNumCand2);
            nNumCand = ParamVM.incrementCandidat();
            Assert.AreEqual(nNumCand2 + 1, nNumCand);
        }
        [TestMethod]
        public void getNumCandidat()
        {
            MyViewModel VM = new MyViewModel();
            Int32 NumCand = VM.ParamNumCandidat;

            ParamVM.incrementCandidat();
            SaveChanges();
            Int32 NumCand2 = VM.ParamNumCandidat;

            Assert.AreEqual(NumCand + 1, NumCand2);
        }
    }
}
