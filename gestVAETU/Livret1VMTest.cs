using System;
using GestVAE.VM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class Livret1VMTest

    {
        [TestMethod]
        public void TestNumerotationDeLivret()
        {

            // Création du premierLivret
            Livret1VM oL1 = new Livret1VM(false);
            Assert.IsTrue(String.IsNullOrEmpty(oL1.Numero));
            oL1.EtatLivret = String.Format("{0:D}-Reçu incomplet", MyEnums.EtatL1.ETAT_L1_RECU_INCOMPLET);
            // Le numéro est calculé lors de la réception
            Assert.IsFalse(String.IsNullOrEmpty(oL1.Numero));
            Assert.AreEqual(DateTime.Now.ToString("yyMM"), oL1.Numero.Substring(0, 4));
            Int32 Num1 = Convert.ToInt32(oL1.Numero.Substring(4));

            // Création d'un second Livret
            Livret1VM oL2 = new Livret1VM(false);
            oL2.EtatLivret = String.Format("{0:D}-Reçu incomplet", MyEnums.EtatL1.ETAT_L1_RECU_INCOMPLET);

            // Les numéros sont bien différents
            Assert.AreNotEqual(oL1.Numero, oL2.Numero);
            Int32 Num2 = Convert.ToInt32(oL2.Numero.Substring(4));

            Assert.AreEqual(Num1 + 1, Num2);

        }
        [TestMethod]
        public void TestDateDeValiditéL1()
        {

            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;

            VM.AjouteL1();
            VM.ValideretQuitterL1();

            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;

            Assert.AreEqual(oL1.DateDemande.Value.AddYears(3), oL1.DateValidite);
            oL1.EtatLivret = String.Format("{0:D}-RecuComplet", MyEnums.EtatL1.ETAT_L1_RECU_COMPLET);
            Assert.AreEqual(oL1.DateDemande.Value.AddYears(3), oL1.DateValidite);
            oL1.DateJury = (DateTime.Now.AddDays(2));
            oL1.DecisionJury = String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE);
            Assert.AreEqual(oL1.DateJury.Value.AddYears(3), oL1.DateValidite);
            oL1.DecisionJury = String.Format("{0:D}-Defavorable", MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
            Assert.AreEqual(oL1.DateJury, oL1.DateValidite);
            oL1.IsRecoursDemande = true;
            oL1.DateJuryRecours = oL1.DateJury.Value.AddDays(5);
            oL1.DecisionJuryRecours = String.Format("{0:D}-Defavorable", MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
            Assert.AreEqual(oL1.DateJury, oL1.DateValidite);
            oL1.DecisionJuryRecours = String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE);
            Assert.AreEqual(oL1.DateJuryRecours.Value.AddYears(3), oL1.DateValidite);


        }
    }
}
