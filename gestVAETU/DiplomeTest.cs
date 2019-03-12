using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestVAEcls;
using System.Linq;

namespace GestVAETU
{
    [TestClass]
    public class DiplomeTest:RootTest
    {
        [TestMethod]
        public void TestCRUDDiplome()
        {
            cleanDB();
            Diplome oDiplome = new Diplome();
            oDiplome.Nom = "CAFDES";
            oDiplome.Description = "Ma Description";

            ctx.Diplomes.Add(oDiplome);

            ctx.SaveChanges();

            oDiplome = ctx.Diplomes.First<Diplome>();

            Int32 nId = oDiplome.ID;

            oDiplome = (from obj in ctx.Diplomes
                     where (obj.ID == nId) && (!obj.bDeleted)
                     select obj).First<Diplome>();
            Assert.AreEqual("CAFDES", oDiplome.Nom);
            Assert.AreEqual("Ma Description", oDiplome.Description);

            oDiplome.Nom = "CAFDES2";
            oDiplome.Description = "Ma Description2";

            ctx.SaveChanges();
            ctx = Context.instance;

            oDiplome = (from obj in ctx.Diplomes
                     where (obj.ID == nId) && (!obj.bDeleted)
                     select obj).First<Diplome>();
            Assert.AreEqual("CAFDES2", oDiplome.Nom);
            Assert.AreEqual("Ma Description2", oDiplome.Description);


            ctx.Diplomes.Remove(oDiplome);

            ctx.SaveChanges();

            int nDiplome = (from obj in ctx.Diplomes select obj).Count<Diplome>();

            Assert.AreEqual(0, nDiplome);


        }

        [TestMethod]
        public void testDomaineComp()
        {
            Diplome oDip1 = new Diplome();
            Diplome oDip2 ;
            oDip1.Nom = "CAFDES";

            DomaineCompetence oDC2 = new DomaineCompetence();
            oDC2.Nom = "DC2";
            oDC2.Numero = 2;
            oDip1.lstDomainesCompetences.Add(oDC2);

            DomaineCompetence oDC1 = new DomaineCompetence();
            oDC1.Nom = "DC1";
            oDC1.Numero = 1;
            oDip1.lstDomainesCompetences.Add(oDC1);


            ctx.Diplomes.Add(oDip1);

            ctx.SaveChanges();
            ctx = Context.instance;

            oDip2 = ctx.Diplomes.Find(oDip1.ID);

            Assert.AreEqual(2, oDip2.lstDomainesCompetences.Count<DomaineCompetence>());

            oDC1 = oDip2.lstDomainesCompetences[0];
            Assert.AreEqual("DC2", oDC1.Nom);
            oDC2 = oDip2.lstDomainesCompetences[1];
            Assert.AreEqual("DC1", oDC2.Nom);

            ctx.DomainesCompetences.Remove(oDC2);

            ctx.SaveChanges();

            ctx = Context.instance;

            oDip2 = (from obj in ctx.Diplomes
                     where obj.ID == oDip1.ID
                     select obj).First<Diplome>();

            Assert.AreEqual(1, oDip2.lstDomainesCompetences.Count);

        }
        [TestMethod]
        public void testDeleteOnCascade()
        {
            Diplome oDip1 = new Diplome();
            Diplome oDip2;
            oDip1.Nom = "CAFDES";

            DomaineCompetence oDC2 = new DomaineCompetence();
            oDC2.Nom = "DC2";
            oDC2.Numero = 2;
            oDip1.lstDomainesCompetences.Add(oDC2);

            DomaineCompetence oDC1 = new DomaineCompetence();
            oDC1.Nom = "DC1";
            oDC1.Numero = 1;
            oDip1.lstDomainesCompetences.Add(oDC1);


            ctx.Diplomes.Add(oDip1);

            ctx.SaveChanges();
            ctx = Context.instance;

            oDip2 = ctx.Diplomes.Find(oDip1.ID);

            //Suppression du Diplome => Sup^pression des Domaines de compétences

            ctx.Diplomes.Remove(oDip2);
            ctx.SaveChanges();
 

        }
    }
}
