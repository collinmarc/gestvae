using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestVAEcls;
using System.Linq;
using GestVAE.VM;

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

            SaveChanges();

            oDC1 = ctx.DomainesCompetences.First<DomaineCompetence>();

            Int32 nId = oDC1.ID;

            oDC2 = (from obj in ctx.DomainesCompetences
                     where (obj.ID == nId) && (!obj.bDeleted)
                     select obj).First<DomaineCompetence>();
            Assert.AreEqual(oDC1.Nom, oDC2.Nom);
            Assert.AreEqual(oDC1.Numero, oDC2.Numero);

            oDC2.Nom = "DC2";
            oDC1.Numero = 2;

            SaveChanges();

            oDC1 = (from obj in ctx.DomainesCompetences
                     where (obj.ID == nId) && (!obj.bDeleted)
                     select obj).First<DomaineCompetence>();
            Assert.AreEqual(oDC2.Nom, oDC1.Nom);
            Assert.AreEqual(oDC2.Numero, oDC1.Numero);


            ctx.DomainesCompetences.Remove(oDC1);

            SaveChanges();

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
            MyViewModel VM = new MyViewModel(true);
            VM.rechNom = oCand.Nom;
            VM.Recherche(true);
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.AjouteDiplomeCand();
            VM.saveData();

            VM.rechNom = oCand.Nom;
            VM.Recherche(true);
            Assert.AreEqual(1, VM.CurrentCandidat.lstDiplomesCandVMs.Count());


        }
    }
}
