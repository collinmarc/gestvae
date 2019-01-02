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
            oDC1 = new DomaineCompetence(oDip,"DC1");
            oDC1.Numero = 1;

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
            ctx = new Context();

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
    }
}
