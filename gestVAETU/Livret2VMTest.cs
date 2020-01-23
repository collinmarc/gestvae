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

        public void testDCAValider()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;

            VM.AjouteL1();
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.FTO_SetDecisionJuryL1Favorable();
            VM.ValideretQuitterL1();
            VM.saveData();
            VM.AjouteL2();
            Livret2VM oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.IsTrue(oL2.lstDCLivret[0].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[1].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[2].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[3].IsAValider);

            oL2.FTO_SetDecisionJuryL2Partielle();
            oL2.lstDCLivret[0].Decision = oL2.DecisionL2ModuleFavorable;
            oL2.lstDCLivret[1].Decision = oL2.DecisionL2ModuleDeFavorable;
            oL2.lstDCLivret[2].Decision = oL2.DecisionL2ModuleFavorable;
            oL2.lstDCLivret[3].Decision = oL2.DecisionL2ModuleDeFavorable;
            VM.ValideretQuitterL2();
            VM.saveData();

            // test de l'état des DCCand
            Assert.AreEqual("Validé", oCand.lstDiplomesCandVMs[0].StatutDC1);
            Assert.AreEqual("Refusé", oCand.lstDiplomesCandVMs[0].StatutDC2);
            Assert.AreEqual("Validé", oCand.lstDiplomesCandVMs[0].StatutDC1);
            Assert.AreEqual("Refusé", oCand.lstDiplomesCandVMs[0].StatutDC4);

            VM.AjouteL2();
            oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.IsFalse(oL2.lstDCLivret[0].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[1].IsAValider);
            Assert.IsFalse(oL2.lstDCLivret[2].IsAValider);
            Assert.IsTrue(oL2.lstDCLivret[3].IsAValider);
            oL2.FTO_SetDecisionJuryL2Partielle();

            oL2.lstDCLivret[1].Decision = oL2.DecisionL2ModuleFavorable;
            oL2.lstDCLivret[3].Decision = oL2.DecisionL2ModuleDeFavorable;
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
            oL2.FTO_SetDecisionJuryL2Partielle();
            oL2.lstDCLivret[3].Decision = oL2.DecisionL2ModuleFavorable;
            VM.ValideretQuitterL2();
            VM.saveData();
        }
    }
}
