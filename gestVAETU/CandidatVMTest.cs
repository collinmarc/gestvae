using System;
using GestVAE.VM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class CandidatVMTest
    {
        [TestMethod]
        public void CreateTest()
        {

            MyViewModel VM = new MyViewModel();
            VM.AddCandidatCommand.Execute(null);
            Assert.AreEqual("Française", VM.CurrentCandidat.Nationnalite);
            Assert.AreEqual("Française", VM.CurrentCandidat.NationnaliteNaissance);

        }
    }
}
