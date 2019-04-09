using System;
using GestVAE.VM;
using GestVAEcls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestVAETU
{
    [TestClass]
    public class ValidationTest:RootTest
    {
        [TestMethod]
        public void GESTVAE001()
        {
            MyViewModel VM = new MyViewModel();

            VM.rechNom = "TEST1";
            VM.Recherche();
            Assert.AreEqual(0, VM.lstCandidatVM.Count);

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";

            VM.saveData();
             VM = new MyViewModel();

            VM.rechNom = "TEST1";
            VM.Recherche();
            Assert.AreEqual(1, VM.lstCandidatVM.Count);

        }
        [TestMethod]
        public void GESTVAE002()
        {
            MyViewModel VM = new MyViewModel();

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel();
            VM.rechNom = "TEST1";
            VM.Recherche();
            Assert.AreEqual(1, VM.lstCandidatVM.Count);

            oCan = VM.lstCandidatVM[0];
            VM.CurrentCandidat = oCan;
            VM.LockCurrentCandidat();
            Assert.IsTrue(oCan.IsLocked);
            oCan.IdSiscole = "123456";
            VM.saveData();
            Assert.IsTrue(oCan.IsUnlocked);

            VM.rechNom = "TEST1";
            VM.Recherche();
            Assert.AreEqual(1, VM.lstCandidatVM.Count);

            oCan = VM.lstCandidatVM[0];
            Assert.IsTrue(oCan.IsUnlocked);
            Assert.AreEqual("123456",oCan.IdSiscole );



        }
        [TestMethod]
        public void GESTVAE003()
        {
            // GIVER 5 Candidats existent dans la base
            MyViewModel VM = new MyViewModel();

            VM.AddCandidat();
            VM.CurrentCandidat.Nom = "TEST1";
            VM.CurrentCandidat.Prenom = "Prenom1";
            VM.CurrentCandidat.Ville = "VILLE1";
            VM.AddCandidat();
            VM.CurrentCandidat.Nom = "TEST2";
            VM.CurrentCandidat.Prenom = "Prenom2";
            VM.CurrentCandidat.Ville = "VILLE2";
            VM.AddCandidat();
            VM.CurrentCandidat.Nom = "TEST3";
            VM.CurrentCandidat.Prenom = "Prenom3";
            VM.CurrentCandidat.Ville = "VILLE3";
            VM.AddCandidat();
            VM.CurrentCandidat.Nom = "TEST4";
            VM.CurrentCandidat.Prenom = "Prenom4";
            VM.CurrentCandidat.Ville = "VILLE4";
            VM.AddCandidat();
            VM.CurrentCandidat.Nom = "TEST5";
            VM.CurrentCandidat.Prenom = "Prenom5";
            VM.CurrentCandidat.Ville = "VILLE5";
            VM.saveData();

            VM = new MyViewModel();
            VM.rechPrenom = "Prenom3";
            VM.Recherche();
            Assert.AreEqual(1, VM.lstCandidatVM.Count);

            VM.rechPrenom = "";
            VM.Recherche();
            Assert.AreEqual(6, VM.lstCandidatVM.Count);

        }

        [TestMethod]
        public void GESTVAE004()
        {
            MyViewModel VM = new MyViewModel();

                VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            MyViewModel VM1 = new MyViewModel();
            VM1 = new MyViewModel();
            VM1.rechNom = "TEST1";
            VM1.Recherche();
            Assert.AreEqual(1, VM1.lstCandidatVM.Count);
            oCan = VM1.lstCandidatVM[0];
            VM1.CurrentCandidat = oCan;
            Assert.IsFalse(VM1.IsCurrentCandidatLocked);

            MyViewModel VM2 = new MyViewModel();
            VM2 = new MyViewModel();
            VM2.rechNom = "TEST1";
            VM2.Recherche();
            Assert.AreEqual(1, VM2.lstCandidatVM.Count);
            oCan = VM2.lstCandidatVM[0];
            VM2.CurrentCandidat = oCan;
            Assert.IsFalse(VM2.IsCurrentCandidatLocked);

            //Lock du candidat sur POSTE1
            VM1.LockCurrentCandidat();
            // Candidat Locker sur poste1
            Assert.IsTrue(VM1.IsCurrentCandidatLocked);
            //Loack candidat sur poste2
            VM2.LockCurrentCandidat();
            // Le candidat ne peut est locké
            Assert.IsTrue(VM2.IsCurrentCandidatLocked);
            Assert.IsFalse(VM2.IsCurrentCandidatLockedByMe);

            VM1.UnLockCurrentCandidat();
            Assert.IsFalse(VM1.IsCurrentCandidatLocked);
            VM2.LockCurrentCandidat();
            Assert.IsTrue(VM2.IsCurrentCandidatLocked);

            VM1.LockCurrentCandidat();
            Assert.IsTrue(VM1.IsCurrentCandidatLocked);
            Assert.IsFalse(VM1.IsCurrentCandidatLockedByMe);

        }

        [TestMethod]
        public void GESTVAE005()
        {
            MyViewModel VM = new MyViewModel();

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            MyViewModel VM1 = new MyViewModel();
            VM1 = new MyViewModel();
            VM1.rechNom = "TEST1";
            VM1.Recherche();
            Assert.AreEqual(1, VM1.lstCandidatVM.Count);
            oCan = VM1.lstCandidatVM[0];
            VM1.CurrentCandidat = oCan;
            Assert.IsFalse(VM1.IsCurrentCandidatLocked);

            MyViewModel VM2 = new MyViewModel();
            VM2 = new MyViewModel();
            VM2.rechNom = "TEST1";
            VM2.Recherche();
            Assert.AreEqual(1, VM2.lstCandidatVM.Count);
            oCan = VM2.lstCandidatVM[0];
            VM2.CurrentCandidat = oCan;
            Assert.IsFalse(VM2.IsCurrentCandidatLocked);

            //Lock du candidat sur POSTE1
            VM1.LockCurrentCandidat();
            // Candidat Locker sur poste1
            Assert.IsTrue(VM1.IsCurrentCandidatLocked);
            Assert.IsTrue(VM1.IsCurrentCandidatLockedByMe);
            //Loack candidat sur poste2
            VM2.LockCurrentCandidat();
            // Le candidat ne peut est locké
            Assert.IsTrue(VM2.IsCurrentCandidatLocked);
            Assert.IsFalse(VM2.IsCurrentCandidatLockedByMe);

            //poste1 Dévérouille Candidat
            VM1.UnLockCurrentCandidat();
            Assert.IsFalse(VM1.IsCurrentCandidatLocked);
            Assert.IsFalse(VM1.IsCurrentCandidatLockedByMe);
            Assert.IsFalse(VM2.IsCurrentCandidatLocked);
            Assert.IsFalse(VM2.IsCurrentCandidatLockedByMe);

        }
        [TestMethod]
        public void GESTVAE006()
        {
            MyViewModel VM = new MyViewModel();

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            MyViewModel VM1 = new MyViewModel();
            VM1 = new MyViewModel();
            VM1.rechNom = "TEST1";
            VM1.Recherche();
            Assert.AreEqual(1, VM1.lstCandidatVM.Count);
            oCan = VM1.lstCandidatVM[0];
            VM1.CurrentCandidat = oCan;
            Assert.IsFalse(VM1.IsCurrentCandidatLocked);

            MyViewModel VM2 = new MyViewModel();
            VM2 = new MyViewModel();
            VM2.rechNom = "TEST1";
            VM2.Recherche();
            Assert.AreEqual(1, VM2.lstCandidatVM.Count);
            oCan = VM2.lstCandidatVM[0];
            VM2.CurrentCandidat = oCan;
            Assert.IsFalse(VM2.IsCurrentCandidatLocked);

            //Lock du candidat sur POSTE1
            VM1.LockCurrentCandidat();
            // Candidat Locker sur poste1
            Assert.IsTrue(VM1.IsCurrentCandidatLocked);
            Assert.IsTrue(VM1.IsCurrentCandidatLockedByMe);

            // Le candidat ne peut est locké
            Assert.IsTrue(VM2.IsCurrentCandidatLocked);
            Assert.IsFalse(VM2.IsCurrentCandidatLockedByMe);

            VM1.CurrentCandidat.Ville = "VILLETEST";
            VM1.saveData();

            Assert.IsFalse(VM1.IsCurrentCandidatLocked);
            Assert.IsFalse(VM2.IsCurrentCandidatLocked);

        }
    [TestMethod]
        public void GESTVAE007()
        {
            MyViewModel VM = new MyViewModel();

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            MyViewModel VM1 = new MyViewModel();
            VM1 = new MyViewModel();
            VM1.rechNom = "TEST1";
            VM1.Recherche();
            Assert.AreEqual(1, VM1.lstCandidatVM.Count);
            oCan = VM1.lstCandidatVM[0];
            VM1.CurrentCandidat = oCan;
            Assert.IsFalse(VM1.IsCurrentCandidatLocked);

            MyViewModel VM2 = new MyViewModel();
            VM2 = new MyViewModel();
            VM2.rechNom = "TEST1";
            VM2.Recherche();
            Assert.AreEqual(1, VM2.lstCandidatVM.Count);
            oCan = VM2.lstCandidatVM[0];
            VM2.CurrentCandidat = oCan;
            Assert.IsFalse(VM2.IsCurrentCandidatLocked);

            //Lock du candidat sur POSTE1
            VM1.LockCurrentCandidat();
            // Candidat Locker sur poste1
            Assert.IsTrue(VM1.IsCurrentCandidatLocked);
            Assert.IsTrue(VM1.IsCurrentCandidatLockedByMe);

            // Le candidat ne peut est locké
            Assert.IsTrue(VM2.IsCurrentCandidatLocked);
            Assert.IsFalse(VM2.IsCurrentCandidatLockedByMe);

            // Fermeture de l'application
            VM1.UnlockCandidats();

            // Le candidat est Libéré sur le poste 2
            Assert.IsFalse(VM2.IsCurrentCandidatLocked);

        }
        [TestMethod]
        public void GESTVAE008()
        {
            MyViewModel VM = new MyViewModel();

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";

            VM.AddCandidat();
            oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST2";
            VM.saveData();

            MyViewModel VM1 ;
            VM1 = new MyViewModel();
            VM1.rechNom = "";
            VM1.Recherche();

            //Lock du candidat sur POSTE1
            VM1.CurrentCandidat = VM1.lstCandidatVM[0];
            VM1.LockCurrentCandidat();
            VM1.CurrentCandidat.DateNaissance = Convert.ToDateTime("1964-02-06");

            VM1.CurrentCandidat = VM1.lstCandidatVM[1];

            // Message D'alerte
            Assert.IsTrue(VM1.HasChanges());

            VM1.UnlockCandidats();

            // Rechargement du Candidat
            VM1 = new MyViewModel();
            VM1.rechNom = "";
            VM1.Recherche();
            VM1.CurrentCandidat = VM1.lstCandidatVM[0];
            Assert.IsNull(VM1.CurrentCandidat.DateNaissance);


        }
        [TestMethod]
        public void GESTVAE010()
        {
            MyViewModel VM = new MyViewModel();

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";

            VM.AddCandidat();
            oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST2";
            VM.saveData();

            MyViewModel VM1;
            VM1 = new MyViewModel();
            VM1.rechNom = "";
            VM1.Recherche();

            //Lock du candidat sur POSTE1
            VM1.CurrentCandidat = VM1.lstCandidatVM[0];
            VM1.LockCurrentCandidat();
            VM1.CurrentCandidat.DateNaissance = Convert.ToDateTime("1964-02-06");

            VM1.CurrentCandidat = VM1.lstCandidatVM[1];

            VM1.saveData();
            // Message D'alerte
            Assert.IsFalse(VM1.HasChanges());


            // Rechargement du Candidat
            VM1 = new MyViewModel();
            VM1.rechNom = "";
            VM1.Recherche();
            VM1.CurrentCandidat = VM1.lstCandidatVM[0];
            Assert.IsNotNull(VM1.CurrentCandidat.DateNaissance);


        }
        [TestMethod]
        public void GESTVAE011()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";

            VM.AddCandidat();
            oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST2";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            Assert.IsFalse(VM.AjouteL1Command.CanExecute(null));
            VM.LockCurrentCandidat();
            Assert.IsTrue(VM.AjouteL1Command.CanExecute(null));

            // Ajout du Livret1
            VM.AjouteL1();
            VM.ValideretQuitterL1();

            // Vérification que le livret est bien ajouté à la liste
            Assert.AreEqual(1, VM.CurrentCandidat.lstLivrets.Count);

            // Sauvegarde des Données
            VM.saveData();

            // rechargement du Model
            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.RechercherCommand.Execute(null);
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            // Le Livret est bien Dans la base
            Assert.AreEqual(1, VM.CurrentCandidat.lstLivrets.Count);

        }
        /// <summary>
        /// Ajout de L1 Date de validité > Ajourd'hui
        /// </summary>
        [TestMethod]
        public void GESTVAE012()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";

            VM.AddCandidat();
            oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST2";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            Assert.IsFalse(VM.AjouteL1Command.CanExecute(null));
            VM.LockCurrentCandidat();
            Assert.IsTrue(VM.AjouteL1Command.CanExecute(null));

            // Ajout du Livret1
            VM.AjouteL1();
            VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE + "-Favorable";
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
            VM.ValideretQuitterL1();
            // L'ajout de L1 n'est plus possible
            Assert.IsFalse(VM.AjouteL1Command.CanExecute(null));
        }
        /// <summary>
        /// Ajout de L1 Date de validité < Ajourdhui
        /// </summary>
        [TestMethod]
        public void GESTVAE012b()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";

            VM.AddCandidat();
            oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST2";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            Assert.IsFalse(VM.AjouteL1Command.CanExecute(null));
            VM.LockCurrentCandidat();
            Assert.IsTrue(VM.AjouteL1Command.CanExecute(null));

            // Ajout du Livret1
            VM.AjouteL1();
            VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE + "-Favorable";
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(-1);
            VM.ValideretQuitterL1();
            // L'ajout de L1 Devient possible 
            Assert.IsTrue(VM.AjouteL1Command.CanExecute(null));
        }

    /// <summary>
    /// Ajout de L1Décision défavorable
    /// </summary>
    [TestMethod]
    public void GESTVAE013()
    {
        MyViewModel VM = new MyViewModel(true);

        VM.AddCandidat();
        CandidatVM oCan = VM.CurrentCandidat;
        oCan.Nom = "TEST1";

        VM.AddCandidat();
        oCan = VM.CurrentCandidat;
        oCan.Nom = "TEST2";
        VM.saveData();

        VM = new MyViewModel(true);
        VM.rechNom = "TEST1";
        VM.Recherche();

        //Lock du candidat sur POSTE1
        VM.CurrentCandidat = VM.lstCandidatVM[0];
        Assert.IsFalse(VM.AjouteL1Command.CanExecute(null));
        VM.LockCurrentCandidat();
        Assert.IsTrue(VM.AjouteL1Command.CanExecute(null));

        // Ajout du Livret1
        VM.AjouteL1();
        VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE + "-DéFavorable";
            // Date de validé > Ajourd'hui
        VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
        VM.ValideretQuitterL1();
        // L'ajout de L1 Est impossible
        Assert.IsFalse(VM.AjouteL1Command.CanExecute(null));
       // Modification de la date de Validié < Ajourd'hui
        VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(-1);
        VM.ValideretQuitterL1();
        // L'ajout de L1 Est Possible
        Assert.IsTrue(VM.AjouteL1Command.CanExecute(null));
        }

        /// <summary>
        /// Ajout de L2 : Validité du L1
        /// </summary>
        [TestMethod]
        public void GESTVAE014()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            // Avant Verrouillage => Ajout L2 impossible
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));
            VM.LockCurrentCandidat();
            // Après Verrouillage => Ajout L2 impossible car pas de L1
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));

            // Ajout du Livret1
            VM.AjouteL1();
            VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL1.DECISION_L1_DEFAVORABLE + "-DéFavorable";
            // Date de validé > Ajourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
            VM.ValideretQuitterL1();
            // L'ajout de L2 Est impossible car le L1 n'est pas valide
            Assert.IsFalse(VM.AjouteL1Command.CanExecute(null));
            // Modification de la date de Validié < Ajourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(-1);
            VM.ValideretQuitterL1();
            // L'ajout de L2 Est impossible car le L1 n'est pas valide
            Assert.IsTrue(VM.AjouteL1Command.CanExecute(null));
        }

        /// <summary>
        /// Ajout de L2 :  L1 Favoravle (Date De validité)
        /// </summary>
        [TestMethod]
        public void GESTVAE015()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            // Avant Verrouillage => Ajout L2 impossible
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));
            VM.LockCurrentCandidat();
            // Après Verrouillage => Ajout L2 impossible car pas de L1
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));

            // Ajout du Livret1
            VM.AjouteL1();
            VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE + "-Favorable";
            // Date de validé > Ajourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
            VM.ValideretQuitterL1();
            // L'ajout de L2 Est Possible car le L1 est valide
            Assert.IsTrue(VM.AjouteL2Command.CanExecute(null));
            // Modification de la date de Validié < Ajourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(-1);
            VM.ValideretQuitterL1();
            // L'ajout de L2 Est impossible car le L1 n'est pas valide
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));
        }//GestVAE015

        /// <summary>
        /// Ajout de L2 : Validité du L2
        /// </summary>
        [TestMethod]
        public void GESTVAE016()
        {
            MyViewModel VM = new MyViewModel(true);

            VM.AddCandidat();
            CandidatVM oCan = VM.CurrentCandidat;
            oCan.Nom = "TEST1";
            VM.saveData();

            VM = new MyViewModel(true);
            VM.rechNom = "TEST1";
            VM.Recherche();

            //Lock du candidat sur POSTE1
            VM.CurrentCandidat = VM.lstCandidatVM[0];
            // Avant Verrouillage => Ajout L2 impossible
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));
            VM.LockCurrentCandidat();

            // Ajout du Livret1 Favorable Date de valiité > Aujourd'hui
            VM.AjouteL1();
            VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL1.DECISION_L1_FAVORABLE + "-Favorable";
            // Date de validé > Ajourd'hui
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
            VM.ValideretQuitterL1();

            // Ajout d'un Livret2 (non complet)
            VM.AjouteL2();
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
            VM.ValideretQuitterL2();
            //Ajout de L2 impossible car L2 en cours
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));
            // Le L2 est périmé => L'ajout de L2 est possible
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(-1);
            Assert.IsTrue(VM.AjouteL2Command.CanExecute(null));
            // Decision = Favorable DateValidité > Now
            VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE + "-Favorable";
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));
            // Decision = Favorable DateValidité < Now
            VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL2.DECISION_L2_FAVORABLE + "-Favorable";
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(-1);
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));
            // Decision = DéFavorable DateValidité < Now
            VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE + "-DéFavorable";
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(-1);
            Assert.IsTrue(VM.AjouteL2Command.CanExecute(null));
            // Decision = DéFavorable DateValidité > Now
            VM.CurrentCandidat.CurrentLivret.DecisionJury = MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE + "-DéFavorable";
            VM.CurrentCandidat.CurrentLivret.DateValidite = DateTime.Now.AddDays(1);
            Assert.IsFalse(VM.AjouteL2Command.CanExecute(null));



        }//GestVAE016
    }//class ValidationTest
}
