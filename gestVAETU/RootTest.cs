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

            foreach (Candidat oC in ctx.Candidats)
            {
                while (oC.lstLivrets1.Count>0)
                {
                    while (oC.lstLivrets1[0].lstJurys.Count > 0)
                    {
                        oC.lstLivrets1[0].lstJurys.RemoveAt(0);
                    }
                    oC.lstLivrets1.RemoveAt(0);
                }
                while (oC.lstLivrets2.Count > 0)
                {
                    while (oC.lstLivrets2[0].lstJurys.Count > 0)
                    {
                        oC.lstLivrets2[0].lstJurys.RemoveAt(0);
                    }
                    oC.lstLivrets2.RemoveAt(0);
                }
            }
            ctx.Candidats.RemoveRange(ctx.Candidats.ToList());
            ctx.Diplomes.RemoveRange(ctx.Diplomes.ToList<Diplome>());
                ctx.SaveChanges();
        }
        [TestInitialize]
        public void Setup()
        {
            Context.Reset();
            ctx = Context.instance;
            cleanDB();

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
        }
    }
}
