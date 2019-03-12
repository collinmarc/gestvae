using System;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class DCLivretTest:RootTest
    {
        [TestMethod]
        public void TestCRUDDCLivret()
        {
            Int32 nIDCand = oCand.ID;
            Assert.AreEqual(4, oDip.lstDomainesCompetences.Count);
            Livret2 oLiv = new Livret2(oDip);
            oCand.lstLivrets2.Add(oLiv);

            Assert.AreEqual(4, oLiv.lstDCLivrets.Count);
            Assert.AreEqual(oDip.lstDomainesCompetences[0].ID, oLiv.lstDCLivrets[0].oDomaineCompetence.ID);
            Assert.AreEqual(oDip.lstDomainesCompetences[1].ID, oLiv.lstDCLivrets[1].oDomaineCompetence.ID);
            Assert.AreEqual(oDip.lstDomainesCompetences[2].ID, oLiv.lstDCLivrets[2].oDomaineCompetence.ID);
            Assert.AreEqual(oDip.lstDomainesCompetences[3].ID, oLiv.lstDCLivrets[3].oDomaineCompetence.ID);

            ctx.SaveChanges();
            Context.Reset();
            ctx = Context.instance;

             oCand = ctx.Candidats.Find(nIDCand);
            Livret2 oLiv2 = oCand.lstLivrets2[0];

            Assert.AreEqual(4, oLiv2.lstDCLivrets.Count);
            Assert.AreEqual(oDip.lstDomainesCompetences[0].ID, oLiv2.lstDCLivrets[0].oDomaineCompetence.ID);
            Assert.AreEqual(oDip.lstDomainesCompetences[1].ID, oLiv2.lstDCLivrets[1].oDomaineCompetence.ID);
            Assert.AreEqual(oDip.lstDomainesCompetences[2].ID, oLiv2.lstDCLivrets[2].oDomaineCompetence.ID);
            Assert.AreEqual(oDip.lstDomainesCompetences[3].ID, oLiv2.lstDCLivrets[3].oDomaineCompetence.ID);

        }
    }
}
