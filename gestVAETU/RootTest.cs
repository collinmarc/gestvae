using System;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace GestVAETU
{
    [TestClass]
    public class RootTest
    {
        [TestInitialize]
        public void Setup()
        {

            Context ctx = new Context();
            ctx.Candidats.RemoveRange(ctx.Candidats.ToList<Candidat>());
            ctx.SaveChanges();
        }
    }
}
