using System;
using GestVAE.VM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class CandidatVMTest:RootTest
    {
        [TestMethod]
        public void CreateTest()
        {

            MyViewModel VM = new MyViewModel();
            VM.AddCandidatCommand.Execute(null);
            Assert.AreEqual("Française", VM.CurrentCandidat.Nationnalite);
            Assert.AreEqual("Française", VM.CurrentCandidat.NationnaliteNaissance);

        }
        [TestMethod]
        public void AddDiplomeTest()
        {
            MyViewModel VM = new MyViewModel();
            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTADDIPLOME";
            oCand.AjoutDiplomeCand();

            VM.saveData();
            VM.rechNom = "TESTADDIPLOME";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            Assert.AreEqual(1, VM.CurrentCandidat.lstDiplomesCandVMs.Count);

        }
    }
}
