using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestVAEcls;
using System.Linq;

namespace GestVAETU
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Context ctx = new Context();
            ctx.T1s.RemoveRange(ctx.T1s.ToList<T1>());
            ctx.T2s.RemoveRange(ctx.T2s.ToList<T2>());
            ctx.SaveChanges();

            T1 oT1 = new T1();
            T2 oT2a = new T2();
            oT1.lstT2.Add(oT2a);
            T2 oT2b = new T2();
            oT1.lstT2.Add(oT2b);

            ctx.T1s.Add(oT1);
            ctx.SaveChanges();

            ctx.T1s.Remove(oT1);
            ctx.SaveChanges();

        }
    }
}
