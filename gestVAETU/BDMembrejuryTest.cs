using System;
using System.Collections.Generic;
using GestVAE.VM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class BDMembrejuryTest
    {
        [TestMethod]
        /// Test du chargement de la base
        public void LoadTest()
        {
            List<BDMembreJury> olst;
            olst = BDMembreJury.loadFrom("./BD Globale convertie Jurés en fonction .csv");
            Assert.AreNotEqual(0, olst.Count);
            BDMembreJury oBDMembre = olst[0];
            Assert.AreEqual("promo 10", oBDMembre.PROMO);
            Assert.AreEqual("SALARIE", oBDMembre.College_membre);
            Assert.AreEqual("Adolescence - Jeunes Adultes handicapés", oBDMembre.Secteur_activite);
        }
        [TestMethod]
        /// Test du chargement de la base
        public void FormatEHESPTest()
        {
            List<BDMembreJury> olst;
            olst = BDMembreJury.loadFrom("./BD Globale convertie Jurés en fonction (EHESP)" +
                ".csv");
            Assert.AreNotEqual(0, olst.Count);
            BDMembreJury oBDMembre = olst[1];
            Assert.AreEqual("Promo 8", oBDMembre.PROMO);
            Assert.AreEqual("ARRIVÉ", oBDMembre.Nom);
            Assert.AreEqual("représentant de l'Etat ou d'une collectivité territoriale ou personne qualifiée", oBDMembre.College_membre);
            Assert.AreEqual("Bretagne", oBDMembre.Region);
        }
    }
}
