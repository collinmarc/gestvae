using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestVAEcls;
using System.Linq;

namespace GestVAETU
{
    [TestClass]
    public class DiplomeCandidatTest : RootTest
    {



        public DiplomeCandidatTest()
        {
            oDip = null;
            oCand = null;
        }
        [TestInitialize()]
        public void MyTestInitialize()
        {
            base.Setup();

        }
        [TestMethod]
        public void TestCRUDDiplomeCandidat()
        {


            DiplomeCand oDC1;
            DiplomeCand oDC2;
            oDC1 = oCand.AddDiplome(oDip);

            //ctx.DiplomeCands.Add(oDC1);

            ctx.SaveChanges();

            oDC1 = ctx.DiplomeCands.First<DiplomeCand>();

            Int32 nId = oDC1.ID;

            oDC2 = (from obj in ctx.DiplomeCands
                     where (obj.ID == nId) && (!obj.bDeleted)
                     select obj).First<DiplomeCand>();
            Assert.AreEqual(oDC1.Statut, oDC2.Statut);

            oDC2.Statut = "EN COURS";
            oDC2.DateObtention = Convert.ToDateTime("06/02/1964");
            oDC2.NumeroDiplome = "1234";
            oDC2.NumeroEURODIR = "4567";


            ctx.SaveChanges();
            ctx = Context.instance;

            oDC1 = (from obj in ctx.DiplomeCands
                    where (obj.ID == nId) && (!obj.bDeleted)
                     select obj).First<DiplomeCand>();
            Assert.AreEqual(oDC2.Statut, oDC1.Statut);
            Assert.AreEqual(oDC2.DateObtention, oDC1.DateObtention);
            Assert.AreEqual(oDC2.NumeroDiplome, oDC1.NumeroDiplome);
            Assert.AreEqual(oDC2.NumeroEURODIR, oDC1.NumeroEURODIR);


            ctx.DiplomeCands.Remove(oDC1);

            ctx.SaveChanges();

            int nDiplomeCandidat = (from obj in ctx.DiplomeCands select obj).Count<DiplomeCand>();

            Assert.AreEqual(0, nDiplomeCandidat);


        }

        [TestMethod]
        public void TestCRUDDiplomeCandidatCreationDomaioneCompetence()
        {


            DiplomeCand oDC1;
            oDC1 = oCand.AddDiplome(oDip);
 
            ctx.SaveChanges();


        }

    }
}
