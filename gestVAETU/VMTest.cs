using System;
using GestVAE.VM;
using GestVAEcls;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class VMTest : RootTest
    {
        [TestMethod]
        [TestCategory("VMTest"), TestCategory("Validation")]
        public void CreateDeleteL1Test()
        {

            MyViewModel VM = new MyViewModel(true);
            VM.getData();

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";

            VM.AjouteL1();
            VM.ValideretQuitterL1();

            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;
            oLiv.FTO_SetDecisionJuryL1DeFavorable();
            oLiv.IsRecoursDemande = true;
            oLiv.DateDepotRecours = DateTime.Today;
            oLiv.DecisionJuryRecours = "TEST";
            Assert.IsTrue(VM.saveData());
            VM.rechNom = "TESTCAND";
            VM.Recherche();
//            Assert.AreEqual(1, VM.lstCandidatVM[0].TheCandidat.lstLivrets1[0].lstJurys.Count);

//            Assert.AreEqual(1, VM.lstCandidatVM[0].lstLivrets[0].TheLivret.lstJurys.Count);
//            VM.lstCandidatVM[0].LoadDetails();
//            VM.lstCandidatVM[0].lstLivrets[0].LoadDetails();
//            Assert.AreEqual(1, VM.lstCandidatVM[0].lstLivrets[0].lstJuryVM.Count);
//            Assert.AreEqual(1, VM.lstCandidatVM[0].lstLivrets[0].TheLivret.lstJurys.Count);
            VM.CurrentCandidat = VM.lstCandidatVM.FirstOrDefault();
            VM.LockCurrentCandidat();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(1, VM.CurrentCandidat.lstLivrets.Count);

            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            oLiv = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
//            Assert.AreEqual(1, oLiv.lstJuryVM.Count);
            Assert.AreEqual("TEST", oLiv.DecisionJuryRecours);
            VM.CurrentCandidat.DeleteCurrentLivret();
            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCAND").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(0, VM.CurrentCandidat.lstLivrets.Count);
            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();

            VM.saveData();
            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCAND").FirstOrDefault();
            Assert.IsNull(VM.CurrentCandidat);



        }
        [TestMethod]
        public void CreateDeleteL2Test()
        {

            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCANDL2";
            VM.LockCurrentCandidat();

            VM.AjouteL2();
            VM.ValideretQuitterL2();

            Livret2VM oLiv = (Livret2VM)oCand.CurrentLivret;
            oLiv.DecisionJury = "DECISIONJURYL2";
            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCANDL2").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(1, VM.CurrentCandidat.lstLivrets.Count);

            VM.LockCurrentCandidat();
            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            oLiv = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.AreEqual("DECISIONJURYL2", oLiv.DecisionJury);
            VM.CurrentCandidat.DeleteCurrentLivret();

            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCANDL2").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(0, VM.CurrentCandidat.lstLivrets.Count);

            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();

            VM.saveData();
            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCANDL2").FirstOrDefault();
            Assert.IsNull(VM.CurrentCandidat);

        }

        [TestMethod]
        public void testhasChangesL1()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCANDL1";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.saveData();

            VM.getData();
            oCand = VM.lstCandidatVM.Where(c => c.Nom == "TESTCANDL1").FirstOrDefault<CandidatVM>();
            VM.CurrentCandidat = oCand;
            oCand.CurrentLivret = oCand.lstLivrets[0];

            Assert.IsFalse(oCand.CurrentLivret.HasChanges());

            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;

            oLiv.DateDemande = DateTime.Now;

            Assert.IsTrue(oLiv.HasChanges());
            VM.ResetCurrentLivret();
            Assert.IsFalse(oLiv.HasChanges());
            Assert.AreEqual("", oLiv.DecisionJury);

            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();

        }
        [TestMethod]
        public void testhasChangesL1JuriesRecours()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCANDL2";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.saveData();

            VM.getData();
            oCand = VM.lstCandidatVM.Where(c => c.Nom == "TESTCANDL2").FirstOrDefault<CandidatVM>();
            VM.CurrentCandidat = oCand;
            oCand.CurrentLivret = oCand.lstLivrets[0];


            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;

            Assert.IsFalse(oLiv.HasChanges());
            oLiv.DecisionJury = "TEST";

            Assert.IsTrue(oLiv.HasChanges());
            VM.ResetCurrentLivret();
            Assert.IsFalse(oLiv.HasChanges());
            Assert.AreEqual("", oLiv.DecisionJury);

            oLiv.DecisionJuryRecours = "TEST2";
            Assert.IsTrue(oLiv.HasChanges());
            VM.ResetCurrentLivret();
            Assert.IsFalse(oLiv.HasChanges());
            Assert.AreEqual("", oLiv.DecisionJuryRecours);

            VM.CurrentCandidat = oCand;
            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();

        }
        [TestMethod]
        public void CreateDeleteOnCascade()
        {

            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";

            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.saveData();

            VM.getData();
            Assert.IsTrue(VM.SetCurrentCandidat("TESTCAND"));
            oCand = VM.CurrentCandidat;
            Assert.AreEqual(1, oCand.lstLivrets.Count);
            oCand.CurrentLivret = oCand.lstLivrets[0];

            Livret1VM oLiv = (Livret1VM)oCand.CurrentLivret;
            oLiv.IsRecoursDemande = true;
            oLiv.DateDepotRecours = DateTime.Now;
            oLiv.DecisionJuryRecours = "TEST";
            Assert.IsTrue(VM.saveData());

            VM.saveData();
            VM.getData();
            oCand = VM.lstCandidatVM.Where(c => c.Nom == "TESTCAND").LastOrDefault();
            oCand.LoadDetails();
            Assert.AreEqual(1, oCand.lstLivrets.Count);
            oCand.CurrentLivret = oCand.lstLivrets[0];
            oCand.DeleteCurrentLivret();

            VM.LockCurrentCandidat();

            VM.DeleteCurrentCandidat();
            Assert.IsTrue(VM.saveData());
        }
        [TestMethod]
        public void testCreateL2()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.IsLocked = true;
            oCand.Nom = "TESTCAND";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.saveData();
            VM.rechNom = "TESTCAND";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            VM.CloturerL1etCreerL2();

            Livret2VM oLiv = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.AreEqual(4, oLiv.lstDCLivret.Count);

            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();


        }

        [TestMethod]
        public void testLock()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.AddCandidatCommand.Execute(null);
            oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND2";
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.saveData();
            VM.getData();

            VM.SetCurrentCandidat("TESTCAND");
            oCand = VM.CurrentCandidat;
            Assert.IsFalse(oCand.IsLocked);

            VM.LockCurrentCandidat();

            Assert.IsTrue(oCand.IsLocked);
            Assert.IsFalse(oCand.IsUnlocked);

            VM.getData();
            Assert.IsTrue(oCand.IsLocked);
            Assert.IsFalse(oCand.IsUnlocked);


            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();
        }
        [TestMethod]
        public void testLockVM()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.AddCandidatCommand.Execute(null);
            oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND2";
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            VM.saveData();
            VM.getData();

            VM.SetCurrentCandidat("TESTCAND");
            oCand = VM.CurrentCandidat;
            Assert.IsFalse(oCand.IsLocked);

            VM.LockCurrentCandidat();

            Assert.IsTrue(oCand.IsLocked);

            VM.getData();
            VM.SetCurrentCandidat("TESTCAND");
            oCand = VM.CurrentCandidat;
            Assert.IsTrue(oCand.IsLocked);
            CandidatVM oCand2 = VM.lstCandidatVM.Where(c => c.Nom == "TESTCAND2").FirstOrDefault();
            Assert.IsFalse(oCand2.IsLocked);

            VM.saveData();
            VM.SetCurrentCandidat("TESTCAND");
            oCand = VM.CurrentCandidat;
            Assert.IsFalse(oCand.IsLocked);

            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();
        }
        /// <summary>
        /// Test de la validité du L1
        /// il est valide 3 ans tant qu'il n'y pas de L2 validé partiellement ensuite c'est à vie
        /// </summary>
        [TestMethod]
        public void testIsL1Valide()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            Int32 nDelaiValiditeL1avant = VM.ParamDelaiValiditeL1;
            VM.ParamDelaiValiditeL1 = 0;

            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            oCand.LoadDetails();
            Assert.IsFalse(oCand.IsL1Valide);
            //Ajout D'un L1
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.saveData();

            VM.rechNom = "TESTCAND";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            oCand = VM.CurrentCandidat;
            // Le L1 est EnCours même si  l'état n'est pas bon
            Assert.IsFalse(oCand.IsL1Valide);
            Assert.IsTrue(oCand.IsL1Encours);
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
            oL1.LstEtatLivret = VM.LstEtatLivret1;
            oL1.FTO_SetDecisionJuryL1Favorable();
            oL1.DateValidite = DateTime.Now.AddYears(3);
            // Le L1 Devient Valide
            Assert.IsTrue(oCand.IsL1Valide);
            oL1.DateValidite = DateTime.Now.AddDays(1);
            // Le L1 Reste Valide à 1 jour de l'échéance
            Assert.IsTrue(oCand.IsL1Valide);

            // Le L1 n'est plus valide
            oL1.DateValidite = DateTime.Now.AddDays(-1);
            Assert.IsFalse(oCand.IsL1Valide);

            // Ajout d'un L2 (Normalement impossible car le L1 n'est plus valide)
            VM.AjouteL2();
            VM.ValideretQuitterL2();
            Livret2VM oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            // Tous les DC sont à valider
            oL2.lstDCLivret[0].IsAValider = true;
            oL2.lstDCLivret[1].IsAValider = true;
            oL2.lstDCLivret[2].IsAValider = true;
            oL2.lstDCLivret[3].IsAValider = true;
            // Si la décision est défavorable => le L1 n'est plus valide
            oL2.FTO_SetDecisionJuryL2DeFavorable();
            Assert.IsFalse(oCand.IsL1Valide);
            // La décision du L2 est validation Partielle
            oL2.FTO_SetDecisionJuryL2Partielle();
            oL2.lstDCLivret[0].Decision = oL2.DecisionL2ModuleFavorable;
            oL2.lstDCLivret[1].Decision = oL2.DecisionL2ModuleDeFavorable;
            oL2.lstDCLivret[2].Decision = oL2.DecisionL2ModuleDeFavorable;
            oL2.lstDCLivret[3].Decision = oL2.DecisionL2ModuleDeFavorable;
            VM.saveData();

            VM.rechNom = "TESTCAND";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            oCand = VM.CurrentCandidat;
            // Si au moins un DC est validé , alors le L1 devienbt valide à vie 
            Assert.IsTrue(oCand.IsL1Valide," le L1 devient valide à vie");



            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();
            VM.ParamDelaiValiditeL1 = nDelaiValiditeL1avant;
            VM.saveDataParam();


        }
        [TestMethod]
        public void testDelaivalidationL1()
        {
            MyViewModel VM = new MyViewModel(true);
            VM.AjouteCandidat();
            VM.LockCurrentCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TESTDELAIVALL1";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            Livret1VM oL1 = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
            oL1.FTO_SetDecisionJuryL1Favorable();

            VM.ParamDelaiValiditeL1 = 0;
            // si sa date de validé est hier
            oL1.DateValidite = DateTime.Now.AddDays(-1);
            // alors il n'est pas valide
            Assert.IsFalse(oL1.IsValide(oCan));

            VM.ParamDelaiValiditeL1 = 5;
            // alors il devient valide
            Assert.IsTrue(oL1.IsValide(oCan));

        }
        /// <summary>
        /// Test la propiété IsToléré de Livret1VM
        /// </summary>
        [TestMethod]
        public void testIsTolere()
        {
            MyViewModel VM = new MyViewModel(true);
            VM.AjouteCandidat();
            VM.LockCurrentCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TESTDELAIVALL1";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            Livret1VM oL1 = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
            oL1.FTO_SetDecisionJuryL1Favorable();

            VM.ParamDelaiValiditeL1 = 5;
            // si sa date de validé est demain
            oL1.DateValidite = DateTime.Now.AddDays(1);
            // Il n'est pas toléré
            Assert.IsFalse(oL1.IsTolere);
            // si sa date de validé est Avant la période de tolérance
            oL1.DateValidite = DateTime.Now.AddDays(-10);
            // Il n'est pas toléré
            Assert.IsFalse(oL1.IsTolere);

            // si sa date de validé est dans la période de tolérance
            oL1.DateValidite = DateTime.Now.AddDays(-3);
            // Il n'est pas toléré
            Assert.IsTrue(oL1.IsTolere);


        }
        [TestMethod]
        public void NumCandidatTest()
        {
            MyViewModel VM = new MyViewModel();
            VM.AjouteCandidat();
            CandidatVM oCand = VM.CurrentCandidat;

            Assert.IsFalse(String.IsNullOrEmpty(oCand.IdVAE));
            Assert.IsTrue(oCand.IdVAE.StartsWith("3"));
            Assert.AreEqual(oCand.IdVAE.Substring(1,2),DateTime.Now.ToString("yy"));
            Int32 Num1 = Convert.ToInt32(oCand.IdVAE.Substring(3));
            VM.AjouteCandidat();
            oCand = VM.CurrentCandidat;
            Int32 Num2 = Convert.ToInt32(oCand.IdVAE.Substring(3));
            Assert.AreEqual(Num1 + 1, Num2);
        }

        /// <summary>
        /// Récupération du Livret1 Valide 
        /// </summary>
        [TestMethod]
        public void getL1ValideTest()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            // Ajout du Livret1
            VM.AjouteL1();
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL1DeFavorable();
            // Date de validé > Aujourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
            VM.ValideretQuitterL1();
            // le L1 n'est pas Valide
            Assert.IsFalse(VM.CurrentCandidat.IsL1Valide);
            // Mais il est encours
            Assert.IsTrue(VM.CurrentCandidat.IsL1Encours);
            // Date de validé =  Hier
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(-1);
            // il n'y a plus de L1 Valide
            Assert.IsFalse(VM.CurrentCandidat.IsL1Valide);
            Assert.IsFalse(VM.CurrentCandidat.IsL1Encours);
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            // on lui affecte un numéro pour le Test
            VM.CurrentCandidat.CurrentLivret.Numero = "TEST1";
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL1Favorable();
            // Date de validé > Aujourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
            // Il y a Maintenant un L1 de Valide
            Assert.IsTrue(VM.CurrentCandidat.IsL1Valide);
            // et c'est celui que l'on as Creeé
            Assert.IsNotNull(VM.CurrentCandidat.getL1Valide());
            Assert.AreEqual("TEST1", VM.CurrentCandidat.getL1Valide().Numero);



        }
        /// <summary>
        /// Récupération du Numero du L1 sur le L2
        /// </summary>
        [TestMethod]
        public void getNumL1ValideTest()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            // Ajout du Livret1
            VM.AjouteL1();
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL1DeFavorable();
            // Date de validé =  Hier
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(-1);
            VM.ValideretQuitterL1();
            // Ajout d'un Second Livret 
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            // on lui affecte un numéro pour le Test
            VM.CurrentCandidat.CurrentLivret.Numero = "TEST1";
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL1Favorable();
            // Date de validé > Aujourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);

            // Ajout d'un L2
            VM.AjouteL2();
            VM.ValideretQuitterL2();
            // Le Numero du L2 est  le même que le L1
            Assert.AreEqual("TEST1", VM.CurrentCandidat.CurrentLivret.Numero);
            Assert.AreEqual(1, ((Livret2VM)VM.CurrentCandidat.CurrentLivret).NumPassage);
            // Ajout d'un Second L2
            VM.AjouteL2();
            VM.ValideretQuitterL2();
            // Le Numero du L2 est  le même que le L1, mais le numero de passage a été incrémenté
            Assert.AreEqual("TEST1", VM.CurrentCandidat.CurrentLivret.Numero);
            Assert.AreEqual(2, ((Livret2VM)VM.CurrentCandidat.CurrentLivret).NumPassage);



        }
        /// <summary>
        /// La date de validité du L2 est celle du L1 (Sans recours)
        /// </summary>
        [TestMethod]
        public void DateValiditeL2ApresL1Test()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            // Ajout du Livret1
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            Livret1VM oL1 = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
            // on lui affecte un numéro pour le Test
            VM.CurrentCandidat.CurrentLivret.Numero = "TEST1";
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL1Favorable();
            VM.CurrentCandidat.CurrentLivret.CommentaireJuryRecours = String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE);
            // Date de validité > Aujourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddYears(3);

            // Ajout d'un L2
            VM.AjouteL2();
            VM.ValideretQuitterL2();
            Livret2VM oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            // Le Numero du L2 est  le même que le L1
            Assert.AreEqual("TEST1", oL2.Numero);
            Assert.AreEqual(1, oL2.NumPassage);
            Assert.AreEqual(false, oL2.IsOuvertureApresRecours);
            Assert.AreEqual(oL1.DateValidite, oL2.DateValidite);

        }
        /// <summary>
        /// La date de validité du L2 est celle du L1 (Après un Recours Favorable)
        /// </summary>
        [TestMethod]
        public void DateValiditeL2ApresL1Test2()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            // Ajout du Livret1
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            Livret1VM oL1 = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
            // on lui affecte un numéro pour le Test
            //            VM.CurrentCandidat.CurrentLivret.Numero = "TEST1";
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL1DeFavorable();
            VM.CurrentCandidat.CurrentLivret.IsRecoursDemande = true;
            VM.CurrentCandidat.CurrentLivret.DecisionJuryRecours = String.Format("{0:D}-Favorable", MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE);
            // Date de validité > Aujourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddYears(3);

            // Ajout d'un L2
            VM.AjouteL2();
            VM.ValideretQuitterL2();
            Livret2VM oL2 = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            // Le Numero du L2 est  le même que le L1
            Assert.AreEqual(oL1.Numero, oL2.Numero);
            Assert.AreEqual(1, oL2.NumPassage);
            Assert.AreEqual(true, oL2.IsOuvertureApresRecours);
            Assert.AreEqual(oL1.DateValidite, oL2.DateValidite);

        }
        /// <summary>
        /// Vérifie le résultat de l recherche s'il y a des modifs en cours
        /// </summary>
        [TestMethod]
        public void DateRechercheAvecModif()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            Assert.IsTrue(VM.Recherche());

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.CurrentCandidat.Prenom = "P1";

            Assert.IsTrue(VM.HasChanges());

            // En mode test , il n'est pas possible de faire une recherche après un Modif
            Assert.IsFalse(VM.Recherche());
            Assert.IsTrue(VM.Recherche(true)); // Mode Force


        }
        /// <summary>
        /// Vérifie le résultat de l recherche s'il y a des modifs en cours
        /// </summary>
        [TestMethod]
        public void CreationDiplomeCandModeObtentionEtstatusTest()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AjouteCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            Assert.AreEqual(0, oCan.lstDiplomesCandVMs.Count);
            oCan.Nom = "TEST1";
            VM.saveData();
            VM.AjouteL2();
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL2Favorable();
            VM.ValideretQuitterL2();
            // Un diplome a bienété crée
            Assert.AreEqual(1, oCan.lstDiplomesCandVMs.Count);
            DiplomeCandVM oDip = oCan.lstDiplomesCandVMs.First();
            Assert.AreEqual("VAE", oDip.ModeObtention);
            Assert.AreEqual("Validé", oDip.StatutDiplome);

            foreach (GestVAEcls.DomaineCompetenceCand item in oDip.lstDCCands)
            {
                Assert.AreEqual("VAE", item.ModeObtention);
                Assert.AreEqual("Validé", item.Statut);

            }





        }

        [TestMethod]
        public void testCreateL1()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            oCand.DateCreation = DateTime.Now.AddDays(-1);
            oCand.TypeDemande = "TEST";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.saveData();
            VM.getData();
            Assert.IsTrue(VM.SetCurrentCandidat("TESTCAND"));
            Livret1VM oLiv = (Livret1VM) VM.CurrentCandidat.lstLivrets[0];

            Assert.AreEqual(VM.CurrentCandidat.DateCreation, oLiv.DateDemande);
            Assert.AreEqual(VM.CurrentCandidat.DateCreation, oLiv.DateEnvoiEHESP);
            Assert.AreEqual(VM.CurrentCandidat.TypeDemande, oLiv.TypeDemande);


        }
        [TestMethod]
        [TestCategory("VMTest"), TestCategory("ANN"),TestCategory("#1003")]
        public void TestCreateL22ndPassage()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            VM.AjouteL1();
            Livret1VM oL1 = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
            oL1.Numero = "TESTL1";
            oL1.DateJury = new DateTime(2019, 04, 12);
            oL1.DateNotificationJury = new DateTime(2019, 04, 13,0,0,0);
            oL1.DateEnvoiL2 = new DateTime(2019, 06, 13, 0, 0, 0);
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL1Favorable();
            VM.ValideretQuitterL1();
            VM.saveData();
            VM.getData();
            Assert.IsTrue(VM.SetCurrentCandidat("TESTCAND"));
            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            Assert.AreEqual("TESTL1", VM.CurrentCandidat.CurrentLivret.Numero);
            // Création du L2 Premier passage
            VM.CloturerL1etCreerL2();
            Livret2VM oLiv = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.AreEqual(1, oLiv.NumPassage);
            Assert.AreEqual("TESTL1", oLiv.Numero);
            Assert.AreEqual(new DateTime(2019,06,13,0,0,0), oLiv.DateEnvoiEHESP);
            VM.ValideretQuitterL2();

            // Création du L2 Second passage
            VM.AjouteL2();
            oLiv = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.AreEqual(2, oLiv.NumPassage);
            Assert.AreEqual("TESTL1", oLiv.Numero);


            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();
        }

        [TestMethod]
        [TestCategory("VMTest"), TestCategory("ANN"), TestCategory("#1016")]
        public void TestCreateL22ndPassageDateValidité()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            VM.AjouteL1();
            Livret1VM oL1 = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
            oL1.Numero = "TESTL1";
            oL1.DateJury = new DateTime(2019, 04, 12);
            oL1.DateNotificationJury = new DateTime(2019, 04, 13, 0, 0, 0);
            oL1.DateEnvoiL2 = new DateTime(2019, 06, 13, 0, 0, 0);
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL1Favorable();
            VM.ValideretQuitterL1();
            VM.saveData();
            VM.getData();
            Assert.IsTrue(VM.SetCurrentCandidat("TESTCAND"));
            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            Assert.AreEqual("TESTL1", VM.CurrentCandidat.CurrentLivret.Numero);

            // Création du L2 Premier passage
            VM.CloturerL1etCreerL2();
            Livret2VM oLiv = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            VM.ValideretQuitterL2();

            // Création du L2 Second passage
            VM.AjouteL2();
            oLiv = (Livret2VM)VM.CurrentCandidat.CurrentLivret;
            Assert.AreEqual(2, oLiv.NumPassage);
            Assert.AreEqual("TESTL1", oLiv.Numero);
            Assert.AreEqual(oL1.DateValidite, oLiv.DateValidite);


            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();
        }
        [TestMethod]
        [TestCategory("VMTest"), TestCategory("ANN"), TestCategory("#938")]
        public void TestChangeNumerotationCandidat()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.dlgParamCommand.Execute(null);
            VM.ParamNumCandidat = 999;
            VM.ValiderdlgParam(null);
            VM.AjouteCandidat();
            String IDVAE = "3" + DateTime.Now.ToString("yy") + "00999";

            Assert.AreEqual(IDVAE, VM.CurrentCandidat.IdVAE);

        }
        [TestMethod,Ignore()]
        public void TestExportdata()
        {
            MyViewModel VM = new MyViewModel();
            String fileName = DateTime.Now.ToString(VM.DatabaseName + "_yyMMddHHmm") + ".bak";

            if (System.IO.File.Exists("C:/Temp/" + fileName))
            {
                System.IO.File.Delete("C:/Temp/" +  fileName);
            }
            VM.exporterData();
            Assert.IsTrue(System.IO.File.Exists("C:/Temp/"+ fileName));


        }
        [TestMethod]
        public void TestDeleteOnCascadeCandidat1()
        {
            Int32 nDiplomeCandAvant, nDiplomeCandApres, nDCCandAvant, nDCCandApres, nCandAvant, nCandApres;
            System.Data.Common.DbConnection oConn = Context.instance.Database.Connection;
            System.Data.Common.DbCommand ocmd = oConn.CreateCommand();

            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from DiplomeCands";
            nDiplomeCandAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DomaineCompetenceCands";
            nDCCandAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Candidats";
            nCandAvant = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            MyViewModel VM;
            VM = new MyViewModel();
            VM.IsInTest = true;
            VM.AjouteCandidat();
            VM.CurrentCandidat.Nom = "TESTRECOURS";
            VM.CurrentCandidat.IsDEIS = true;
            VM.CurrentCandidat.IsCAFERUIS = true;
            VM.CurrentCandidat.IsCAFDES = true;
            VM.saveData();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from DiplomeCands";
            nDiplomeCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DomaineCompetenceCands";
            nDCCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Candidats";
            nCandApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nDiplomeCandAvant + 3, nDiplomeCandApres);
            Assert.AreEqual(nDCCandAvant + 12, nDCCandApres);
            Assert.AreEqual(nCandAvant + 1, nCandApres);

            VM.rechNom = "TESTRECOURS";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.CurrentCandidat.IsDEIS = false;
