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
            oL1.FTO_SetDecisionJuryL1Favorable(DateTime.Today.AddDays(2));
            Assert.AreEqual(oL1.DateJury.Value.AddYears(3), oL1.DateValidite);
            oL1.FTO_SetDecisionJuryL1DeFavorable(DateTime.Today.AddDays(2));
            Assert.AreEqual(oL1.DateJury, oL1.DateValidite);
            oL1.IsRecoursDemande = true;
            oL1.DateJuryRecours = oL1.DateJury.Value.AddDays(5);
            oL1.DecisionJuryRecours = String.Format("{0:D}-Defavorable", MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE);
            Assert.AreEqual(oL1.DateJury, oL1.DateValidite);
            oL1.DecisionJuryRecours = String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE);
            Assert.AreEqual(oL1.DateJuryRecours.Value.AddYears(3), oL1.DateValidite);


        }
        /// <summary>
        /// 0000941: L2 : La Date Limite de réception = Date de validité du L1.
        /// </summary>
        [TestMethod]
        [TestCategory("#941")]
        public void TestDateDeValiditéL1L2()
        {

            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;

            VM.AjouteL1();
            VM.ValideretQuitterL1();

            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            // Jury = Après-demain
            oL1.FTO_SetDecisionJuryL1Favorable(DateTime.Today.AddDays(2));

            VM.CloturerL1etCreerL2();
            Assert.IsTrue(VM.CurrentCandidat.CurrentLivret is Livret2VM);
            Assert.AreEqual(oL1.DateValidite, ((Livret2VM)VM.CurrentCandidat.CurrentLivret).DateLimiteReceptEHESP);



        }
        /// <summary>
        /// 	0000996: L1: Date de recevalivité doit être à NULL par defaut.
        /// </summary>
        [TestMethod]
        [TestCategory("#996")]
        public void TestDateDeRecevabilite()
        {

            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;

            VM.AjouteL1();
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.EtatLivret = String.Format("{0:D}-Recu complet", MyEnums.EtatL1.ETAT_L1_RECU_COMPLET);
            VM.ValideretQuitterL1();

             oL1 = (Livret1VM)oCand.CurrentLivret;
            Assert.IsNull(oL1.DateJury);
            Assert.IsNull(oL1.DateDepotRecours);



        }
        [TestMethod]
        [TestCategory("#1103")]
        public void TestDateDeRecevabilitechangeAvecDatenotificationjury()
        {
            DateTime dateV1 = DateTime.Today.AddDays(10);
            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;

            VM.AjouteL1();
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.EtatLivret = String.Format("{0:D}-Recu complet", MyEnums.EtatL1.ETAT_L1_RECU_COMPLET);
            oL1.DateValidite = dateV1;
            oL1.DateNotificationJury = DateTime.Today.AddDays(1);
            Assert.AreNotEqual(dateV1,oL1.DateValidite);
        }

        [TestMethod]
        [TestCategory("#1158")]
        [TestCategory("#1159")]
        public void TestCreationL2()
        {

            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;

            VM.AjouteL1();
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.EtatLivret = String.Format("{0:D}-Recu complet", MyEnums.EtatL1.ETAT_L1_RECU_COMPLET);
            oL1.FTO_SetDecisionJuryL1Favorable(); 
            VM.ValideretQuitterL1();
            Assert.AreEqual(1, oCand.lstLivrets.Count);

            oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.IsCNIOK = true;
            oL1.DateValiditeCNI = new DateTime(2020,01,01) ;
            oL1.IsEnregistre = true;
            oL1.IsPaye = true;
            VM.AjouteL2();
            VM.ValideretQuitterL2();
            Assert.AreEqual(2, oCand.lstLivrets.Count);

            Livret2VM oL2 = (Livret2VM)oCand.lstLivrets[1];

            Assert.AreEqual(oL1.IsCNIOK, oL2.IsCNIOK);
            Assert.AreEqual(oL1.DateValiditeCNI, oL2.DateValiditeCNI);
            Assert.AreEqual(oL1.IsEnregistre, oL2.IsEnregistre);
            Assert.AreEqual(oL1.IsPaye, oL2.IsPaye);


        }
    }
}
