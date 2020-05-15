using System;
using GestVAE.VM;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class LivretTest:RootTest
    {
        [TestMethod]
        public void TestCreationL1()
        {
            Livret1 oL1 = new Livret1();
            oL1.Numero = "20190115001";
            Assert.IsFalse(oL1.isClos);
            Assert.IsTrue(oL1.IsNonRecu);
            Assert.IsFalse(oL1.IsContrat);
            Assert.IsFalse(oL1.IsConvention);
            Assert.AreEqual(oL1.oDiplome.ID , Diplome.getDiplomeParDefaut().ID);
            Assert.IsFalse(oL1.IsCNIOK);
            Assert.IsNull(oL1.DateValiditeCNI);
            
        }
        [TestMethod,Ignore()]
        public void TestCRUDTest()
        {
            int nId = 0;
            nId = oCand.ID;
            Livret1 oL1 = new Livret1();
            oL1.Numero ="20190115001";
            oL1.VecteurInformation = "COURIER";
            oL1.TypeDemande = "Courrier";

            oCand.lstLivrets1.Add(oL1);

            Livret2 oL2 = new Livret2();
            oL2.Numero = "1";
            oCand.lstLivrets2.Add(oL2);

            ctx.SaveChanges();

            ctx = Context.instance;
            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstLivrets1.Count);
            Assert.AreEqual(1, oCand.lstLivrets2.Count);



        }
        [TestMethod,Ignore()]
        public void TestCRUDLivret1Test()
        {
            int nId = 0;
            nId = oCand.ID;
            Livret1 oL1 = new Livret1();
            oL1.Numero = "20190115001";
            oL1.IsContrat = false;
            oL1.TypeDemande = "Courrier";
            oL1.VecteurInformation = "site Ehesp";
            oL1.EtatLivret = "0-Demandé";
            oL1.Date1ereDemandePieceManquantes = new DateTime(2019, 05, 10);
            oL1.Date2emeDemandePieceManquantes = new DateTime(2019, 05, 11);
            oL1.DateDemande1erRetour = new DateTime(2019, 05, 12);
            oL1.DateDemande2emeRetour = new DateTime(2019, 05, 13);
            oL1.DateReceptionPiecesManquantes = new DateTime(2019, 05, 14);
            oL1.IsCNIOK = true;
            oL1.DateValiditeCNI = new DateTime(2020, 01, 21);

            oCand.lstLivrets1.Add(oL1);


            ctx.SaveChanges();

            ctx = Context.instance;
            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstLivrets1.Count);

            Livret1 oL1Lu = oCand.lstLivrets1[0];
            Assert.AreEqual(oL1.Numero, oL1Lu.Numero);
            Assert.AreEqual(oL1.IsContrat, oL1Lu.IsContrat);
            Assert.AreEqual(oL1.TypeDemande, oL1Lu.TypeDemande);
            Assert.AreEqual(oL1.VecteurInformation, oL1Lu.VecteurInformation);
            Assert.AreEqual(oL1.EtatLivret, oL1Lu.EtatLivret);
            Assert.AreEqual(oL1.Date1ereDemandePieceManquantes, oL1Lu.Date1ereDemandePieceManquantes);
            Assert.AreEqual(oL1.Date2emeDemandePieceManquantes, oL1Lu.Date2emeDemandePieceManquantes);
            Assert.AreEqual(oL1.DateDemande1erRetour, oL1Lu.DateDemande1erRetour);
            Assert.AreEqual(oL1.DateDemande2emeRetour, oL1Lu.DateDemande2emeRetour);
            Assert.AreEqual(oL1.DateReceptionPiecesManquantes, oL1Lu.DateReceptionPiecesManquantes);
            Assert.IsTrue(oL1Lu.IsCNIOK);
            Assert.AreEqual(oL1.DateValiditeCNI, oL1Lu.DateValiditeCNI);

            oL1Lu.IsCNIOK = false;
            oL1Lu.DateValiditeCNI = null;

            ctx.SaveChanges();
            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstLivrets1.Count);
             oL1Lu = oCand.lstLivrets1[0];
            Assert.IsFalse(oL1Lu.IsCNIOK);
            Assert.IsNull(oL1Lu.DateValiditeCNI);


        }
        [TestMethod,Ignore()]
        public void TestCRUDLivret2Test()
        {
            int nId = 0;
            nId = oCand.ID;
            Livret2 oL2a = new Livret2();
            oL2a.Numero = "20190115001";
            oL2a.IsContrat = false;
            oL2a.EtatLivret = "0-Demandé";
            oL2a.Date1ereDemandePieceManquantes = new DateTime(2019, 05, 10);
            oL2a.Date2emeDemandePieceManquantes = new DateTime(2019, 05, 11);
            oL2a.DateDemande1erRetour = new DateTime(2019, 05, 12);
            oL2a.DateDemande2emeRetour = new DateTime(2019, 05, 13);
            oL2a.DateReceptionPiecesManquantes = new DateTime(2019, 05, 14);

            oCand.lstLivrets2.Add(oL2a);


            ctx.SaveChanges();

            ctx = Context.instance;
            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstLivrets2.Count);

            Livret2 oL2Lu = oCand.lstLivrets2[0];
            Assert.AreEqual(oL2a.Numero, oL2Lu.Numero);
            Assert.AreEqual(oL2a.IsContrat, oL2Lu.IsContrat);
            Assert.AreEqual(oL2a.EtatLivret, oL2Lu.EtatLivret);
            Assert.AreEqual(oL2a.Date1ereDemandePieceManquantes, oL2Lu.Date1ereDemandePieceManquantes);
            Assert.AreEqual(oL2a.Date2emeDemandePieceManquantes, oL2Lu.Date2emeDemandePieceManquantes);
            Assert.AreEqual(oL2a.DateDemande1erRetour, oL2Lu.DateDemande1erRetour);
            Assert.AreEqual(oL2a.DateDemande2emeRetour, oL2Lu.DateDemande2emeRetour);
            Assert.AreEqual(oL2a.DateReceptionPiecesManquantes, oL2Lu.DateReceptionPiecesManquantes);


        }
        [TestMethod,Ignore()]
        public void TestCRUDLivret1PJTest()
        {
            int nId = 0;
            nId = oCand.ID;
            Livret1 oL1 = new Livret1();
            oL1.Numero = "20190115001";

            PieceJointeL1 oPJ = new PieceJointeL1();
            oPJ.Libelle = "CNI";
            oPJ.IsRecu = true;
            oPJ.IsOK = false;
            oL1.lstPiecesJointes.Add(oPJ);

            oCand.lstLivrets1.Add(oL1);


            ctx.SaveChanges();

            ctx = Context.instance;
            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstLivrets1.Count);

            oL1 = oCand.lstLivrets1[0];
            PieceJointeL1 oPJ2 = oL1.lstPiecesJointes[0];

            Assert.AreEqual(oPJ.Libelle, oPJ2.Libelle);
            Assert.AreEqual(oPJ.IsRecu, oPJ2.IsRecu);
            Assert.AreEqual(oPJ.IsOK, oPJ2.IsOK);

        }
         [TestMethod]
        public void TestJury()
        {
            MyViewModel VM = new MyViewModel(true);
            int nId = 0;
            nId = oCand.ID;
            VM.rechNom = oCand.Nom;
            VM.Recherche(true);
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            Livret1VM oL1 = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
            oL1.Numero = "20190115001";
            oL1.MotifGeneralJury = "MotifG";
            oL1.MotifDetailJury = "MotifD";
            VM.saveData();

            VM.rechNom = oCand.Nom;
            VM.Recherche(true);
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            oL1 = (Livret1VM)VM.CurrentCandidat.lstLivrets[0];

            Assert.AreEqual("MotifG", oL1.MotifGeneralJury);
            Assert.AreEqual("MotifD", oL1.MotifDetailJury);

        }
        [TestMethod]
        public void ValiderL2ValidationTotaleTest()
        {
            int nId = 0;
            nId = oCand.ID;
            Diplome oDipDefault = Diplome.getDiplomeParDefaut();
            Livret2 oL2 = new Livret2(oDipDefault);
            // Tous les DC sont a Valider
            foreach (DCLivret item in oL2.lstDCLivrets)
            {
                item.IsAValider = true;
            }
            oL2.create1erJury();
            oL2.oCandidat = oCand;
            oCand.lstLivrets2.Add(oL2);
            // Validation Complete
            oL2.get1erJury().Decision = "10-Favorable";
            foreach (DCLivret item in oL2.lstDCLivrets)
            {
                item.Decision = "10-Validé";
            }

            oL2.ValiderLivret2();

            Assert.AreEqual(1, oCand.lstDiplomes.Count);
            Assert.AreEqual("Validé", oCand.lstDiplomes[0].Statut);

        }//ValiderL2Test
        [TestMethod]
        public void ValiderL2ValidationPArtielleTest()
        {
            int nId = 0;
            nId = oCand.ID;
            Diplome oDipDefault = Diplome.getDiplomeParDefaut();
            Livret2 oL2 = new Livret2(oDipDefault);
            // Tous les DC sont a Valider
            foreach (DCLivret item in oL2.lstDCLivrets)
            {
                item.IsAValider = true;
            }
            oL2.create1erJury();
            oL2.oCandidat = oCand;
            oCand.lstLivrets2.Add(oL2);
            // Validation Complete
            oL2.get1erJury().Decision = "30-Validation Partielle";
            Boolean b1 = true;
            foreach (DCLivret item in oL2.lstDCLivrets)
            {
                if (b1)
                {
                    item.Decision = "10-Validé";
                    b1 = false;
                }
                else
                {
                    item.Decision = "20-Refusé";

                }
            }

            oL2.ValiderLivret2();

            Assert.AreEqual(1, oCand.lstDiplomes.Count);
            Assert.AreEqual("Validé partiellement", oCand.lstDiplomes[0].Statut);

        }//ValiderL2Test

        [TestMethod]
        public void ValiderL2ValidationRefuseTest()
        {
            int nId = 0;
            nId = oCand.ID;
            Diplome oDipDefault = Diplome.getDiplomeParDefaut();
            Livret2 oL2 = new Livret2(oDipDefault);
            // Tous les DC sont a Valider
            foreach (DCLivret item in oL2.lstDCLivrets)
            {
                item.IsAValider = true;
            }

            oL2.create1erJury();
            oL2.oCandidat = oCand;
            oCand.lstLivrets2.Add(oL2);
            // Refus de validation
            oL2.get1erJury().Decision = "20-Refusé";
            foreach (DCLivret item in oL2.lstDCLivrets)
            {
                    item.Decision = "20-Refusé";
            }

            oL2.ValiderLivret2();

            Assert.AreEqual(1, oCand.lstDiplomes.Count);
            Assert.AreEqual("Refusé", oCand.lstDiplomes[0].Statut);

        }//ValiderL2ValidationRefuseTest

        [TestMethod]
        public void ValiderL2ValidationEcoursTest()
        {
            int nId = 0;
            nId = oCand.ID;
            Diplome oDipDefault = Diplome.getDiplomeParDefaut();
            Livret2 oL2 = new Livret2(oDipDefault);
            oL2.create1erJury();
            oL2.oCandidat = oCand;
            oCand.lstLivrets2.Add(oL2);

            oL2.ValiderLivret2();

            Assert.AreEqual(1, oCand.lstDiplomes.Count);
            Assert.AreEqual("En cours", oCand.lstDiplomes[0].Statut);

        }//ValiderL2ValidationRefuseTest
    }

}
