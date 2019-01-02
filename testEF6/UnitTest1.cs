using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace testEF6
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GESTVAEEntities1 ctx = new GESTVAEEntities1();

            ctx.T2.RemoveRange(ctx.T2.ToList<T2>());
            ctx.T1.RemoveRange(ctx.T1.ToList<T1>());
            ctx.SaveChanges();
            T1 oT1 = new T1();
            T2 oT2a = new T2();
            T2 oT2b = new T2();
            oT1.T2s.Add(oT2a);
            oT1.T2s.Add(oT2b);

            ctx.T1.Add(oT1);

            ctx.SaveChanges();

            ctx.T1.Remove(oT1);
            ctx.SaveChanges();
        }
    }
}
