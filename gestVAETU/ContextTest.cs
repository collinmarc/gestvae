﻿using System;
using System.Configuration;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class ContextTest
    {
        [TestMethod]
        public void TestCreate()
        {

            Context ctx = new Context();
            Assert.AreEqual("BUREAU-DELL\\SQLEXPRESS", ctx.Database.Connection.DataSource);
            Assert.AreEqual("GESTVAETU2", ctx.Database.Connection.Database);
        }
    }
}
