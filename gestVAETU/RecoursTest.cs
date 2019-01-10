using System;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class RecoursTest : RootTest
    {
        [TestMethod]
        public void TestCRUDRecoursTest()
        {
            int nId = 0;

            Livret1 oL1 = new Livret1();
            oCand.lstLivrets1.Add(oL1);
            ctx.SaveChanges();

            Recours oRec = new Recours();
            oRec.DateDepot = Convert.ToDateTime("10/01/2019");
            oRec.TypeRecours = EnumTypeRecours.Contentieux;
            oRec.MotifRecours = "AAAA";
            oRec.NomJury = "BBBB";
            oRec.Decision = "Accepté";

            oL1.lstRecours.Add(oRec);
            ctx.SaveChanges();

            nId = oCand.ID;
            Context.Reset();

            ctx = Context.instance;

            oCand = ctx.Candidats.Find(nId);
            oL1 = oCand.lstLivrets1[0];
            Assert.AreEqual(1, oL1.lstRecours.Count);

            Recours oRec2 = oL1.lstRecours[0];

            Assert.AreEqual(oRec.ID, oRec2.ID);
            Assert.AreEqual(oRec.DateDepot, oRec2.DateDepot);
            Assert.AreEqual(oRec.TypeRecours, oRec2.TypeRecours);
            Assert.AreEqual(oRec.MotifRecours, oRec2.MotifRecours);
            Assert.AreEqual(oRec.NomJury, oRec2.NomJury);
            Assert.AreEqual(oRec.Decision, oRec2.Decision);




        }
    }
}
