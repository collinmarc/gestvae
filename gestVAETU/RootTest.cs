using System;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using GestVAE.VM;

namespace GestVAETU
{
    [TestClass]
    public class RootTest
    {

        protected Diplome oDip;
        protected Candidat oCand;

        public TestContext TestContext { get; set; }

        public Context ctx { get; set; }

        public void cleanDB()
        {
            //using (ctx = Context.instance)
            //{
                ;
            //ctx.DomaineCompetenceCands.RemoveRange(ctx.DomaineCompetenceCands.ToList<DomaineCompetenceCand>());
            //ctx.DiplomeCands.RemoveRange(ctx.DiplomeCands.ToList<DiplomeCand>());
            //ctx.Diplomes.RemoveRange(ctx.Diplomes.ToList<Diplome>());
            //ctx.DomainesCompetences.RemoveRange(ctx.DomainesCompetences.ToList<DomaineCompetence>());
            //foreach(Candidat oCand in ctx.Candidats)
            //{
            //    ctx.Entry<Candidat>(oCand).State = System.Data.Entity.EntityState.Deleted;
            //}
            MyViewModel VM = new MyViewModel();
            VM.getData();
            while (VM.lstCandidatVM.Count>0)
            {
                VM.CurrentCandidat = VM.lstCandidatVM[0];
                VM.DeleteCurrentCandidat();
            }
            VM.saveData();
//            ctx.Candidats.RemoveRange(ctx.Candidats.ToList<Candidat>());
            //foreach (Diplome oItem in ctx.Diplomes)
            //{
            //    ctx.Entry<Diplome>(oItem).State = System.Data.Entity.EntityState.Deleted;
            //}
            ctx.Diplomes.RemoveRange(ctx.Diplomes.ToList<Diplome>());
//            ctx.DeleteOnCascade();
                ctx.SaveChanges();
            //}

        }
        [TestInitialize]
        public void Setup()
        {
            ctx = Context.instance;
            cleanDB();
            //using (ctx = Context.instance)
            //{
            //    //ctx.DomaineCompetenceCands.RemoveRange(ctx.DomaineCompetenceCands.ToList<DomaineCompetenceCand>());
                //ctx.DiplomeCands.RemoveRange(ctx.DiplomeCands.ToList<DiplomeCand>());
                //ctx.Diplomes.RemoveRange(ctx.Diplomes.ToList<Diplome>());
                //ctx.DomainesCompetences.RemoveRange(ctx.DomainesCompetences.ToList<DomaineCompetence>());
                //ctx.Diplomes.RemoveRange(ctx.Diplomes.ToList<Diplome>());
                ctx.Candidats.RemoveRange(ctx.Candidats.ToList<Candidat>());
                ctx.SaveChanges();

                oCand = new Candidat("Marc Collin");
                ctx.Candidats.Add(oCand);
                oDip = new Diplome("CAFDES");
                oDip.Description = "Description du CAFDES";
                oDip.addDomainecompetence("DC1");
                oDip.addDomainecompetence("DC2");
                oDip.addDomainecompetence("DC3");
                oDip.addDomainecompetence("DC4");

                ctx.Diplomes.Add(oDip);
                ctx.SaveChanges();
            //}
            //ctx = Context.instance;
        }
    }
}
