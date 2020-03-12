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
            MyViewModel VM = new MyViewModel(true);
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
        [TestMethod]
        public void CRUDTest()
        {
            MyViewModel VM = new MyViewModel(true);
            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTADD";

            VM.saveData();
            VM.rechNom = "TESTADD";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            Assert.AreEqual("TESTADD", VM.CurrentCandidat.Nom);
            Assert.AreEqual("", VM.CurrentCandidat.Commentaire);
            VM.CurrentCandidat.Commentaire = "COMMENTAIRE";
            VM.CurrentCandidat.TypeCommentaire = GestVAEcls.TypeCommentaire.INFO;
            VM.saveData();

            VM.rechNom = "TESTADD";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            Assert.AreEqual("TESTADD", VM.CurrentCandidat.Nom);
            Assert.AreEqual("COMMENTAIRE", VM.CurrentCandidat.Commentaire);
            Assert.AreEqual(GestVAEcls.TypeCommentaire.INFO, VM.CurrentCandidat.TypeCommentaire);


            VM.DeleteCurrentCandidat();
            VM.saveData();

            VM.rechNom = "TESTADD";
            VM.Recherche();

            Assert.AreEqual(0, VM.lstCandidatVM.Count);


        }
    }
}
