using System;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class LivretTest:RootTest
    {
        [TestMethod]
        public void TestCRUDTest()
        {
            int nId = 0;
            nId = oCand.ID;
            Livret1 oL1 = new Livret1();
            oL1.Numero ="20190115001";
            oL1.OrigineDemande = "COURIER";
            oL1.TypeDemande = "Courrier";

            oCand.lstLivrets1.Add(oL1);

            Livret2 oL2 = new Livret2();
            oL2.Numero = 1;
            oL2.OrigineDemande = "LIVRET2";
            oCand.lstLivrets2.Add(oL2);

            ctx.SaveChanges();

            ctx = Context.instance;
            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstLivrets1.Count);
            Assert.AreEqual(1, oCand.lstLivrets2.Count);



        }
        [TestMethod]
        public void TestCRUDLivret1Test()
        {
            int nId = 0;
            nId = oCand.ID;
            Livret1 oL1 = new Livret1();
            oL1.Numero = "20190115001";
            oL1.isContrat = false;
            oL1.TypeDemande = "Courrier";
            oL1.OrigineDemande = "site Ehesp";
            oL1.EtatLivret = "0-Demandé";

            oCand.lstLivrets1.Add(oL1);


            ctx.SaveChanges();

            ctx = Context.instance;
            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstLivrets1.Count);

            Livret1 oL2 = oCand.lstLivrets1[0];
            Assert.AreEqual(oL1.Numero, oL2.Numero);
            Assert.AreEqual(oL1.isContrat, oL2.isContrat);
            Assert.AreEqual(oL1.TypeDemande, oL2.TypeDemande);
            Assert.AreEqual(oL1.OrigineDemande, oL2.OrigineDemande);
            Assert.AreEqual(oL1.EtatLivret, oL2.EtatLivret);


        }
        [TestMethod]
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
        public void TestCRUDLivret1EchangeTest()
        {
            int nId = 0;
            nId = oCand.ID;
            Livret1 oL1 = new Livret1();
            oL1.Numero = "20190115001";

            EchangeL1 oECH = new EchangeL1("Demande de PJ");
            oL1.lstEchanges.Add(oECH);

            oCand.lstLivrets1.Add(oL1);


            ctx.SaveChanges();

            ctx = Context.instance;
            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstLivrets1.Count);

            oL1 = oCand.lstLivrets1[0];
            EchangeL1 oECH2 = oL1.lstEchanges[0];

            Assert.AreEqual(oECH2.MotifEch, oECH.MotifEch);
//            Assert.AreEqual(oECH2.DateEch, oECH.DateEch);
            Assert.AreEqual(oECH2.IsOK, oECH.IsOK);

        }
        [TestMethod]
        public void TestJury()
        {
            int nId = 0;
            nId = oCand.ID;
            Livret1 oL1 = new Livret1();
            oL1.Numero = "20190115001";
            oCand.lstLivrets1.Add(oL1);

            Jury oJ = new Jury();
            oJ.MotifGeneral = "MotifG";
            oJ.MotifDetail = "MotifD";
            oL1.lstJurys.Add(oJ);

            ctx.SaveChanges();

            ctx = Context.instance;
            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstLivrets1.Count);

            oL1 = oCand.lstLivrets1[0];
            Jury oJ2 = oL1.lstJurys[0];

            Assert.AreEqual(oJ.MotifGeneral, oJ2.MotifGeneral);
            //            Assert.AreEqual(oECH2.DateEch, oECH.DateEch);
            Assert.AreEqual(oJ.MotifDetail, oJ2.MotifDetail);

        }
    }
    }
