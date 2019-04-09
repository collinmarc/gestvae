using System;
using GestVAE.VM;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class VMTest : RootTest
    {
        [TestMethod]
        [TestCategory("VMTest"), TestCategory("Validation")]
        public void CreateDeleteL1Test()
        {

            MyViewModel VM = new MyViewModel(true);
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
            VM.CurrentCandidat.DeleteCurrentLivret();
            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCAND").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(0, VM.CurrentCandidat.lstLivrets.Count);
            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();

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
            VM.CurrentCandidat.DeleteCurrentLivret();
            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCANDL2").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(0, VM.CurrentCandidat.lstLivrets.Count);

            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();

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
            VM.CurrentCandidat = oCand;
            oCand.CurrentLivret = oCand.lstLivrets[0];

            Assert.IsFalse(oCand.CurrentLivret.HasChanges());

            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;

            oLiv.DateDemande = DateTime.Now;

            Assert.IsTrue(oLiv.HasChanges());
            VM.ResetCurrentLivret();
            Assert.IsFalse(oLiv.HasChanges());
            Assert.AreEqual("", oLiv.DecisionJury);

            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
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
            VM.CurrentCandidat = oCand;
            oCand.CurrentLivret = oCand.lstLivrets[0];


            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;

            Assert.IsFalse(oLiv.HasChanges());
            oLiv.DecisionJury = "TEST";

            Assert.IsTrue(oLiv.HasChanges());
            VM.ResetCurrentLivret();
            Assert.IsFalse(oLiv.HasChanges());
            Assert.AreEqual("", oLiv.DecisionJury);

            oLiv.DecisionJuryRecours = "TEST2";
            Assert.IsTrue(oLiv.HasChanges());
            VM.ResetCurrentLivret();
            Assert.IsFalse(oLiv.HasChanges());
            Assert.AreEqual("", oLiv.DecisionJuryRecours);

            VM.CurrentCandidat = oCand;
            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
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
            Assert.IsTrue(VM.SetCurrentCandidat("TESTCAND"));
            oCand = VM.CurrentCandidat;
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
            oCand.DeleteCurrentLivret();

            VM.LockCurrentCandidat();

            VM.DeleteCurrentCandidat();
            Assert.IsTrue(VM.saveData());
        }
        [TestMethod]
        public void testCreateL2()
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
            Assert.IsTrue(VM.SetCurrentCandidat("TESTCAND"));
            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            VM.CloturerL1etCreerL2();

            Livret2VM oLiv = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.AreEqual(4, oLiv.lstDCLivret.Count);

            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();


        }

        [TestMethod]
        public void testLock()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.AddCandidatCommand.Execute(null);
            oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND2";
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.saveData();
            VM.getData();

            VM.SetCurrentCandidat("TESTCAND");
            oCand = VM.CurrentCandidat;
            Assert.IsFalse(oCand.IsLocked);

            VM.LockCurrentCandidat();

            Assert.IsTrue(oCand.IsLocked);
            Assert.IsFalse(oCand.IsUnlocked);

            VM.getData();
            Assert.IsTrue(oCand.IsLocked);
            Assert.IsFalse(oCand.IsUnlocked);


            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();
        }
        [TestMethod]
        public void testLockVM()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.AddCandidatCommand.Execute(null);
            oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND2";
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.saveData();
            VM.getData();

            VM.SetCurrentCandidat("TESTCAND");
            oCand = VM.CurrentCandidat;
            Assert.IsFalse(oCand.IsLocked);

            VM.LockCurrentCandidat();

            Assert.IsTrue(oCand.IsLocked);

            VM.getData();
            VM.SetCurrentCandidat("TESTCAND");
            oCand = VM.CurrentCandidat;
            Assert.IsTrue(oCand.IsLocked);
            CandidatVM oCand2 = VM.lstCandidatVM.Where(c => c.Nom == "TESTCAND2").FirstOrDefault();
            Assert.IsFalse(oCand2.IsLocked);

            VM.saveData();
            VM.SetCurrentCandidat("TESTCAND");
            oCand = VM.CurrentCandidat;
            Assert.IsFalse(oCand.IsLocked);

            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();
        }
        [TestMethod]
        public void testIsL1Valide()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            VM.saveData();

            Assert.IsFalse(oCand.IsL1Valide);
            //Ajout D'un L1
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            // Le L1 Rest non valide car l'état n'est pas bon
            Assert.IsFalse(oCand.IsL1Valide);
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.EtatLivret = String.Format("{0:D}-Accepté", MyEnums.EtatL1.ETAT_L1_ACCEPTE);
            oL1.DateValidite = DateTime.Now.AddYears(3);
            // Le L1 Devient Valide
            Assert.IsTrue(oCand.IsL1Valide);
            oL1.DateValidite = DateTime.Now.AddDays(1);
            // Le L1 Reste Valide à 1 jour de l'échéance
            Assert.IsTrue(oCand.IsL1Valide);

            // Le L1 n'est plus valide
            oL1.DateValidite = DateTime.Now.AddDays(-1);
            Assert.IsFalse(oCand.IsL1Valide);


            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();
        }
    }
}
