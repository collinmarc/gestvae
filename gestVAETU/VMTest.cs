using System;
using GestVAE.VM;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class VMTest
    {
        [TestMethod]
        public void CreateDeleteL1Test()
        {

            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
         
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;
            oLiv.IsRecoursDemande = true;
            oLiv.DateDepot = DateTime.Now;
            oLiv.DecisionJuryRecours = "TEST";
            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCAND").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(1, VM.CurrentCandidat.lstLivrets.Count);

            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            oLiv = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
            Assert.AreEqual("TEST", oLiv.DecisionJuryRecours);
            VM.CurrentCandidat.DeleteLivret();
            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCAND").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(0, VM.CurrentCandidat.lstLivrets.Count);

            VM.DeleteCandidat();

            VM.saveData();
            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCAND").FirstOrDefault();
            Assert.IsNull(VM.CurrentCandidat);



        }
        [TestMethod]
        public void CreateDeleteL2Test()
        {

            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCANDL2";

            VM.AjouteL2();
            VM.ValideretQuitterL2();

            Livret2VM oLiv = (Livret2VM)oCand.CurrentLivret;
            oLiv.DecisionJury = "DECISIONJURYL2";
            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCANDL2").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(1, VM.CurrentCandidat.lstLivrets.Count);

            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            oLiv = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.AreEqual("DECISIONJURYL2", oLiv.DecisionJury);
            VM.CurrentCandidat.DeleteLivret();
            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCANDL2").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(0, VM.CurrentCandidat.lstLivrets.Count);

            VM.DeleteCandidat();

            VM.saveData();
            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCANDL2").FirstOrDefault();
            Assert.IsNull(VM.CurrentCandidat);

        }

        [TestMethod]
        public void testhasChangesL1()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCANDL1";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.saveData();

            VM.getData();
            oCand = VM.lstCandidatVM.Where(c => c.Nom == "TESTCANDL1").FirstOrDefault<CandidatVM>();
            oCand.CurrentLivret = oCand.lstLivrets[0];

            Assert.IsFalse(oCand.CurrentLivret.HasChanges());

            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;

            oLiv.DateDemande = DateTime.Now;

            Assert.IsTrue(oLiv.HasChanges());
            VM.ResetL1();
            Assert.IsFalse( oLiv.HasChanges());
            Assert.AreEqual("", oLiv.DecisionJury);

            oCand.DeleteLivret();
            VM.DeleteCandidat();
            VM.saveData();

        }
        [TestMethod]
        public void testhasChangesL1JuriesRecours()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCANDL2";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.saveData();

            VM.getData();
            oCand = VM.lstCandidatVM.Where(c => c.Nom == "TESTCANDL2").FirstOrDefault<CandidatVM>();
            oCand.CurrentLivret = oCand.lstLivrets[0];


            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;

            Assert.IsFalse(oLiv.HasChanges());
            oLiv.DecisionJury = "TEST";

            Assert.IsTrue(oLiv.HasChanges());
            VM.ResetL1();
            Assert.IsFalse(oLiv.HasChanges());
            Assert.AreEqual("", oLiv.DecisionJury);

            oLiv.DecisionJuryRecours = "TEST2";
            Assert.IsTrue(oLiv.HasChanges());
            VM.ResetL1();
            Assert.IsFalse(oLiv.HasChanges());
            Assert.AreEqual("", oLiv.DecisionJuryRecours);

            oCand.DeleteLivret();
            VM.CurrentCandidat = oCand;
            VM.DeleteCandidat();
            VM.saveData();

        }
        [TestMethod]
        public void CreateDeleteOnCascade()
        {

            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";

            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.saveData();

            VM.getData();
            oCand = VM.lstCandidatVM.Where(c => c.Nom == "TESTCAND").LastOrDefault();
            Assert.AreEqual(1, oCand.lstLivrets.Count);
            oCand.CurrentLivret = oCand.lstLivrets[0];

            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;
            oLiv.IsRecoursDemande = true;
            oLiv.DateDepot = DateTime.Now;
            oLiv.DecisionJuryRecours = "TEST";
            Assert.IsTrue(VM.saveData());

            VM.saveData();
            VM.getData();
            oCand = VM.lstCandidatVM.Where(c => c.Nom == "TESTCAND").LastOrDefault();
            Assert.AreEqual(1, oCand.lstLivrets.Count);
            oCand.CurrentLivret = oCand.lstLivrets[0];
            oCand.DeleteLivret();

            VM.DeleteCandidat();
            Assert.IsTrue(VM.saveData());
        }
    }
}
