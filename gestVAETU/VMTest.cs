using System;
using GestVAE.VM;
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

            VM.AddCandidatCommand.Execute(null);
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

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCAND").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(1, VM.CurrentCandidat.lstLivrets.Count);

            VM.CurrentCandidat.CurrentLivret = VM.CurrentCandidat.lstLivrets[0];
            oLiv = (Livret1VM)VM.CurrentCandidat.CurrentLivret;
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

            VM.AjouteL2();
            VM.ValideretQuitterL2();

            Livret2VM oLiv = (Livret2VM)oCand.CurrentLivret;
            oLiv.DecisionJury = "DECISIONJURYL2";
            Assert.IsTrue(VM.saveData());

            VM.getData();
            VM.CurrentCandidat = VM.lstCandidatVM.Where(i => i.Nom == "TESTCANDL2").FirstOrDefault();
            Assert.IsNotNull(VM.CurrentCandidat);
            Assert.AreEqual(1, VM.CurrentCandidat.lstLivrets.Count);

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

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.saveData();
            VM.getData();
            Assert.IsTrue(VM.SetCurrentCandidat("TESTCAND"));
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
        [TestMethod]
        public void testIsL1Valide()
        {
            MyViewModel VM = new MyViewModel();
            VM.IsInTest = true;
            VM.getData();

            VM.AddCandidatCommand.Execute(null);
            CandidatVM oCand = VM.CurrentCandidat;
            oCand.Nom = "TESTCAND";
            VM.saveData();

            Assert.IsFalse(oCand.IsL1Valide);
            //Ajout D'un L1
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            // Le L1 est EnCours même si  l'état n'est pas bon
            Assert.IsFalse(oCand.IsL1Valide);
            Assert.IsTrue(oCand.IsL1Encours);
            Livret1VM oL1 = (Livret1VM)oCand.CurrentLivret;
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


            VM.LockCurrentCandidat();
            VM.DeleteCurrentCandidat();
            VM.saveData();
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
            VM.CurrentCandidat.CurrentLivret.FTO_SetDecisionJuryL1Favorable();
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
            VM.AjouteL1();
            VM.ValideretQuitterL1();
            VM.saveData();
            VM.getData();
            Assert.IsTrue(VM.SetCurrentCandidat("TESTCAND"));
            Livret1VM oLiv = (Livret1VM) VM.CurrentCandidat.lstLivrets[0];

            Assert.AreEqual(VM.CurrentCandidat.DateCreation, oLiv.DateDemande);
            Assert.AreEqual(VM.CurrentCandidat.DateCreation, oLiv.DateEnvoiEHESP);


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

    }
}
