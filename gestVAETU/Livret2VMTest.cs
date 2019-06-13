using System;
using GestVAE.VM;
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
    }
}
