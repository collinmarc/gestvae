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
    }
}
