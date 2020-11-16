
using GestVAEcls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestVAE.VM
{
    //public enum Statuts { ACCEPTE, REFUSE};
    public class MyViewModel : NotifyUIBase
    {
        private Context _ctx;
        private ContextParam _ctxParam;
        private bool _modelhasChanges = false;
        private ObservableCollection<CandidatVM> _lstCandidatVM;
        private ObservableCollection<RegionVM> _lstRegionVM;
        private ObservableCollection<DiplomeVM> _lstDiplomeVM;
        private ObservableCollection<PieceJointeCategorie> _lstPieceJointeCategorie;
        private ObservableCollection<MotifGeneralL1> _lstMotifGL1;
        private ObservableCollection<MotifGeneralL2> _lstMotifGL2;
        private Boolean _isBusy;
        private CandidatVM _candidatVM;
        public Action CloseAction { get; set; }
        public List<BDMembreJury> lstParamBDMembreJury { get; set; }
        public ObservableCollection<ParamCollege> lstParamCollege { get; set; }
        public ObservableCollection<ParamDepartement> lstParamDepartement { get; set; }
        public ObservableCollection<ParamTypeDemande> lstParamTypeDemande { get; set; }
        public ObservableCollection<ParamVecteurInformation> lstParamVecteurInformation { get; set; }
        private Int32 _ContextID=0;
        public CandidatVM CurrentCandidat
        {
            get { return _candidatVM; }
            set {
               
                _candidatVM = value;
                if (CurrentCandidat != null)
                {
                    CurrentCandidat.LoadDetails();
                }
                RaisePropertyChanged("IsCurrentCandidatLockable");
                RaisePropertyChanged("IsCurrentCandidatSelected");
                RaisePropertyChanged(); }
        }
        public String AppVersion
        {
            get { return Properties.Settings.Default.NUMVERSION; }
        }
        public String ContextID
        {
            get { return String.Format("{0}", _ContextID); }
        }

        public String DBVersion
        {
        get {
                String strReturn = "";
                Context ctx = Context.instance;
                ctx.Database.Connection.Open();
                DbCommand oCmd = ctx.Database.Connection.CreateCommand();
                oCmd.CommandText = "SELECT MigrationId from __MigrationHistory ORDER BY MigrationId ";
                DbDataReader oReader =   oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    strReturn = oReader.GetString(0);
                }
                oReader.Close();
                ctx.Database.Connection.Close();
                if (strReturn!= "")
                {
                    String[] tab = strReturn.Split('_');
                    if (tab.Length >0)
                    {
                        strReturn = tab[0];
                    }

                }

                return strReturn;
            }
        }//DBVersion

        public Boolean IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsInTest { get; set; }

        public MyViewModel()
        {
            IsInTest = false;
            Reset();
            //getData();
        }
        public MyViewModel(Boolean pIsInTest) :this()
        {
            IsInTest = pIsInTest;
        }
        private void Reset()
        {
            Context.Reset();
            _ctx = Context.instance;
            _ctxParam = new ContextParam();

            _lstCandidatVM = new ObservableCollection<CandidatVM>();
            _lstRegionVM = new ObservableCollection<RegionVM>();
            _lstDiplomeVM = new ObservableCollection<DiplomeVM>();
            _lstPieceJointeCategorie = new ObservableCollection<PieceJointeCategorie>();
            _lstMotifGL1 = new ObservableCollection<MotifGeneralL1>();
            _lstMotifGL2 = new ObservableCollection<MotifGeneralL2>();
            lstParamCollege = new ObservableCollection<ParamCollege>();
            lstParamDepartement = new ObservableCollection<ParamDepartement>();
            lstParamTypeDemande = new ObservableCollection<ParamTypeDemande>();
            lstParamVecteurInformation = new ObservableCollection<ParamVecteurInformation>();
            // génération d'un Numéro d'ID
            // on attends 1 ms pour être sur que 2 contextes ne sont pas créés en même temps (CF test de validation)
            // Pas parfait mais je n'ai pas envie de changer le type du contexteID dans la base.
            Thread.Sleep(1);
            _ContextID = Convert.ToInt32(DateTime.Now.ToString("fffffff"));

            CreateCommands();

        }
        private void CreateCommands()
        {
            _SaveCommand = new SaveCommand(o => { saveData(); },
                                           o => { return HasChanges(); }
                                          );
            UnLockAllCommand = new RelayCommand<MyViewModel>(o => { UnlockAll(); },
                                                            o => { return IsAnyLock(); }
                                          );
            _AddCandidatCommand = new RelayCommand<CandidatVM>(o => { AjouteCandidat(); }
                                           );
            _dlgParamCommand = new RelayCommand<MyViewModel>(o => { CalldlgParam(); }
                                           );
            _ValiderParametresCommand = new RelayCommand<dlgParametre>(o => { ValiderdlgParam(o); }
                                           );
            dlgAProposCommand = new RelayCommand<MyViewModel>(o => { CalldlgAPropos(); }
                                           );
            _RechercherCommand = new RelayCommand<MyViewModel>(o => { Recherche(); }
                                           );
            AjouteDiplomeCandCommand = new RelayCommand<MyViewModel>(o => { AjouteDiplomeCand(); }
                                           );
            IsPostFormationCommand = new RelayCommand<bool>(o => { IsPostFormation(o); }
                                           );
            AjouteL1Command = new RelayCommand<MyViewModel>(o => { AjouteL1(); },
                                                            o => { return IsCurrentCandidatAddL1Available; }
                                           );
            AjoutePJL1Command = new RelayCommand<MyViewModel>(o => { AjoutePJL1(); },
                                                              o => { return IsAjoutPJPossible(); }
                                           );
            AjoutePJL2Command = new RelayCommand<MyViewModel>(o => { AjoutePJL2(); },
                                                                o => { return IsAjoutPJPossible(); }
                                           );
            DeletePJCommand = new RelayCommand<MyViewModel>(o => { DeletePJ(); },
                                                            o => { return IsDeletePJPossible(); }
                                           );
            DeleteMembreJuryCommand = new RelayCommand<MyViewModel>(o => { DeleteMembreJury(); }
                                           );
            AjouterMembreJuryCommand = new RelayCommand<MyViewModel>(o => { AjouterMembreJury(); }
                                            );
            AjouteL2Command = new RelayCommand<MyViewModel>(o => { AjouteL2(); },
                                                            o => { return IsCurrentCandidatAddL2Available; }
                                            );
            dlgDiplomeCommand = new RelayCommand<MyViewModel>(o => { GestionDiplome(); }
                                           );
            ValideretQuitterL1Command = new RelayCommand<MyViewModel>(o => { ValideretQuitterL1(); },
                                                                        o => { return IsValiderEtQuitterAvailable; }
                                           );
            ValideretQuitterL2Command = new RelayCommand<MyViewModel>(o => { ValideretQuitterL2(); },
                                                                        o => { return IsValiderEtQuitterAvailable; }
                                           );
            CloturerL1etCreerL2Command = new RelayCommand<MyViewModel>(o => { CloturerL1etCreerL2(); }
                                           );
            CloseCommand = new RelayCommand<MyViewModel>(o => { QuitterLivret(); }
                                           );
            DeleteCandidatCommand = new RelayCommand<MyViewModel>(o => { DeleteCurrentCandidat(); }
                                           );
            DeleteDiplomeCandCommand = new RelayCommand<MyViewModel>(o => { DeleteDiplomeCand(); }
                                           );

            CloturerL2Command = new RelayCommand<MyViewModel>(o => { CloturerL2(); }
                                           );
            LockCommand = new RelayCommand<MyViewModel>(o => { LockCurrentCandidat(); },
                                                        o => { return IsCurrentCandidatLockable(); }
                                                        );

            UnLockCommand = new RelayCommand<MyViewModel>(o => { UnLockCurrentCandidat(); },
                                                        o => { return this.IsCurrentCandidatLockedByMe; }
                                                        );
            ExecSQLCommand = new RelayCommand<MyViewModel>(o => { ExecSQL(); }
                                                        );
            DecloturerLivretCommand = new RelayCommand<MyViewModel>(o => { DecloturerLivret(); }
                                                        );
            DoubleClickCandidat = new RelayCommand<MyViewModel>(o => { DoubleClickSurCandidat(); }
                                                                    );

            ExporterDataCommand = new RelayCommand<MyViewModel>(o => { exporterData(); }
                                                                        );

            _RechercherBaseMembreJurycommand = new RelayCommand<MyViewModel>(o => { RechercherBaseMembreJury(); }
                                                                    );

            CommentaireCommand = new RelayCommand<MyViewModel>(o => { Commentaire(); });
        }//Createcommand

        public ObservableCollection<CandidatVM> lstCandidatVM
        {
            get {return _lstCandidatVM;}
            set
            {
                if (value != _lstCandidatVM)
                {
                    _lstCandidatVM = value;
                    RaisePropertyChanged();
                };
            }
        }
        public ObservableCollection<RegionVM> lstRegionVM
        {
            get {return _lstRegionVM;}
            set
            {
                if (value != _lstRegionVM)
                {
                    _lstRegionVM = value;
                    RaisePropertyChanged();
                };
            }
        }
        public ObservableCollection<DiplomeVM> lstDiplomeVM
        {
            get {return  _lstDiplomeVM;}

        }
        public ObservableCollection<PieceJointeCategorie> lstPieceJointeCategorie
        {
            get {return  _lstPieceJointeCategorie;}

        }
        public ObservableCollection<MotifGeneralL1> lstMotifGL1
        {
            get {return  _lstMotifGL1;}

        }
        public ObservableCollection<MotifGeneralL2> lstMotifGL2
        {
            get { return _lstMotifGL2; }
        }
        public List<String> LstEtatLivret1
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add(String.Format("{0:D}-Sans_Suite", MyEnums.EtatL1.ETAT_L1_SANS_SUITE));
                oReturn.Add(String.Format("{0:D}-Demandé", MyEnums.EtatL1.ETAT_L1_DEMANDE));
                oReturn.Add(String.Format("{0:D}-Envoyé", MyEnums.EtatL1.ETAT_L1_ENVOYE));
                oReturn.Add(String.Format("{0:D}-Reçu incomplet", MyEnums.EtatL1.ETAT_L1_RECU_INCOMPLET));
                oReturn.Add(String.Format("{0:D}-Reçu complet", MyEnums.EtatL1.ETAT_L1_RECU_COMPLET));
                oReturn.Add(String.Format("{0:D}-Défavorable", MyEnums.EtatL1.ETAT_L1_REFUSE));
                oReturn.Add(String.Format("{0:D}-Favorable", MyEnums.EtatL1.ETAT_L1_ACCEPTE));
                return oReturn;
            }
            set { }
        }
        public List<String> LstEtatLivret2
        {
            get
            {
                List<String> oReturn = new List<String>();
                oReturn.Add(String.Format("{0:D}-Demandé", MyEnums.EtatL1.ETAT_L1_DEMANDE));
                oReturn.Add(String.Format("{0:D}-Envoyé", MyEnums.EtatL1.ETAT_L1_ENVOYE));
                oReturn.Add(String.Format("{0:D}-Reçu incomplet", MyEnums.EtatL1.ETAT_L1_RECU_INCOMPLET));
                oReturn.Add(String.Format("{0:D}-Reçu complet", MyEnums.EtatL1.ETAT_L1_RECU_COMPLET));
                oReturn.Add(String.Format("{0:D}-Défavorable", MyEnums.EtatL1.ETAT_L1_REFUSE));
                //                oReturn.Add(String.Format("{0:D}-Recours", MyEnums.EtatL1.ETAT_L1_RECOURS));
                oReturn.Add(String.Format("{0:D}-Accepté", MyEnums.EtatL1.ETAT_L1_ACCEPTE));
                return oReturn;
            }
            set { }
        }

        public Boolean saveData()
        {
            Boolean bReturn = true;
            IsBusy = true;
            try
            {
                foreach (CandidatVM item in lstCandidatVM.Where(i=>i.IsLocked))
                {
                        if (item.IsDeleted)
                        {
                            _ctx.DeleteOnCascade(item.TheCandidat);
                       // _ctx.Candidats.Remove(item.TheCandidat);
                        }
                        else
                        {
                            item.Commit();
                        }
                }

//                 _ctx.DeleteOnCascade();
                _ctx.SaveChanges();
                UnlockCandidats();
                _modelhasChanges = false;
                if (CurrentCandidat != null)
                {
                    CurrentCandidat.SetModelHasChanges(false);
                }
                bReturn = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                bReturn = false;
            }
            IsBusy = false;
            return bReturn;
        }//SaveData


        public void getData()
        {
            CSDebug.TraceINFO("MyViwModel.getData : START");
            try
            {

                IsBusy = true;
            _lstCandidatVM.Clear();
            foreach (Candidat item in _ctx.Candidats)
            {
                if (item.Sexe == null)
                {
                    item.Sexe = Sexe.H;
                }

                CandidatVM oCand = new CandidatVM(item);
                _lstCandidatVM.Add(oCand);
            }
            CurrentCandidat = null;
            if (lstCandidatVM.Count > 0)
            {
                CurrentCandidat = _lstCandidatVM[0];
            }

            RaisePropertyChanged("lstCandidatVM");
            RaisePropertyChanged("CurrentCandidat");


            IsBusy = false;
        }
           catch (Exception ex )
            {

                CSDebug.TraceException("MyViewModel.getData : ", ex);
            }

            CSDebug.TraceINFO("MyViwModel.getData : END");

        }
        public void getParams()
        {
            try
            {
                IsBusy = true;
                // Créatino du CAFDES si Necessaire
                Diplome oDipCAFDES = Diplome.getDiplomeParDefaut();

                if (oDipCAFDES == null)
                {
                    oDipCAFDES = new Diplome("CAFDES");
                    oDipCAFDES.addDomainecompetence("DC1");
                    oDipCAFDES.addDomainecompetence("DC2");
                    oDipCAFDES.addDomainecompetence("DC3");
                    oDipCAFDES.addDomainecompetence("DC4");

                    _ctx.Diplomes.Add(oDipCAFDES);
                }

                _lstRegionVM.Clear();

                foreach (Region item in _ctxParam.Regions)
                {
                    RegionVM oItVM = new RegionVM(item);
                    _lstRegionVM.Add(oItVM);
                }
                RaisePropertyChanged("lstRegionVM");

                _lstDiplomeVM.Clear();
                foreach (Diplome item in _ctx.Diplomes)
                {
                    DiplomeVM oItVM = new DiplomeVM(item);
                    _lstDiplomeVM.Add(oItVM);
                }
                RaisePropertyChanged("lstDiplomeVM");

                _lstPieceJointeCategorie.Clear();
                foreach (PieceJointeCategorie item in _ctxParam.pieceJointeCategories)
                {
                    //DiplomeVM oItVM = new DiplomeVM(item);
                    _lstPieceJointeCategorie.Add(item);
                }
                RaisePropertyChanged("lstPieceJointeCategorie");

                _lstMotifGL1.Clear();
                foreach (MotifGeneralL1 item in _ctxParam.dbMotifGeneralL1)
                {
                    _lstMotifGL1.Add(item);
                }
                RaisePropertyChanged("lstMotifGL1");

                _lstMotifGL2.Clear();
                foreach (MotifGeneralL2 item in _ctxParam.dbMotifGeneralL2)
                {
                    _lstMotifGL2.Add(item);
                }
                RaisePropertyChanged("lstMotifGL2");

                lstParamCollege.Clear();
                foreach (ParamCollege item in _ctxParam.dbParamCollege)
                {
                    lstParamCollege.Add(item);
                }
                lstParamDepartement.Clear();
                foreach (ParamDepartement item in _ctxParam.dbParamDepartement)
                {
                    lstParamDepartement.Add(item);
                }
                lstParamTypeDemande.Clear();
                foreach (ParamTypeDemande item in _ctxParam.dbParamTypeDemande)
                {
                    lstParamTypeDemande.Add(item);
                }
                lstParamVecteurInformation.Clear();
                foreach (ParamVecteurInformation item in _ctxParam.dbParamVecteurInformation)
                {
                    lstParamVecteurInformation.Add(item);
                }

                try
                {
                    lstParamBDMembreJury = BDMembreJury.loadFrom(ParamPathToBaseJury);
                }
                catch (Exception ex)
                {
                    MessageBoxShow("erreur en chargement de la liste des membres du jurys:" + ex.Message);
                }



                IsBusy = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
                CSDebug.TraceException("MyViewModel.getParam : ", ex);
            }

            CSDebug.TraceINFO("MyViwModel.getParam : END");

        }//getParam

        public void populate()
        {

            String[] tabvecteurs = new string[]
            {
                "Ehesp (autre)",
"site Ehesp",
"Établissements de formation CAFDES",
"Site établissements de formation CAFDES",
"Organisme de formation (suite à une prestation)",
"Directeur, RH",
"Collègues",
"DRASS",
"PIC/PRC",
"ASH",
"Gazette des communes",
"Direction",
"TSA",
"Autres",
"Presse",
"Salon Géront'Expo",
"Pôle Emploi (ANPE)",
"ASP (CNASEA)",
"Internet (autres sites…)",
"Non renseigné"
            };
            Random oRand = new Random();
            foreach (Candidat item in _ctx.Candidats)
            {
                if (item.lstLivrets1.Count == 1)
                {
                    Livret1 oL1 = item.lstLivrets1[0];
                    oL1.VecteurInformation = tabvecteurs[oRand.Next(0, 20)];
                }
            }

            RaisePropertyChanged("lstCandidatsVM");
        }
        public void AjouteCandidat()
        {
            Candidat oCand = new Candidat("[Nouveau candidat]");
            _ctx.Candidats.Add(oCand);
            CandidatVM oCandVM = new CandidatVM(oCand);
            oCandVM.Sexe = Sexe.H;
            oCandVM.Nationnalite = "Française";
            oCandVM.NationnaliteNaissance = "Française";
            if (String.IsNullOrEmpty(oCandVM.IdVAE))
            {
                oCandVM.IdVAE = "3" + DateTime.Now.ToString("yy") + ParamVM.incrementCandidat().ToString("00000");
            }
            lstCandidatVM.Add(oCandVM);
            CurrentCandidat = oCandVM;
            LockCurrentCandidat();
            RaisePropertyChanged("lstCandidatVM");
        }


        private ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _SaveCommand;
            }
        }


        private ICommand _AddCandidatCommand;

        public ICommand AddCandidatCommand
        {
            get { return _AddCandidatCommand; }
        }
        public ICommand dlgAProposCommand { get; set; }

        private ICommand _dlgParamCommand;
        public ICommand dlgParamCommand
        {
            get { return _dlgParamCommand; }
        }

        private ICommand _ValiderParametresCommand;
        public ICommand ValiderParametresCommand
        {
            get { return _ValiderParametresCommand; }
        }
        private ICommand _RechercherBaseMembreJurycommand;
        public ICommand RechercherBaseMembreJurycommand
        {
            get { return _RechercherBaseMembreJurycommand; }
        }

        private ICommand _RechercherCommand;

        public ICommand RechercherCommand
        {
            get { return _RechercherCommand; }
        }
        public ICommand dlgDiplomeCommand { get; set; }
        public ICommand AjouteDiplomeCandCommand { get; set; }
        public ICommand AjouteL1Command { get; set; }
        public ICommand AjoutePJL1Command { get; set; }
        public ICommand AjoutePJL2Command { get; set; }
        public ICommand DeletePJCommand { get; set; }
        public ICommand DeleteMembreJuryCommand { get; set; }
        public ICommand IsPostFormationCommand { get; set; }
        public ICommand AjouteL2Command { get; set; }
        public ICommand ValideretQuitterL1Command { get; set; }
        public ICommand ValideretQuitterL2Command { get; set; }
        public ICommand CloturerL1etCreerL2Command { get; set; }
        public ICommand CloturerL2Command { get; set; }
        public ICommand AjouterMembreJuryCommand { get; set; }
        public ICommand DecloturerLivretCommand { get; set; }
        public ICommand DoubleClickCandidat { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand DeleteCandidatCommand { get; set; }
        public ICommand DeleteDiplomeCandCommand { get; set; }
        public ICommand LockCommand { get; set; }
        public ICommand UnLockCommand { get; set; }
        public ICommand UnLockAllCommand { get; set; }
        public ICommand ExecSQLCommand { get; set; }
        public ICommand ExporterDataCommand { get; set; }
        public ICommand CommentaireCommand { get; set; }
        public String rechIdentifiantVAE { get; set; }
        public String rechIdentifiantSISCOLE { get; set; }
        public String rechNom { get; set; }
        public String rechPrenom { get; set; }
        public String rechVille { get; set; }
        public Boolean rechbHandicap { get; set; }
        public DateTime? rechDateNaissance { get; set; }
        public DateTime? rechDateReceptL1Deb { get; set; }
        public DateTime? rechDateReceptL1Fin { get; set; }
        public DateTime? rechDateReceptL2Deb { get; set; }
        public DateTime? rechDateReceptL2Fin { get; set; }
        public DateTime? rechDateValidL1Deb { get; set; }
        public DateTime? rechDateValidL1Fin { get; set; }
        public DateTime? rechDateValidL2Deb { get; set; }
        public DateTime? rechDateValidL2Fin { get; set; }
        public String rechEtatL1 { get; set; }
        public String rechEtatL2 { get; set; }

        public Boolean Recherche(Boolean pForce = false)
        {
            Boolean bReturn = true;
            // S'il y a des Modif et que je suis pas en mode force
            if (HasChanges() && ! pForce )
            {
                bReturn = false;
                if (!IsInTest)
                {
                    if (MessageBox.Show("Attention, certaines modifications seront perdues.\nVoulez-vous Continuer sans sauvegarder?", "ATTENTION", MessageBoxButton.YesNo, MessageBoxImage.Warning)
    == MessageBoxResult.Yes)
                    {
                        UnlockCandidats();
                        Reset();
                        getParams();
                        bReturn = true;
                    }

                }
            }
            if (bReturn)
            {
                IsBusy = true;
                IQueryable<Candidat> rq;

                rq = _ctx.Candidats;
                if (!String.IsNullOrEmpty(rechIdentifiantVAE))
                {
                    rq = rq.Where(c => c.IdVAE.Equals(rechIdentifiantVAE));
                }
                if (!String.IsNullOrEmpty(rechIdentifiantSISCOLE))
                {
                    rq = rq.Where(c => c.IdSiscole.Equals(rechIdentifiantSISCOLE));
                }
                if (!String.IsNullOrEmpty(rechNom))
                {
                    if (rechNom.Contains("%"))
                    {
                        rq = rq.Where(c => c.Nom.Contains(rechNom.Replace("%", "")));
                    }
                    else
                    {
                        rq = rq.Where(c => c.Nom.Equals(rechNom));
                    }
                }
                if (!String.IsNullOrEmpty(rechPrenom))
                {
                    if (rechPrenom.Contains("%"))
                    {
                        rq = rq.Where(c => c.Prenom.Contains(rechPrenom.Replace("%", "")));
                    }
                    else
                    {
                        rq = rq.Where(c => c.Prenom.Equals(rechPrenom));
                    }
                }
                if (!String.IsNullOrEmpty(rechVille))
                {
                    if (rechVille.Contains("%"))
                    {
                        rq = rq.Where(c => c.Ville.Contains(rechVille.Replace("%", "")));
                    }
                    else
                    {
                        rq = rq.Where(c => c.Ville.Contains(rechVille));
                    }
                }
                if (rechDateNaissance != null)
                {
                    rq = rq.Where(c => c.DateNaissance.Value.Equals(rechDateNaissance.Value));

                }
                if (!String.IsNullOrEmpty(rechEtatL1))
                {
                    rq = rq.Where(c => c.lstLivrets1.Where(L1 => L1.EtatLivret == rechEtatL1).Count() > 0);

                }
                if (!String.IsNullOrEmpty(rechEtatL2))
                {
                    rq = rq.Where(c => c.lstLivrets2.Where(L2 => L2.EtatLivret == rechEtatL2).Count() > 0);

                }
                if (rechDateReceptL1Deb != null)
                {
                    rq = rq.Where(c => c.lstLivrets1.Where(L1 => L1.DateReceptEHESP >= rechDateReceptL1Deb).Count() > 0);
                }
                if (rechDateReceptL1Fin != null)
                {
                    rq = rq.Where(c => c.lstLivrets1.Where(L1 => L1.DateReceptEHESP <= rechDateReceptL1Fin).Count() > 0);

                }
                if (rechDateReceptL2Deb != null)
                {
                    rq = rq.Where(c => c.lstLivrets2.Where(L2 => L2.DateReceptEHESP >= rechDateReceptL2Deb).Count() > 0);
                }
                if (rechDateReceptL2Fin != null)
                {
                    rq = rq.Where(c => c.lstLivrets2.Where(L2 => L2.DateReceptEHESP <= rechDateReceptL2Fin).Count() > 0);

                }
                if (rechDateValidL1Deb != null)
                {
                    rq = rq.Where(c => c.lstLivrets1.Where(L1 => 
                                                        L1.lstJurys.Where(J=>J.DateJury>=rechDateValidL1Deb || (J.DateNotificationJuryRecours!= null && J.DateNotificationJuryRecours>=rechDateValidL1Deb) ).Count()>0).Count()>0);
                }
                if (rechDateValidL1Fin != null)
                {
                    rq = rq.Where(c => c.lstLivrets1.Where(L1 =>
                                                        L1.lstJurys.Where(J => J.DateJury >= rechDateValidL1Deb || (J.DateNotificationJuryRecours != null && J.DateNotificationJuryRecours <= rechDateValidL1Fin)).Count() > 0).Count() > 0);

                }
                if (rechDateValidL2Deb != null)
                {
                    rq = rq.Where(c => c.lstLivrets2.Where(L2 =>
                                                        L2.lstJurys.Where(J => J.DateNotificationJury >= rechDateValidL2Deb).Count() > 0).Count() > 0);
                }
                if (rechDateValidL2Fin != null)
                {
                    rq = rq.Where(c => c.lstLivrets2.Where(L2 =>
                                                        L2.lstJurys.Where(J => J.DateNotificationJury <= rechDateValidL2Fin).Count() > 0).Count() > 0);

                }
                if (rechbHandicap)
                {
                    rq = rq.Where(c => c.bHandicap);

                }
                _lstCandidatVM.Clear();
                foreach (Candidat item in rq)
                {

                    CandidatVM oCand = new CandidatVM(item);
                    _lstCandidatVM.Add(oCand);
                }
                if (_lstCandidatVM.Count > 0)
                {
//                    CurrentCandidat = _lstCandidatVM[0];
                    
                }
                else
                {
                    CurrentCandidat = null;
                }
                RaisePropertyChanged("lstCandidatVM");
                RaisePropertyChanged("CurrentCandidat");
                IsBusy = false;

            }
            return bReturn;
        }//recherche

        public void AjouteDiplomeCand()
        {
            CandidatVM oCandVM = CurrentCandidat;
            oCandVM.AjoutDiplomeCand();


        }
        public void IsPostFormation(bool pValue)
        {

            CurrentCandidat.IsPostFormation = pValue;
            if (CurrentCandidat.IsPostFormation)
            {
                if (!IsInTest)
                {
                    if (CurrentCandidat.CurrentDiplomeCand != null)
                    {
                        dlgDiplomeCand odlg = new dlgDiplomeCand();
                        odlg.setContexte(this);

                        odlg.ShowDialog();
                    }
                }

            }
        }

        /// <summary>
        /// Ajout d'un livret1 au candidat
        /// </summary>
        public void AjouteL1()
        {
            Debug.Assert(CurrentCandidat != null);

            CandidatVM oCandVM = CurrentCandidat;
            Livret1VM oLivVM = new Livret1VM(CurrentCandidat.IsLocked);
            oLivVM.LstEtatLivret = LstEtatLivret1;
            oLivVM.EtatLivret = LstEtatLivret1[2];
            oLivVM.DateDemande = oCandVM.DateCreation;
            oLivVM.DateEnvoiEHESP = oCandVM.DateCreation;
            oLivVM.DateValidite = oLivVM.DateDemande.Value.AddYears(Properties.Settings.Default.DelaiValidite);
            oLivVM.TypeDemande = CurrentCandidat.TypeDemande;
            CurrentCandidat.CurrentLivret = oLivVM;
            if (!IsInTest)
            {
                frmLivret1 odlg = new frmLivret1();
                odlg.setContexte(this);
                odlg.ShowDialog();
            }
        }//AjouteL1
         /// <summary>
         /// Ajout d'un Livret2
         /// </summary>
        public void AjouteL2()
        {
            Livret2VM oL2VM = null;
            try
            {

                CandidatVM oCandVM = CurrentCandidat;
                oL2VM = new Livret2VM(CurrentCandidat.IsLocked);
                oL2VM.LstEtatLivret = LstEtatLivret2;

                oL2VM.EtatLivret = LstEtatLivret2[2];
                oL2VM.DateDemande = DateTime.Now;
                oL2VM.NumPassage = 1;
                if (CurrentCandidat.lstLivrets.Where(l => l.Typestr == Livret2.TYPELIVRET).Count() > 0)
                {
                    int nbL2 = CurrentCandidat.lstLivrets.Where(l => l.Typestr == Livret2.TYPELIVRET).Select(l => ((Livret2VM)l).NumPassage).Max();
                    oL2VM.NumPassage = nbL2 + 1;
                }
                Livret1VM oL1 = CurrentCandidat.getL1Valide();
                if (oL1 != null)
                {
                    oL2VM.Numero = oL1.Numero;
                    oL2VM.DateValidite = oL1.DateValidite;
                    oL2VM.DateLimiteReceptEHESP = oL1.DateValidite;
                    if (oL1.IsRecoursDemande)
                    {
                        oL2VM.IsOuvertureApresRecours = true;
                    }
                    if (oL1.DateEnvoiL2.HasValue)
                    {
                        oL2VM.DateEnvoiEHESP = oL1.DateEnvoiL2;
                    }
                    else
                    {
                        oL1.DateEnvoiL2 = DateTime.Today;
                        oL2VM.DateEnvoiEHESP = DateTime.Today;
                    }
                    oL2VM.IsContrat = oL1.IsContrat;
                    oL2VM.IsConvention = oL1.IsConvention;
                    oL2VM.IsNonRecu = oL1.IsNonRecu;
                    oL2VM.IsCNIOK = oL1.IsCNIOK;
                    oL2VM.DateValiditeCNI = oL1.DateValiditeCNI;
                    oL2VM.IsEnregistre = false;
                    oL2VM.IsPaye = false;
                }


                // Récupération de la date d'envoi du L2 premier passage s'il s'agit un second passage
                if (oL2VM.NumPassage>1)
                {
                    Livret2VM oL2Prem = (Livret2VM)CurrentCandidat.lstLivrets.Where(l => l.Typestr == Livret2.TYPELIVRET && ((Livret2VM)l).NumPassage == 1).FirstOrDefault();
                    if (oL2Prem != null)
                    {
                        oL2VM.DateEnvoiEHESP = oL2Prem.DateEnvoiEHESP;
                    }
                }

                // Récupération du diplome du candidat (si présent)
                DiplomeCand oDiplomeCandidat = CurrentCandidat.TheCandidat.lstDiplomes.Where(d => d.oDiplome.ID == oL2VM.TheLivret.oDiplome.ID).FirstOrDefault();
                if (oDiplomeCandidat == null)
                {
                    DiplomeCandVM oDipCandVM = CurrentCandidat.AjoutDiplomeCand(oL2VM.TheLivret.oDiplome);
                    oDiplomeCandidat = oDipCandVM.TheDiplomeCand;
                    oDipCandVM.ModeObtention = "VAE";
                    oDipCandVM.StatutDiplome = "En cours";
                    oDipCandVM.StatutDC1 = "";
                    oDipCandVM.StatutDC2 = "";
                    oDipCandVM.StatutDC3 = "";
                    oDipCandVM.StatutDC4 = "";
                }

                ((Livret2)oL2VM.TheLivret).InitDCLivrets(oDiplomeCandidat);
                foreach (DCLivret oDCL in ((Livret2)oL2VM.TheLivret).lstDCLivrets)
                {
                    if (CurrentCandidat.IsCAFERUIS && oDCL.NomDC=="DC4" && oDCL.IsAValider)
                    {
                        oDCL.PropositionDecision = "CAFERUIS";
                    }
                    if (CurrentCandidat.IsDEIS && oDCL.NomDC == "DC1" && oDCL.IsAValider)
                    {
                        oDCL.PropositionDecision = "DEIS";
                    }
                    if (CurrentCandidat.IsDEIS && oDCL.NomDC == "DC4" && oDCL.IsAValider)
                    {
                        oDCL.PropositionDecision = "DEIS";
                    }
                    oL2VM.lstDCLivret.Add(new DCLivretVM(oDCL));
                }

                CurrentCandidat.CurrentLivret = oL2VM;

                if (!IsInTest)
                {
                    frmLivret2 odlg = new frmLivret2();
                    odlg.setContexte(this);
                    odlg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CSDebug.TraceException("MVM.AjouteL2", ex);
                oL2VM = null;
            }

    }
public void AjoutePJL1()
        {
            Livret1VM oLiv = (Livret1VM)CurrentCandidat.CurrentLivret;
            oLiv.AjoutePJ("L1");
            SetModelHasChanges();
        }
        public void AjoutePJL2()
        {
            Livret2VM oLiv = (Livret2VM)CurrentCandidat.CurrentLivret;
            oLiv.AjoutePJ("L2");
            SetModelHasChanges();
        }
        public void DeletePJ()
        {
           
            LivretVMBase oLiv = CurrentCandidat.CurrentLivret;
            oLiv.DeletePJ();
            SetModelHasChanges();
        }

        public void DeleteMembreJury()
        {

            LivretVMBase oLiv = CurrentCandidat.CurrentLivret;
            oLiv.DeleteMembreJury();
            SetModelHasChanges();
        }

        public void AjouterMembreJury()
        {

            LivretVMBase oLiv = CurrentCandidat.CurrentLivret;
            oLiv.AjouterMembreJury();
        }
        /// <summary>
        /// Créer le Livret2 puis Cloturer le Livret1
        /// </summary>
        public void CloturerL1etCreerL2()
        {
            // Validation du Livret1
            Livret1VM oLiv = (Livret1VM)CurrentCandidat.CurrentLivret;
            ValideretQuitterL1();
            if (!IsInTest)
            {
                CloseAction();
            }
            // Création du Livret2 (Recupération du Livret1)
            AjouteL2(); 
            // CloturerLivret1
            oLiv.IsLivretClos = true;
        }

        public void CloturerL2()
        {
            Livret2VM oLiv = (Livret2VM)CurrentCandidat.CurrentLivret;
            oLiv.Cloturer();
            if (!IsInTest)
            {
                CloseAction();
            }
        }

        public void GestionDiplome()
        {
            dlgDiplome odlg = new dlgDiplome();
            DiplomeVM odiplomeVM = new DiplomeVM();
            odlg.setContexte(odiplomeVM);
            odlg.ShowDialog();

        }
        /// <summary>
        ///  Validation de la fenêtre Paramètre
        /// </summary>
        public void ValiderdlgParam(dlgParametre pDlg)
        {
            saveDataParam();
            if (!IsInTest)
            {
                pDlg.Close();
            }
        }
        /// <summary>
        ///  Appel de la fenêtre de gestion des paramètres
        /// </summary>
        public void CalldlgParam()
        {
            dlgParametre oDlg = new dlgParametre();
//            _ctxParam = new ContextParam();
            oDlg.setContexte(this);
            if (!IsInTest)
            {
                oDlg.ShowDialog();
            }
        }
        public void CalldlgAPropos()
        {
            dlgAPropos oDlg = new dlgAPropos();
            oDlg.setContexte(this);
            oDlg.ShowDialog();
        }

        public void ValideretQuitterL1()
        {
            Livret1VM oL1VM = (Livret1VM)CurrentCandidat.CurrentLivret;
            // Si le livret est Nouveau => Ajout dans la Collection des Livrets
            if (oL1VM.IsNew)
            {
                CurrentCandidat.lstLivrets.Add(oL1VM);
                SetModelHasChanges();
            }
            CurrentCandidat.refreshlstLivrets();
            if (!IsInTest)
            {
                CloseAction();
            }
        }

        public void ValideretQuitterL2()
        {
            Livret2VM oL2VM = (Livret2VM)CurrentCandidat.CurrentLivret;

            // Validation du contenu du Livret
            //oL2VM.Commit();
            // Mise à jour du diplome du candidat
            //if (oL2VM.IsEtatAccepte)
            {
                UpdateDiplomeCand(oL2VM);
            }
            // Si le livret est Nouveau => Ajout dans la Collection des Livrets
            if (oL2VM.IsNew)
            {
                CurrentCandidat.lstLivrets.Add(oL2VM);
                SetModelHasChanges();
            }
            if (!IsInTest)
            {
                CloseAction();
            }
        }
        /// <summary>
        ///  Mise à jour du diplome du candidat
        /// </summary>
        /// <param name="pLivret"></param>
        private void UpdateDiplomeCand(Livret2VM pLivret)
        {

            DiplomeCandVM oDip = CurrentCandidat.getDiplomeCand(pLivret);
            if (oDip != null)

            {
                if (pLivret.IsEtatEnCours)
                {
                    foreach (DCLivretVM item in pLivret.lstDCLivretAValider)
                    {
                        DomaineCompetenceCand oDCCand = oDip.lstDCCands.Where(d => d.NomDomaineCompetence == item.NomDC).FirstOrDefault();
                        if (oDCCand != null)
                        {
                            oDCCand.Statut = "En cours";
                        }
                        item.Statut = "En cours";
                    }
                }
                else
                {
                    if (pLivret.IsDecisionJuryPartielle)
                    {
                        foreach (DCLivretVM item in pLivret.lstDCLivretAValider)
                        {
                            DomaineCompetenceCand oDCCand = oDip.lstDCCands.Where(d => d.NomDomaineCompetence == item.NomDC).FirstOrDefault();
                            if (oDCCand != null)
                            {
                                if (item.IsDecisionFavorable)
                                {
                                    oDCCand.Statut = "Validé";
                                    oDCCand.DateObtention = pLivret.DateJury;
                                    oDCCand.ModeObtention = "VAE";
                                }
                                else
                                {
                                    oDCCand.Statut = "Refusé";
                                    oDCCand.DateObtention = pLivret.DateJury;
                                }
                            }
                        }

                    }
                    else
                    {
                        if (pLivret.IsDecisionJuryFavorable)
                        {
                            // Validation des DC àValider
                            foreach (DCLivretVM item in pLivret.lstDCLivretAValider)
                            {
                                item.Statut = oDip.LstStatutModule[0];
                                item.Decision = pLivret.DecisionL2ModuleFavorable;
                                DomaineCompetenceCand oDCCand = oDip.lstDCCands.Where(d => d.NomDomaineCompetence == item.NomDC).FirstOrDefault();
                                oDCCand.Statut = oDip.LstStatutModule[0];
                                oDCCand.DateObtention = pLivret.DateJury;
                                oDCCand.ModeObtention = "VAE";
                            }
                            oDip.DateObtentionDiplome = pLivret.DateJury;
                            oDip.StatutDiplome = "Validé";
                        }
                        if (pLivret.IsDecisionJuryDefavorable)
                        {
                            // Validation des DC àValider
                            foreach (DCLivretVM item in pLivret.lstDCLivretAValider)
                            {
                                item.Statut = oDip.LstStatutModule[1];
                                DomaineCompetenceCand oDCCand = oDip.lstDCCands.Where(d => d.NomDomaineCompetence == item.NomDC).FirstOrDefault();
                                oDCCand.Statut = oDip.LstStatutModule[1];
                                oDCCand.DateObtention = pLivret.DateJury;
                                oDCCand.ModeObtention = "VAE";
                            }
                        }
                    }
                }
                oDip.CalcStatutDiplome();

            }

        }

        public void QuitterLivret()
        {
            LivretVMBase oLiv = CurrentCandidat.CurrentLivret;
            if (oLiv.HasChanges())
            {
                if (MessageBoxShow("Attention, certaines modifications seront perdues, voulez-vous continuer?", "ATTENTION", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.Yes)
                {
                    DbEntityEntry oEntity = oLiv.getEntity();
                    if (oEntity.State != EntityState.Detached)
                    { 
#if _DEBUG_
                    DbPropertyValues oValues = oEntity.CurrentValues;
                    foreach (String name in oValues.PropertyNames)
                    {
                            Console.WriteLine(String.Format("{0} = Original = {1}, current = {2}", name, oEntity.Property(name).OriginalValue, oEntity.Property(name).CurrentValue));
                    }
#endif
                    ResetCurrentLivret();
                }
                    CloseAction();
                }
            }
            else
            {
                CloseAction();
            }
        }

        /// <summary>
        /// Réinitialise le Livret courant à partir des données Originelles
        /// </summary>
        public void ResetCurrentLivret()
    {
        if (CurrentCandidat.CurrentLivret != null)
        {
            CurrentCandidat.CurrentLivret.Reset();
                CurrentCandidat.refreshlstLivrets();
        }
    }
    public bool HasChanges()
        {
            Boolean bReturn = false;
            bReturn = (_ctx.ChangeTracker.HasChanges() || _modelhasChanges);
            if (CurrentCandidat != null)
            {
                bReturn = bReturn || CurrentCandidat.HasChanges();
            }
            return bReturn;
        }
        public void SetModelHasChanges()
        {
            _modelhasChanges = true;
        }

        public void DeleteCurrentCandidat()
        {
            if (CurrentCandidat != null)
            {
                if (CurrentCandidat.IsLocked)
                {

                    if (MessageBoxShow("Etes-vous sur de souloir supprimer le candidat", "Suppression d'un candidat", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        CurrentCandidat.IsDeleted = true;
                        SetModelHasChanges();
                        //CurrentCandidat.UnLock(_ContextID);
                        //_ctx.Candidats.Remove(CurrentCandidat.TheCandidat);
                        //lstCandidatVM.Remove(CurrentCandidat);
                        CurrentCandidat = null;
                    }
                }
            }
   
        }
        public void DeleteDiplomeCand()
        {
            if (CurrentCandidat != null)
            {
                if (CurrentCandidat.CurrentDiplomeCand != null)
                {
                    CurrentCandidat.DeleteCurrentDiplome();
                }
            }

        }

        public Boolean SetCurrentCandidat(String pNom)
        {
            Boolean bReturn = false;

            try
            {
                CandidatVM oCand = lstCandidatVM.Where(c => c.Nom == pNom).LastOrDefault();
                CurrentCandidat = oCand;
                
                bReturn = (oCand != null);
            }
            catch (Exception)
            {

                bReturn = false;
            }
            return bReturn;


        }

        public Boolean CleanAllLocks()
        {
            ContextLock ctxLock = new ContextLock();
            ctxLock.Locks.RemoveRange(ctxLock.Locks.ToList());
            return true;
        }


        public Boolean LockCurrentCandidat()
        {
            Context ctxLock = new Context();
            if (CurrentCandidat != null)
            {
                if (!CurrentCandidat.IsLocked)
                {
                    CurrentCandidat.Lock(_ContextID);
                    RaisePropertyChanged("IsCurrentCandidatLocked");
                }
            }
            return true;
        }
        public Boolean UnLockCurrentCandidat()
        {
            Context ctxLock = new Context();
            if (CurrentCandidat != null)
            {
                if (IsCurrentCandidatLockedByMe)
                { 
                    CurrentCandidat.UnLock(_ContextID);
                }
            }
            return true;
        }
        public Boolean IsCurrentCandidatLockable()
        {
            
            Boolean bReturn = true;
            if (CurrentCandidat == null)
            {
                bReturn = false;
            }
            else
            {
                bReturn = ! IsCurrentCandidatLocked ;
            }
            return bReturn;
        }
        public Boolean IsCurrentCandidatLocked
        {
            get
            {
                Boolean bReturn = false;
                if (CurrentCandidat != null)
                {
                    if (CurrentCandidat.IsLocked)
                    {
                        bReturn = true;
                    }
                }
                return bReturn;
            }
        }
        /// <summary>
        /// Le Candidat courant est-il locké par moi
        /// </summary>
        public Boolean IsCurrentCandidatLockedByMe
        {
            get
            {
                Boolean bReturn = false;
                if (CurrentCandidat != null)
                {
                    ContextLock ctxLock = new ContextLock();
                    int nLock = ctxLock.Locks.Where(L => L.IDCandidat == CurrentCandidat.ID && L.IDUser == _ContextID).Count();
                    bReturn = (nLock > 0);
                }
                return bReturn;
            }
        }
        public Boolean IsValiderEtQuitterAvailable
        {
            get
            {
                Boolean bReturn = false;
                if (CurrentCandidat != null)
                {
                    LivretVMBase oLiv = CurrentCandidat.CurrentLivret;
                    if (oLiv != null)
                    {
                        bReturn = oLiv.IsValiderOK();
                    }
                }
                return bReturn;
            }
        }
        /// <summary>
        /// L'ajout du Livret1 est-il Autorisé sur le candidat Courant ?
        /// </summary>
        public Boolean IsCurrentCandidatAddL1Available
        {
            get
            {
                Boolean bReturn = false;
                if (CurrentCandidat == null)
                {
                    bReturn=  false;
                }
                if (IsCurrentCandidatLocked)
                {
                    // L'ajout d'un L1 n'est pas possible s'il y a un L1 de valide
                    bReturn = !CurrentCandidat.IsL1Valide;
                    if (bReturn)
                    {
                        // OU S'il y a un L1 en cours
                        bReturn = !CurrentCandidat.IsL1Encours;
                    }
                }
                return bReturn;
            }
        }

        /// <summary>
        /// A-t-on le droit d'ajouter un L2 ?
        /// Candidat Locké + Ajout de L2 possible 
        /// </summary>
        public Boolean IsCurrentCandidatAddL2Available
        {
            get
            {
                Boolean bReturn = false;
                if (CurrentCandidat != null)
                {
                    if (CurrentCandidat.IsLocked)
                    {
                        bReturn = CurrentCandidat.IsAddL2Available;


                    }
                }
                return bReturn;
            }
        }

        public void UnlockCandidats()
        {
            ContextLock ctxLock = new ContextLock();
            ctxLock.Locks.RemoveRange(ctxLock.Locks.Where(L => L.IDUser == _ContextID));
            ctxLock.SaveChanges();
            RaisePropertyChanged("IsCurrentCandidatLocked");
            RaisePropertyChanged("IsCurrentCandidatLockedByMe");
            foreach (CandidatVM oCand in lstCandidatVM)
            {
                oCand.RaisePropertyChanged("IsLocked");
            };


        }
        public void UnlockAll()
        {
            if (MessageBoxShow("Etes-vous sur de vouloir déverrouiller TOUS les candidats ?", "Déverrouiller tous les candidats", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ContextLock ctxLock = new ContextLock();
                ctxLock.Locks.RemoveRange(ctxLock.Locks.ToList());
                ctxLock.SaveChanges();
            }
        }
        public Boolean IsAnyLock()
        {
            ContextLock ctxLock = new ContextLock();
            int nCount = ctxLock.Locks.ToList().Count();
            return (nCount > 0);
        }

        public void ExecSQL()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selectionner le fichier à exécuter";
            String strFilename;
            String Script;
            if (ofd.ShowDialog()== true)
            {
                strFilename = ofd.FileName;
                Script = File.ReadAllText(strFilename);
                IEnumerable<string> commandStrings = Regex.Split(Script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                System.Data.SqlClient.SqlConnection cnx = (SqlConnection)_ctx.Database.Connection;
                cnx.Open();
                SqlCommand command = new SqlCommand();

                try
                {
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (command = new SqlCommand(commandString, cnx))
                            {
                                CSDebug.TraceINFO(commandString);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    CSDebug.TraceException("ExecSQL", ex);
                    CSDebug.TraceINFO("command.text  = ["+  command.CommandText + "]");
                }
                cnx.Close();
                MessageBoxShow("Exécution terminée");
            }


        }
        public void DecloturerLivret()
        {
            if (CurrentCandidat != null)
            {
                if (CurrentCandidat.CurrentLivret != null)
                {
                    CurrentCandidat.CurrentLivret.IsLivretClos = false;
                }
            }
        }
        public void DoubleClickSurCandidat()
        {
            if (CurrentCandidat != null)
            {
                LockCurrentCandidat();
            }
        }

        public MessageBoxResult MessageBoxShow(String pMessage,String pCaption = "Gest VAE", MessageBoxButton pButton=MessageBoxButton.OK,MessageBoxImage pIcon = MessageBoxImage.None )
        {
            MessageBoxResult oResult = MessageBoxResult.Yes;
            if (!IsInTest)
            {
                oResult = MessageBox.Show(pMessage, pCaption, pButton, pIcon);
            }
            return oResult;
        }

        public Boolean IsCurrentCandidatSelected {
            get
            {
                return CurrentCandidat != null;
            }
        }
        /// <summary>
        /// Prochain Numero de candidat
        /// </summary>
        public Int32 ParamNumCandidat {
            get
            {
                Int32 nReturn = 0;
                Param objParam = _ctxParam.dbParam.FirstOrDefault();
                if (objParam != null)
                {
                    _ctxParam.Entry(objParam).Reload();
                    nReturn = objParam.NumCandidat;
                }
                return nReturn;
            }
            set
            {
                if (value != ParamNumCandidat)
                {
                    Param objParam = _ctxParam.dbParam.FirstOrDefault();
                    if (objParam != null)
                    {
                        objParam.NumCandidat = value;
                        _ctxParam.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// Prochain Numero de Livret
        /// </summary>
        public Int32 ParamNumLivret
        {
            get
            {
                Int32 nReturn = 0;
                using (ContextParam ctx = new ContextParam())
                {
                    Param objParam = _ctxParam.dbParam.FirstOrDefault();
                    if (objParam != null)
                    {
                        _ctxParam.Entry(objParam).Reload();
                        nReturn = objParam.NumLivret;
                    }
                }
                return nReturn;
            }
            set
            {
                if (value != ParamNumLivret)
                {
                    using (ContextParam ctx = new ContextParam())
                    {
                        Param objParam = _ctxParam.dbParam.FirstOrDefault();
                        if (objParam != null)
                        {
                            objParam.NumLivret = value;
                            _ctxParam.SaveChanges();
                        }
                    }

                }
            }
        }//ParamNumLivret
         /// <summary>
         /// Delai de validité du L1 après expiration
         /// </summary>
        public Int32 ParamDelaiValiditeL1
        {
            get
            {
                Int32 nReturn = 0;
                Param objParam = _ctxParam.dbParam.FirstOrDefault();
                if (objParam != null)
                {
                    _ctxParam.Entry(objParam).Reload();
                    nReturn = objParam.DelaiValiditeL1;
                }
                return nReturn;
            }
            set
            {
                if (value != ParamDelaiValiditeL1)
                {
                    Param objParam = _ctxParam.dbParam.FirstOrDefault();
                    if (objParam != null)
                    {
                        objParam.DelaiValiditeL1 = value;
                        _ctxParam.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// Couleur de fond des Livret en tolérance
        /// </summary>
        public String ParamCouleurTolerance
        {
            get
            {
                String nReturn = "";
                Param objParam = _ctxParam.dbParam.FirstOrDefault();
                if (objParam != null)
                {
                    _ctxParam.Entry(objParam).Reload();
                    nReturn = objParam.CouleurTolerance;
                }
                return nReturn;
            }
            set
            {
                if (value != ParamCouleurTolerance)
                {
                    Param objParam = _ctxParam.dbParam.FirstOrDefault();
                    if (objParam != null)
                    {
                        objParam.CouleurTolerance = value;
                        _ctxParam.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// Chemoin d'accès au fichier des membres du jury
        /// </summary>
        public String ParamPathToBaseJury
        {
            get
            {
                String nReturn = "";
                Param objParam = _ctxParam.dbParam.FirstOrDefault();
                if (objParam != null)
                {
                    _ctxParam.Entry(objParam).Reload();
                    nReturn = objParam.PathToBaseJury;
                }
                return nReturn;
            }
            set
            {
                if (value != ParamPathToBaseJury)
                {
                    Param objParam = _ctxParam.dbParam.FirstOrDefault();
                    if (objParam != null)
                    {
                        objParam.PathToBaseJury = value;
                        _ctxParam.SaveChanges();
                    }
                }
            }
        }

        private Boolean IsAjoutPJPossible()
        {
            Boolean bReturn = false;
            if (CurrentCandidat != null)
            {
                if (CurrentCandidat.CurrentLivret != null)
                {
                    bReturn = (CurrentCandidat.CurrentLivret.CategoriePJ != null && CurrentCandidat.CurrentLivret.LibellePJ != null);
                }
            }
            return bReturn;
        }
        private Boolean IsDeletePJPossible()
        {
            Boolean bReturn = false;
            if (CurrentCandidat != null)
            {
                if (CurrentCandidat.CurrentLivret != null)
                {
                    bReturn = (CurrentCandidat.CurrentLivret.selectedPJ != null );
                }
            }
            return bReturn;
        }


        /*
                        <ComboBoxItem Content="Régions"/>
                <ComboBoxItem Content="Départements"/>
                <ComboBoxItem Content="Diplômes"/>
                <ComboBoxItem Content="Pièces jointes"/>
                <ComboBoxItem Content="Motif refus L1"/>
                <ComboBoxItem Content="Motif refus L2"/>
                <ComboBoxItem Content="Collèges jury"/>
                <ComboBoxItem Content="Type de la demande"/>
                <ComboBoxItem Content="Vecteur d'information"/>
                <ComboBoxItem Content="Numérotation"/>
*/

        private String _NomParametre = "Régions";

        public String NomParametre
        {
            get { return _NomParametre; }
            set {
                _NomParametre = value;
                RaisePropertyChanged("IsParamRegion");
                RaisePropertyChanged("IsParamDepartement");
                RaisePropertyChanged("IsParamDiplome");
                RaisePropertyChanged("IsParamPJ");
                RaisePropertyChanged("IsParamMotifRefusL1");
                RaisePropertyChanged("IsParamMotifRefusL2");
                RaisePropertyChanged("IsParamColleges");
                RaisePropertyChanged("IsParamTypeDemande");
                RaisePropertyChanged("IsParamVecteur");
                RaisePropertyChanged("IsParamNumerotation");
                RaisePropertyChanged("IsParamDelaiValiditeL1");
                RaisePropertyChanged("IsParamPathToBDMembreJury");
            }
        }

        private Boolean NomParametreEquals(String pNom)
        {
            Boolean bReturn = false;
            if (NomParametre != null)
            {
                bReturn = NomParametre.Equals(pNom);
            }
            return bReturn;
        }
        public Boolean IsParamRegion { get { return NomParametreEquals("Régions"); } }
        public Boolean IsParamDepartement { get { return NomParametreEquals("Départements"); } }
        public Boolean IsParamDiplome { get { return NomParametreEquals("Diplômes"); } }
        public Boolean IsParamPJ { get { return NomParametreEquals("Pièces jointes"); } }
        public Boolean IsParamMotifRefusL1 { get { return NomParametreEquals("Motif refus L1"); } }
        public Boolean IsParamMotifRefusL2 { get { return NomParametreEquals("Motif refus L2"); } }
        public Boolean IsParamColleges { get { return NomParametreEquals("Collèges jury"); } }
        public Boolean IsParamTypeDemande { get { return NomParametreEquals("Type de la demande"); } }
        public Boolean IsParamVecteur { get { return NomParametreEquals("Vecteur d'information"); } }
        public Boolean IsParamNumerotation { get { return NomParametreEquals("Numérotation"); } }
        public Boolean IsParamDelaiValiditeL1 { get { return NomParametreEquals("Délai Validité du L1"); } }
        public Boolean IsParamPathToBDMembreJury { get { return NomParametreEquals("Base des membres du jury"); } }

        public Boolean saveDataParam()
        {
            Boolean bReturn = true;
            try
            {

                foreach (PieceJointeCategorie item in lstPieceJointeCategorie)
                {
                    if (_ctxParam.Entry<PieceJointeCategorie>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctxParam.pieceJointeCategories.Add(item);
                    }
                    if (_ctxParam.Entry<PieceJointeCategorie>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctxParam.pieceJointeCategories.Remove(item);
                    }
                }
                foreach (MotifGeneralL1 item in lstMotifGL1)
                {
                    if (_ctxParam.Entry<MotifGeneralL1>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctxParam.dbMotifGeneralL1.Add(item);
                    }
                    if (_ctx.Entry<MotifGeneralL1>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctxParam.dbMotifGeneralL1.Remove(item);
                    }
                }

                foreach (MotifGeneralL2 item in lstMotifGL2)
                {
                    if (_ctxParam.Entry<MotifGeneralL2>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctxParam.dbMotifGeneralL2.Add(item);
                    }
                    if (_ctx.Entry<MotifGeneralL2>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctxParam.dbMotifGeneralL2.Remove(item);
                    }
                }

                foreach (RegionVM item in lstRegionVM)
                {
                    if (item.IsNew)
                    {
                        _ctxParam.Regions.Add(item.RegionItem);
                    }
                }

                foreach (ParamDepartement item in lstParamDepartement)
                {
                    if (_ctxParam.Entry<ParamDepartement>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctxParam.dbParamDepartement.Add(item);
                    }
                    if (_ctxParam.Entry<ParamDepartement>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctxParam.dbParamDepartement.Remove(item);
                    }
                }
                foreach (ParamCollege item in lstParamCollege)
                {
                    if (_ctxParam.Entry<ParamCollege>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctxParam.dbParamCollege.Add(item);
                    }
                    if (_ctxParam.Entry<ParamCollege>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctxParam.dbParamCollege.Remove(item);
                    }
                }
                foreach (ParamTypeDemande item in lstParamTypeDemande)
                {
                    if (_ctxParam.Entry<ParamTypeDemande>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctxParam.dbParamTypeDemande.Add(item);
                    }
                    if (_ctxParam.Entry<ParamTypeDemande>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctxParam.dbParamTypeDemande.Remove(item);
                    }
                }
                foreach (ParamVecteurInformation item in lstParamVecteurInformation)
                {
                    if (_ctxParam.Entry<ParamVecteurInformation>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctxParam.dbParamVecteurInformation.Add(item);
                    }
                    if (_ctxParam.Entry<ParamVecteurInformation>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctxParam.dbParamVecteurInformation.Remove(item);
                    }
                }
                _ctxParam.SaveChanges();
                _modelhasChanges = false;
                bReturn = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                bReturn = false;
            }

            return bReturn;
        }//SaveData

        public String DatabaseName
        {
            get
            {
                return _ctx.Database.Connection.Database;
            }
        }
        public void exporterData()
        {
            IsBusy = true;
            DbConnection ocon = _ctx.Database.Connection;
            if (ocon.State == System.Data.ConnectionState.Closed)
            {
                ocon.Open();
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter= "Backup BDD(*.bak)|*.bak";
            sfd.FileName = DateTime.Now.ToString(ocon.Database + "_yyMMddHHmm") + ".bak";
            sfd.Title = "Exporter la base de données";
            if (sfd.ShowDialog() == true)
            {
                DbCommand oCmd = ocon.CreateCommand();
                String fileName = sfd.FileName;
                oCmd.CommandText = "BACKUP DATABASE " + ocon.Database + " TO DISK = '" + fileName + "'";
                oCmd.ExecuteNonQuery();
                MessageBoxShow("Export terminé");
            }
            ocon.Close();

            IsBusy = false;
        }

        public void RechercherBaseMembreJury()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "fichier CSV (*.csv)|*.csv";
            openFileDialog.CheckFileExists = true;

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    ParamPathToBaseJury = openFileDialog.FileName;
                        BDMembreJury.loadFrom(ParamPathToBaseJury);
                }
                catch (Exception ex)
                {


                    MessageBoxShow("erreur en lecture du fichier " + ex.Message);
                    ParamPathToBaseJury = "";

                }
            }

        }
        private BDMembreJury _DBMembreJurySelected;

        public BDMembreJury DBMembreJurySelected
        {
            get { return _DBMembreJurySelected; }
            set { _DBMembreJurySelected = value; }
        }

        public void Commentaire()
        {
            frmCommentaire ofrm = new frmCommentaire();
            ofrm.SetconTexte(this);
            ofrm.ShowDialog();
        }

    }
}
