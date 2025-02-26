using System;
using GestVAE.VM;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class Livret2VMTest

    {
        /// <summary>
        /// 	0000996: L1: Date de recevalivité doit être à NULL par defaut.
        /// </summary>
        [TestMethod]
        [TestCategory("#1002")]
        public void TestDatePrevionnelleJury()
        {

            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;

            VM.AjouteL1();
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.FTO_SetDecisionJuryL1Favorable();
            VM.ValideretQuitterL1();
            VM.AjouteL2();

            Livret2VM oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            oL2.DatePrevJury1 = DateTime.Today;
            Assert.AreEqual(DateTime.Today.AddDays(1), oL2.DatePrevJury2);



        }
        /// <summary>
        /// 0001103: Chgmt date de recevabilité du L2 :
        /// </summary>
        [TestMethod]
        [TestCategory("#1103")]
        public void TestchgmtDateValiditesurdatenotifJury()
        {

            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;

            VM.AjouteL1();
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.DateValidite = DateTime.Today.AddDays(10);
            oL1.FTO_SetDecisionJuryL1Favorable();
            VM.ValideretQuitterL1();
            VM.saveData();
            VM.AjouteL2();
            Livret2VM oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.AreEqual(oL1.DateValidite, oL2.DateValidite);
            oL2.DateNotificationJury = DateTime.Today;
            Assert.AreEqual(oL1.DateValidite, oL2.DateValidite);

        }
        /// <summary>
        /// 1040 : Les DC non Validés du L2 diovent être mis AValider
        /// </summary>
        [TestMethod]
        [TestCategory("#1040")]
        [TestCategory("#1278")]

        public void testDCAValider()
        {
            MyViewModel VM = new MyViewModel(true);
            //Ajout d'un candidat avec un L1 Favorable
            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;
            VM.AjouteL1();
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.FTO_SetDecisionJuryL1Favorable();
            VM.ValideretQuitterL1();
            VM.saveData();

            // Ajout D'un L2
            VM.AjouteL2();
            Livret2VM oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.IsTrue(oL2.lstDCLivret[0].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[1].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[2].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[3].IsAValider);
            Assert.AreEqual("En Cours", oL2.lstDCLivret[0].Statut);
            Assert.AreEqual("En Cours", oL2.lstDCLivret[1].Statut);
            Assert.AreEqual("En Cours", oL2.lstDCLivret[2].Statut);
            Assert.AreEqual("En Cours", oL2.lstDCLivret[3].Statut);

            // Validation partielle du L2
            oL2.FTO_SetDecisionJuryL2Partielle();
            oL2.lstDCLivret[0].Decision = Livret2VM.DecisionDCFavorable;
            oL2.lstDCLivret[1].Decision = Livret2VM.DecisionL2DCDefavorable;
            oL2.lstDCLivret[2].Decision = Livret2VM.DecisionDCFavorable;
            oL2.lstDCLivret[3].Decision = Livret2VM.DecisionL2DCDefavorable;
            VM.ValideretQuitterL2();
            VM.saveData();

            // test de l'état des DCCand après Décision du jury
            Assert.AreEqual("Validé", oCand.lstDiplomesCandVMs[0].StatutDC1);
            Assert.AreEqual("Refusé", oCand.lstDiplomesCandVMs[0].StatutDC2);
            Assert.AreEqual("Validé", oCand.lstDiplomesCandVMs[0].StatutDC1);
            Assert.AreEqual("Refusé", oCand.lstDiplomesCandVMs[0].StatutDC4);

            // Création d'un nouveau L2
            VM.AjouteL2();
            oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.IsFalse(oL2.lstDCLivret[0].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[1].IsAValider);
            Assert.IsFalse(oL2.lstDCLivret[2].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[3].IsAValider);
            Assert.AreEqual("Validé", oL2.lstDCLivret[0].Statut);
            Assert.AreEqual("Refusé", oL2.lstDCLivret[1].Statut);
            Assert.AreEqual("Validé", oL2.lstDCLivret[2].Statut);
            Assert.AreEqual("Refusé", oL2.lstDCLivret[3].Statut);

            // Validation PArtielle du L2
            oL2.FTO_SetDecisionJuryL2Partielle();
            oL2.lstDCLivret[1].Decision = Livret2VM.DecisionDCFavorable;
            oL2.lstDCLivret[3].Decision = Livret2VM.DecisionL2DCDefavorable;
            VM.ValideretQuitterL2();
            VM.saveData();
            // test de l'état des DCCand
            Assert.AreEqual("Validé", oCand.lstDiplomesCandVMs[0].StatutDC1);
            Assert.AreEqual("Validé", oCand.lstDiplomesCandVMs[0].StatutDC2);
            Assert.AreEqual("Validé", oCand.lstDiplomesCandVMs[0].StatutDC1);
            Assert.AreEqual("Refusé", oCand.lstDiplomesCandVMs[0].StatutDC4);

            VM.AjouteL2();
            oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.IsFalse(oL2.lstDCLivret[0].IsAValider);
            Assert.IsFalse(oL2.lstDCLivret[1].IsAValider);
            Assert.IsFalse(oL2.lstDCLivret[2].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[3].IsAValider);
            Assert.AreEqual("Validé", oL2.lstDCLivret[0].Statut);
            Assert.AreEqual("Validé", oL2.lstDCLivret[1].Statut);
            Assert.AreEqual("Validé", oL2.lstDCLivret[2].Statut);
            Assert.AreEqual("Refusé", oL2.lstDCLivret[3].Statut);
            oL2.FTO_SetDecisionJuryL2Partielle();
            oL2.lstDCLivret[3].Decision = Livret2VM.DecisionDCFavorable;
            VM.ValideretQuitterL2();
            VM.saveData();
        }
    }
}
