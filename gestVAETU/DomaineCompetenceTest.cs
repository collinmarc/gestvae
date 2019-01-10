using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestVAEcls;
using System.Linq;

namespace GestVAETU
{
    [TestClass]
    public class DomaineComptenceTest:RootTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            base.Setup();
        }
        [TestMethod]
        public void TestCRUDDomComp()
        {

            Int32 nDCAvant = ctx.DomainesCompetences.Count<DomaineCompetence>();
            DomaineCompetence oDC1;
            DomaineCompetence oDC2;
            oDC1 = new DomaineCompetence("DC1");
            oDC1.Numero = 1;
            oDip.lstDomainesCompetences.Add(oDC1);
            ctx.DomainesCompetences.Add(oDC1);

            ctx.SaveChanges();

            oDC1 = ctx.DomainesCompetences.First<DomaineCompetence>();

            Int32 nId = oDC1.ID;

            oDC2 = (from obj in ctx.DomainesCompetences
                     where (obj.ID == nId) && (!obj.bDeleted)
                     select obj).First<DomaineCompetence>();
            Assert.AreEqual(oDC1.Nom, oDC2.Nom);
            Assert.AreEqual(oDC1.Numero, oDC2.Numero);

            oDC2.Nom = "DC2";
            oDC1.Numero = 2;

            ctx.SaveChanges();
            ctx = Context.instance;

            oDC1 = (from obj in ctx.DomainesCompetences
                     where (obj.ID == nId) && (!obj.bDeleted)
                     select obj).First<DomaineCompetence>();
            Assert.AreEqual(oDC2.Nom, oDC1.Nom);
            Assert.AreEqual(oDC2.Numero, oDC1.Numero);


            ctx.DomainesCompetences.Remove(oDC1);

            ctx.SaveChanges();

            int nDomaineCompetence = (from obj in ctx.DomainesCompetences select obj).Count<DomaineCompetence>();

            Assert.AreEqual(nDCAvant, nDomaineCompetence);


        }
        [TestMethod]
        public void TestAjoutDiplome()
        {
            DiplomeCand oDipC = oCand.AddDiplome(oDip);
            
            Diplome oDipDefaut = Diplome.getDiplomeParDefaut();

            Assert.AreEqual(oDip.ID, oDipC.oDiplome.ID);
        }
        [TestMethod]
        public void TestAjoutDiplomePArDefaut()
        {

            int nId = oCand.ID;
            Diplome oDipDefaut = Diplome.getDiplomeParDefaut();
            DiplomeCand oDipC = oCand.AddDiplome(oDipDefaut);


            Assert.IsNotNull(oDipDefaut);
            Assert.AreEqual(oDipDefaut.ID, oDipC.oDiplome.ID);
            Assert.AreEqual(oDipDefaut.lstDomainesCompetences.Count, oDipC.lstDCCands.Count);
            Assert.AreEqual(1, oCand.lstDiplomes.Count);

            ctx.SaveChanges();
            ctx = Context.instance;

            oCand = ctx.Candidats.Find(nId);
            Assert.AreEqual(1, oCand.lstDiplomes.Count);
            Assert.AreEqual(oDipDefaut.ID, oCand.lstDiplomes[0].oDiplome.ID);
            Assert.AreEqual(oDipDefaut.lstDomainesCompetences.Count, oCand.lstDiplomes[0].oDiplome.lstDomainesCompetences.Count);

        }
    }
}