//            VM.CurrentCandidat.IsCAFERUIS = false;
//            VM.CurrentCandidat.IsCAFDES = false;
            Assert.IsTrue(VM.saveData());
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from DiplomeCands";
            nDiplomeCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DomaineCompetenceCands";
            nDCCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Candidats";
            nCandApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nDiplomeCandAvant+2, nDiplomeCandApres);
            Assert.AreEqual(nDCCandAvant + 8, nDCCandApres);
            Assert.AreEqual(nCandAvant + 1, nCandApres);

            // SUPRESSION DU CAFERUIS
            //=======================
            VM.rechNom = "TESTRECOURS";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.CurrentCandidat.IsCAFERUIS = false;
            //            VM.CurrentCandidat.IsCAFERUIS = false;
            //            VM.CurrentCandidat.IsCAFDES = false;
            Assert.IsTrue(VM.saveData());
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from DiplomeCands";
            nDiplomeCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DomaineCompetenceCands";
            nDCCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Candidats";
            nCandApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nDiplomeCandAvant + 1, nDiplomeCandApres);
            Assert.AreEqual(nDCCandAvant + 4, nDCCandApres);
            Assert.AreEqual(nCandAvant + 1, nCandApres);

            // SUPRESSION DU CAFDES
            //=======================
            VM.rechNom = "TESTRECOURS";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            VM.CurrentCandidat.IsCAFDES = false;
            //            VM.CurrentCandidat.IsCAFERUIS = false;
            //            VM.CurrentCandidat.IsCAFDES = false;
            Assert.IsTrue(VM.saveData());

            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from DiplomeCands";
            nDiplomeCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DomaineCompetenceCands";
            nDCCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Candidats";
            nCandApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            Assert.AreEqual(nDiplomeCandAvant , nDiplomeCandApres);
            Assert.AreEqual(nDCCandAvant , nDCCandApres);
            Assert.AreEqual(nCandAvant + 1, nCandApres);


        }
        /// <summary>
        /// Test du delete onCascade sur la suppression du candidat
        /// </summary>
        [TestMethod]
        public void TestDeleteOnCascadeCandidat2()
        {
            Int32 nDiplomeCandAvant, nDiplomeCandApres, nDCCandAvant, nDCCandApres, nCandAvant, nCandApres;
            System.Data.Common.DbConnection oConn = Context.instance.Database.Connection;
            System.Data.Common.DbCommand ocmd = oConn.CreateCommand();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from DiplomeCands";
            nDiplomeCandAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DomaineCompetenceCands";
            nDCCandAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Candidats";
            nCandAvant = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            MyViewModel VM;
            VM = new MyViewModel();
            VM.IsInTest = true;
            VM.AjouteCandidat();
            VM.CurrentCandidat.Nom = "TESTRECOURS";
            VM.CurrentCandidat.IsDEIS = true;
            VM.CurrentCandidat.IsCAFERUIS = true;
            VM.CurrentCandidat.IsCAFDES = true;
            VM.saveData();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from DiplomeCands";
            nDiplomeCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DomaineCompetenceCands";
            nDCCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Candidats";
            nCandApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nDiplomeCandAvant + 3, nDiplomeCandApres);
            Assert.AreEqual(nDCCandAvant + 12, nDCCandApres);
            Assert.AreEqual(nCandAvant + 1, nCandApres);

            //SUPRESSION DU CANDIDAT
            VM.rechNom = "TESTRECOURS";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            Assert.IsTrue(VM.saveData());

            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from DiplomeCands";
            nDiplomeCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DomaineCompetenceCands";
            nDCCandApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Candidats";
            nCandApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nDiplomeCandAvant, nDiplomeCandApres);
            Assert.AreEqual(nDCCandAvant, nDCCandApres);
            Assert.AreEqual(nCandAvant, nCandApres);


        }

        [TestMethod]
        public void TestDeleteOnCascadeL1()
        {
            Int32 nJuryAvant, nJuryApres, nRecoursAvant, nRecoursApres;
            Int32 nPJL1Avant, nPJL1Apres, nL1Avant, nL1Apres;
            System.Data.Common.DbConnection oConn = Context.instance.Database.Connection;
            System.Data.Common.DbCommand ocmd = oConn.CreateCommand();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL1";
            nPJL1Avant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret1";
            nL1Avant = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            MyViewModel VM;
            VM = new MyViewModel();
            VM.IsInTest = true;
            VM.AjouteCandidat();
            VM.CurrentCandidat.Nom = "TESTRECOURS";
            VM.AjouteL1();
            VM.CurrentCandidat.CurrentLivret.CategoriePJ = new PieceJointeCategorie() { Categorie = "Test" };
            VM.CurrentCandidat.CurrentLivret.LibellePJ = new PieceJointeItem() { Libelle = "Test" };
            VM.AjoutePJL1();
            VM.ValideretQuitterL1();
            VM.saveData();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL1";
            nPJL1Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret1";
            nL1Apres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nJuryAvant + 1, nJuryApres);
            Assert.AreEqual(nRecoursAvant + 1, nRecoursApres);
            Assert.AreEqual(nPJL1Avant + 1, nPJL1Apres);
            Assert.AreEqual(nL1Avant + 1, nL1Apres);

            VM.rechNom = "TESTRECOURS";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            Assert.IsTrue(VM.saveData());
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL1";
            nPJL1Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret1";
            nL1Apres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            Assert.AreEqual(nPJL1Avant, nPJL1Apres);
            Assert.AreEqual(nL1Avant, nL1Apres);
            Assert.AreEqual(nJuryAvant, nJuryApres);
            Assert.AreEqual(nRecoursAvant, nRecoursApres);



        }
        [TestMethod]
        public void TestDeleteOnCascadeL2()
        {
            Int32 nJuryAvant, nJuryApres, nRecoursAvant, nRecoursApres;
            Int32 nPJL2Avant, nPJL2Apres, nL2Avant, nL2Apres;
            Int32 nMembreJuryAvant, nMembreJuryApres;
            Int32 nDcLivretAvant, nDcLivretApres;
            System.Data.Common.DbConnection oConn = Context.instance.Database.Connection;
            System.Data.Common.DbCommand ocmd = oConn.CreateCommand();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL2";
            nPJL2Avant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret2";
            nL2Avant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from MembreJuries";
            nMembreJuryAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DCLivrets";
            nDcLivretAvant = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            MyViewModel VM;
            VM = new MyViewModel();
            VM.IsInTest = true;
            VM.AjouteCandidat();
            VM.CurrentCandidat.Nom = "TESTRECOURS";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.AjouteL2();
            VM.CurrentCandidat.CurrentLivret.CategoriePJ = new PieceJointeCategorie() { Categorie = "Test" };
            VM.CurrentCandidat.CurrentLivret.LibellePJ = new PieceJointeItem() { Libelle = "Test" };
            VM.AjoutePJL2();
            VM.AjouterMembreJury();
            VM.ValideretQuitterL2();
            VM.saveData();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL2";
            nPJL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret2";
            nL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from MembreJuries";
            nMembreJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DCLivrets";
            nDcLivretApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nJuryAvant+2, nJuryApres);
            Assert.AreEqual(nRecoursAvant+2, nRecoursApres);
            Assert.AreEqual(nPJL2Avant + 1, nPJL2Apres);
            Assert.AreEqual(nMembreJuryAvant + 1, nMembreJuryApres);
            Assert.AreEqual(nL2Avant + 1, nL2Apres);
            Assert.AreEqual(nDcLivretAvant + 4, nDcLivretApres);

            VM.rechNom = "TESTRECOURS";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            Assert.IsTrue(VM.saveData());
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL2";
            nPJL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from MembreJuries";
            nMembreJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret2";
            nL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DCLivrets";
            nDcLivretApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            Assert.AreEqual(nPJL2Avant, nPJL2Apres);
            Assert.AreEqual(nL2Avant, nL2Apres);
            Assert.AreEqual(nJuryAvant, nJuryApres);
            Assert.AreEqual(nMembreJuryAvant , nMembreJuryApres);
            Assert.AreEqual(nRecoursAvant, nRecoursApres);
            Assert.AreEqual(nDcLivretAvant, nDcLivretApres);
            Assert.AreEqual(nL2Avant, nL2Apres);




        }
        [TestMethod]
        public void TestDeleteOnCascadeSupressionLivretL1()
        {
            Int32 nJuryAvant, nJuryApres, nRecoursAvant, nRecoursApres;
            Int32 nPJL1Avant, nPJL1Apres, nL1Avant, nL1Apres;
            System.Data.Common.DbConnection oConn = Context.instance.Database.Connection;
            System.Data.Common.DbCommand ocmd = oConn.CreateCommand();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL1";
            nPJL1Avant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret1";
            nL1Avant = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            MyViewModel VM;
            VM = new MyViewModel();
            VM.IsInTest = true;
            VM.AjouteCandidat();
            VM.CurrentCandidat.Nom = "TESTRECOURS";
            VM.AjouteL1();
            VM.CurrentCandidat.CurrentLivret.CategoriePJ = new PieceJointeCategorie() { Categorie = "Test" };
            VM.CurrentCandidat.CurrentLivret.LibellePJ = new PieceJointeItem() { Libelle = "Test" };
            VM.AjoutePJL1();
            VM.ValideretQuitterL1();
            VM.saveData();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL1";
            nPJL1Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret1";
            nL1Apres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nJuryAvant + 1, nJuryApres);
            Assert.AreEqual(nRecoursAvant + 1, nRecoursApres);
            Assert.AreEqual(nPJL1Avant + 1, nPJL1Apres);
            Assert.AreEqual(nL1Avant + 1, nL1Apres);

            VM.rechNom = "TESTRECOURS";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            Assert.AreEqual(1, VM.CurrentCandidat.lstLivrets.Count);
            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            VM.CurrentCandidat.DeleteCurrentLivret();
            Assert.IsTrue(VM.saveData());
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL1";
            nPJL1Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret1";
            nL1Apres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            Assert.AreEqual(nPJL1Avant, nPJL1Apres);
            Assert.AreEqual(nL1Avant, nL1Apres);
            Assert.AreEqual(nJuryAvant, nJuryApres);
            Assert.AreEqual(nRecoursAvant, nRecoursApres);



        }

        [TestMethod]
        public void TestDeleteOnCascadeSuppressionL2()
        {
            Int32 nJuryAvant, nJuryApres, nRecoursAvant, nRecoursApres;
            Int32 nPJL2Avant, nPJL2Apres, nL2Avant, nL2Apres;
            Int32 nMembreJuryAvant, nMembreJuryApres;
            Int32 nDcLivretAvant, nDcLivretApres;
            System.Data.Common.DbConnection oConn = Context.instance.Database.Connection;
            System.Data.Common.DbCommand ocmd = oConn.CreateCommand();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL2";
            nPJL2Avant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret2";
            nL2Avant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from MembreJuries";
            nMembreJuryAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DCLivrets";
            nDcLivretAvant = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            MyViewModel VM;
            VM = new MyViewModel();
            VM.IsInTest = true;
            VM.AjouteCandidat();
            VM.CurrentCandidat.Nom = "TESTRECOURS";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.AjouteL2();
            VM.CurrentCandidat.CurrentLivret.CategoriePJ = new PieceJointeCategorie() { Categorie = "Test" };
            VM.CurrentCandidat.CurrentLivret.LibellePJ = new PieceJointeItem() { Libelle = "Test" };
            VM.AjoutePJL2();
            VM.AjouterMembreJury();
            VM.ValideretQuitterL2();
            VM.saveData();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL2";
            nPJL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret2";
            nL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from MembreJuries";
            nMembreJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DCLivrets";
            nDcLivretApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nJuryAvant + 2, nJuryApres);
            Assert.AreEqual(nRecoursAvant + 2, nRecoursApres);
            Assert.AreEqual(nPJL2Avant + 1, nPJL2Apres);
            Assert.AreEqual(nMembreJuryAvant + 1, nMembreJuryApres);
            Assert.AreEqual(nL2Avant + 1, nL2Apres);
            Assert.AreEqual(nDcLivretAvant + 4, nDcLivretApres);

            VM.rechNom = "TESTRECOURS";
            VM.Recherche();
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            VM.LockCurrentCandidat();
            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[1];
            VM.CurrentCandidat.DeleteCurrentLivret();
            Assert.IsTrue(VM.saveData());
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL2";
            nPJL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from MembreJuries";
            nMembreJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret2";
            nL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DCLivrets";
            nDcLivretApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            Assert.AreEqual(nPJL2Avant, nPJL2Apres);
            Assert.AreEqual(nL2Avant, nL2Apres);
            Assert.AreEqual(nJuryAvant+1, nJuryApres); // On a toujours le Jury du L1
            Assert.AreEqual(nMembreJuryAvant, nMembreJuryApres);
            Assert.AreEqual(nRecoursAvant+1, nRecoursApres); // on a toujours le Recours du L1
            Assert.AreEqual(nDcLivretAvant, nDcLivretApres);
            Assert.AreEqual(nL2Avant, nL2Apres);
        }

        [TestMethod]
        public void TestAjoutSuppressionL2()
        {
            Int32 nJuryAvant, nJuryApres, nRecoursAvant, nRecoursApres;
            Int32 nPJL2Avant, nPJL2Apres, nL2Avant, nL2Apres;
            Int32 nMembreJuryAvant, nMembreJuryApres;
            Int32 nDcLivretAvant, nDcLivretApres;
            System.Data.Common.DbConnection oConn = Context.instance.Database.Connection;
            System.Data.Common.DbCommand ocmd = oConn.CreateCommand();
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL2";
            nPJL2Avant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret2";
            nL2Avant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from MembreJuries";
            nMembreJuryAvant = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DCLivrets";
            nDcLivretAvant = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();

            MyViewModel VM;
            VM = new MyViewModel();
            VM.IsInTest = true;
            VM.AjouteCandidat();
            VM.CurrentCandidat.IsLocked = true;
            VM.CurrentCandidat.LoadDetails();
            VM.CurrentCandidat.Nom = "TESTRECOURS";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.AjouteL2();
            VM.CurrentCandidat.CurrentLivret.CategoriePJ = new PieceJointeCategorie() { Categorie = "Test" };
            VM.CurrentCandidat.CurrentLivret.LibellePJ = new PieceJointeItem() { Libelle = "Test" };
            VM.AjoutePJL2();
            VM.AjouterMembreJury();
            VM.ValideretQuitterL2();
            // SUPPRESSION DU L2 AVANT SAUVEGARDE
            VM.CurrentCandidat.DeleteCurrentLivret();

            Assert.IsTrue(VM.saveData());
            oConn.Open();
            ocmd.CommandText = "SELECT Count(*) from Juries";
            nJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Recours";
            nRecoursApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from PieceJointeL2";
            nPJL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from Livret2";
            nL2Apres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from MembreJuries";
            nMembreJuryApres = (Int32)(ocmd.ExecuteScalar());
            ocmd.CommandText = "SELECT Count(*) from DCLivrets";
            nDcLivretApres = (Int32)(ocmd.ExecuteScalar());
            oConn.Close();
            Assert.AreEqual(nJuryAvant + 1, nJuryApres, "Jury avant <> Jury après");
            Assert.AreEqual(nRecoursAvant + 1, nRecoursApres);
            Assert.AreEqual(nPJL2Avant + 0, nPJL2Apres);
            Assert.AreEqual(nMembreJuryAvant + 0, nMembreJuryApres);
            Assert.AreEqual(nL2Avant + 0, nL2Apres);
            Assert.AreEqual(nDcLivretAvant + 0, nDcLivretApres);

        }

    }
}
