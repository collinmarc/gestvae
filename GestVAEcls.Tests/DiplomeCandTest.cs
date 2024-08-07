// <copyright file="DiplomeCandTest.cs">Copyright ©  2018</copyright>
using System;
using GestVAEcls;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAEcls.Tests
{
    /// <summary>Cette classe contient des tests unitaires paramétrables pour DiplomeCand</summary>
    [PexClass(typeof(DiplomeCand))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DiplomeCandTest
    {
        /// <summary>Stub de test pour CalculerStatut()</summary>
        [PexMethod]
        public void CalculerStatutTest([PexAssumeUnderTest]DiplomeCand target)
        {
            target.CalculerStatut();
            // TODO: ajouter des assertions à méthode DiplomeCandTest.CalculerStatutTest(DiplomeCand)
        }
    }
}
