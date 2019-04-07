using System;
using GestVAE.VM;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class ValidationTest:RootTest
    {
        [TestMethod]
        public void GESTVAE001()
        {
            MyViewModel VM = new MyViewModel();

            VM.rechNom = "TEST1";
            VM.Recherche();
            Assert.AreEqual(0, VM.lstCandidatVM.Count);

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";

            VM.saveData();
             VM = new MyViewModel();

            VM.rechNom = "TEST1";
            VM.Recherche();
            Assert.AreEqual(1, VM.lstCandidatVM.Count);

        }
        [TestMethod]
        public void GESTVAE002()
        {
            MyViewModel VM = new MyViewModel();

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel();
            VM.rechNom = "TEST1";
            VM.Recherche();
            Assert.AreEqual(1, VM.lstCandidatVM.Count);

            oCan = VM.lstCandidatVM[0];
            Assert.IsTrue(oCan.IsUnlocked);
            oCan.Lock();
            Assert.IsTrue(oCan.IsLocked);
            oCan.IdSiscole = "123456";
            VM.saveData();
            Assert.IsTrue(oCan.IsUnlocked);

            VM.rechNom = "TEST1";
            VM.Recherche();
            Assert.AreEqual(1, VM.lstCandidatVM.Count);

            oCan = VM.lstCandidatVM[0];
            Assert.IsTrue(oCan.IsUnlocked);
            Assert.AreEqual("123456",oCan.IdSiscole );



        }
    }
}
