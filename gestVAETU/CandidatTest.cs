﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestVAEcls;
using System.Linq;

namespace GestVAETU
{
    [TestClass]
    public class CandidatTest : RootTest
    {
        [TestMethod]
        public void TestCRUD()
        {

            Context ctx = new Context();
            Candidat oCand = new Candidat();
            oCand.Nom = "COLLIN";
            oCand.Prenom = "MArc";

            ctx.Candidats.Add(oCand);

            ctx.SaveChanges();

            oCand = ctx.Candidats.First<Candidat>();

            Int32 nId = oCand.ID;

            oCand = (from obj in ctx.Candidats
                    where (obj.ID == nId) && (!obj.bDeleted )
                    select obj).First<Candidat>();
            Assert.AreEqual("COLLIN", oCand.Nom);
            Assert.AreEqual("MArc", oCand.Prenom);

            oCand.Nom = "THOMAS";
            oCand.Prenom = "JF";

            ctx.SaveChanges();
            ctx = new Context();

            oCand = (from obj in ctx.Candidats
                     where (obj.ID == nId) && (!obj.bDeleted)
                     select obj).First<Candidat>();
            Assert.AreEqual("THOMAS", oCand.Nom);
            Assert.AreEqual("JF", oCand.Prenom);


            ctx.Candidats.Remove(oCand);

            ctx.SaveChanges();

            int nCand = (from obj in ctx.Candidats select obj).Count<Candidat>();

            Assert.AreEqual(0, nCand);



        }
    }
}