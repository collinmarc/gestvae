
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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestVAE.VM
{
    //public enum Statuts { ACCEPTE, REFUSE};
    public class MyViewModel : NotifyUIBase
    {
        private Context _ctx;
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
        public ObservableCollection<ParamCollege> lstParamCollege { get; set; }
        public ObservableCollection<ParamOrigine> lstParamOrigine { get; set; }
        public ObservableCollection<ParamTypeDemande> lstParamTypeDemande { get; set; }
        public ObservableCollection<ParamVecteurInformation> lstParamVecteurInformation { get; set; }
        private Boolean bCandidatAjoute = false;
        private Int32 _ContextID=0;
        public CandidatVM CurrentCandidat
        {
            get { return _candidatVM; }
            set {
               
                _candidatVM = value;
                RaisePropertyChanged("IsCurrentCandidatLockable");
                RaisePropertyChanged("IsCurrentCandidatSelected");
                RaisePropertyChanged(); }
        }
        public DiplomeCandVM CurrentDiplomeCand{get;set;}
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
            Context.Reset();
            IsInTest = false;
            _ctx = Context.instance;
            _lstCandidatVM = new ObservableCollection<CandidatVM>();
            _lstRegionVM = new ObservableCollection<RegionVM>();
            _lstDiplomeVM = new ObservableCollection<DiplomeVM>();
            _lstPieceJointeCategorie = new ObservableCollection<PieceJointeCategorie>();
            _lstMotifGL1 = new ObservableCollection<MotifGeneralL1>();
            _lstMotifGL2 = new ObservableCollection<MotifGeneralL2>();
            lstParamCollege = new ObservableCollection<ParamCollege>();
            lstParamOrigine = new ObservableCollection<ParamOrigine>();
            lstParamTypeDemande = new ObservableCollection<ParamTypeDemande>();
            lstParamVecteurInformation = new ObservableCollection<ParamVecteurInformation>();
            _ContextID = new Random().Next(); // ID de l'application

            CreateCommands();
            //getData();
        }
        public MyViewModel(Boolean pIsInTest) :this()
        {
            IsInTest = pIsInTest;
        }

        private void CreateCommands()
        {
            _SaveCommand = new SaveCommand(o => { saveData(); },
                                           o => { return HasChanges(); }
                                          );
            UnLockAllCommand = new RelayCommand<MyViewModel>(o => { UnlockAll(); },
                                                            o => { return IsAnyLock(); }
                                          );
            _AddCandidatCommand = new RelayCommand<CandidatVM>(o => { AjouterCandidat(); }
                                           );
            _dlgParamCommand = new RelayCommand<MyViewModel>(o => { CalldlgParam(); }
                                           );
            dlgAProposCommand = new RelayCommand<MyViewModel>(o => { CalldlgAPropos(); }
                                           );
            _RechercherCommand = new RelayCommand<MyViewModel>(o => { Recherche(); }
                                           );
            AjouteDiplomeCandCommand = new RelayCommand<MyViewModel>(o => { AjouteDiplomeCand(); }
                                           );
            AjouteL1Command = new RelayCommand<MyViewModel>(o => { AjouteL1(); },
                                                            o=> { return IsCurrentCandidatAddL1Available; }
                                           );
            AjoutePJL1Command = new RelayCommand<MyViewModel>(o => { AjoutePJL1(); }
                                           );
            AjoutePJL2Command = new RelayCommand<MyViewModel>(o => { AjoutePJL2(); }
                                           );
            DeletePJCommand = new RelayCommand<MyViewModel>(o => { DeletePJ(); }
                                           );
            AjouteL2Command = new RelayCommand<MyViewModel>(o => { AjouteL2(); },
                                                            o => { return IsCurrentCandidatAddL2Available; }
                                            );
            dlgDiplomeCommand = new RelayCommand<MyViewModel>(o => { GestionDiplome(); }
                                           );
            ValideretQuitterL1Command = new RelayCommand<MyViewModel>(o => { ValideretQuitterL1(); }
                                           );
            ValideretQuitterL2Command = new RelayCommand<MyViewModel>(o => { ValideretQuitterL2(); }
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
            DecloturerLivretCommand= new RelayCommand<MyViewModel>(o => { DecloturerLivret(); }
                                                        );
        }

        public ObservableCollection<CandidatVM> lstCandidatVM
        {
            get => _lstCandidatVM;
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
            get => _lstRegionVM;
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
            get => _lstDiplomeVM;

        }
        public ObservableCollection<PieceJointeCategorie> lstPieceJointeCategorie
        {
            get => _lstPieceJointeCategorie;

        }
        public ObservableCollection<MotifGeneralL1> lstMotifGL1
        {
            get => _lstMotifGL1;

        }
        public ObservableCollection<MotifGeneralL2> lstMotifGL2
        {
            get => _lstMotifGL2;
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
                oReturn.Add(String.Format("{0:D}-Refusé", MyEnums.EtatL1.ETAT_L1_REFUSE));
                oReturn.Add(String.Format("{0:D}-Accepté", MyEnums.EtatL1.ETAT_L1_ACCEPTE));
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
                oReturn.Add(String.Format("{0:D}-Refusé", MyEnums.EtatL1.ETAT_L1_REFUSE));
                //                oReturn.Add(String.Format("{0:D}-Recours", MyEnums.EtatL1.ETAT_L1_RECOURS));
                oReturn.Add(String.Format("{0:D}-Accepté", MyEnums.EtatL1.ETAT_L1_ACCEPTE));
                return oReturn;
            }
            set { }
        }

        public Boolean saveData()
        {
            Boolean bReturn = true;
            try
            {
                foreach (CandidatVM item in lstCandidatVM)
                {
                    item.Commit();
                }
                foreach (PieceJointeCategorie item in lstPieceJointeCategorie)
                {
                    if (_ctx.Entry<PieceJointeCategorie>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctx.pieceJointeCategories.Add(item);
                    }
                    if (_ctx.Entry<PieceJointeCategorie>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctx.pieceJointeCategories.Remove(item);
                    }
                }
                foreach (MotifGeneralL1 item in lstMotifGL1)
                {
                    if (_ctx.Entry<MotifGeneralL1>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctx.dbMotifGeneralL1.Add(item);
                    }
                    if (_ctx.Entry<MotifGeneralL1>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctx.dbMotifGeneralL1.Remove(item);
                    }
                }

                foreach (MotifGeneralL2 item in lstMotifGL2)
                {
                    if (_ctx.Entry<MotifGeneralL2>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctx.dbMotifGeneralL2.Add(item);
                    }
                    if (_ctx.Entry<MotifGeneralL2>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctx.dbMotifGeneralL2.Remove(item);
                    }
                }

                foreach (RegionVM item in lstRegionVM)
                {
                    if (item.IsNew)
                    {
                        _ctx.Regions.Add(item.RegionItem);
                    }
                }
                foreach (DiplomeVM item in lstDiplomeVM)
                {
                    item.Commit();
                }

                foreach (CandidatVM item in lstCandidatVM)
                {
                    item.Commit();
                }
                foreach (ParamOrigine item in lstParamOrigine)
                {
                    if (_ctx.Entry<ParamOrigine>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctx.dbParamOrigine.Add(item);
                    }
                    if (_ctx.Entry<ParamOrigine>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctx.dbParamOrigine.Remove(item);
                    }
                }
                foreach (ParamCollege item in lstParamCollege)
                {
                    if (_ctx.Entry<ParamCollege>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctx.dbParamCollege.Add(item);
                    }
                    if (_ctx.Entry<ParamCollege>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctx.dbParamCollege.Remove(item);
                    }
                }
                foreach (ParamTypeDemande item in lstParamTypeDemande)
                {
                    if (_ctx.Entry<ParamTypeDemande>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctx.dbParamTypeDemande.Add(item);
                    }
                    if (_ctx.Entry<ParamTypeDemande>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctx.dbParamTypeDemande.Remove(item);
                    }
                }
                foreach (ParamVecteurInformation item in lstParamVecteurInformation)
                {
                    if (_ctx.Entry<ParamVecteurInformation>(item).State == System.Data.Entity.EntityState.Detached)
                    {
                        _ctx.dbParamVecteurInformation.Add(item);
                    }
                    if (_ctx.Entry<ParamVecteurInformation>(item).State == System.Data.Entity.EntityState.Deleted)
                    {
                        _ctx.dbParamVecteurInformation.Remove(item);
                    }
                }
                _ctx.DeleteOnCascade();
                _ctx.SaveChanges();
                UnlockCandidats();
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


        public void getData()
        {
            CSDebug.TraceINFO("MyViwModel.getData : START");
            try
            {

                getParams();

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
                foreach (Region item in _ctx.Regions)
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
                foreach (PieceJointeCategorie item in _ctx.pieceJointeCategories)
                {
                    //DiplomeVM oItVM = new DiplomeVM(item);
                    _lstPieceJointeCategorie.Add(item);
                }
                RaisePropertyChanged("lstPieceJointeCategorie");

                _lstMotifGL1.Clear();
                foreach (MotifGeneralL1 item in _ctx.dbMotifGeneralL1)
                {
                    _lstMotifGL1.Add(item);
                }
                RaisePropertyChanged("lstMotifGL1");

                _lstMotifGL2.Clear();
                foreach (MotifGeneralL2 item in _ctx.dbMotifGeneralL2)
                {
                    _lstMotifGL2.Add(item);
                }
                RaisePropertyChanged("lstMotifGL2");

                lstParamCollege.Clear();
                foreach (ParamCollege item in _ctx.dbParamCollege)
                {
                    lstParamCollege.Add(item);
                }
                lstParamOrigine.Clear();
                foreach (ParamOrigine item in _ctx.dbParamOrigine)
                {
                    lstParamOrigine.Add(item);
                }
                lstParamTypeDemande.Clear();
                foreach (ParamTypeDemande item in _ctx.dbParamTypeDemande)
                {
                    lstParamTypeDemande.Add(item);
                }
                lstParamVecteurInformation.Clear();
                foreach (ParamVecteurInformation item in _ctx.dbParamVecteurInformation)
                {
                    lstParamVecteurInformation.Add(item);
                }




                IsBusy = false;
            }
            catch (Exception ex)
            {

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
        public void AjouterCandidat()
        {
            Candidat oCand = new Candidat("[Nouveau candidat]");
            _ctx.Candidats.Add(oCand);
            CandidatVM oCandVM = new CandidatVM(oCand);
            oCandVM.Nationnalite = "Française";
            oCandVM.NationnaliteNaissance = "Française";
            if (String.IsNullOrEmpty(oCandVM.IdVAE))
            {
                oCandVM.IdVAE = "3" + DateTime.Now.ToString("yy") + ParamVM.incrementCandidat().ToString("00000");
            }
            lstCandidatVM.Add(oCandVM);
            CurrentCandidat = oCandVM;
            RaisePropertyChanged("lstCandidatVM");
            bCandidatAjoute = true;
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
        public ICommand AjouteL2Command { get; set; }
        public ICommand ValideretQuitterL1Command { get; set; }
        public ICommand ValideretQuitterL2Command { get; set; }
        public ICommand CloturerL1etCreerL2Command { get; set; }
        public ICommand CloturerL2Command { get; set; }
        public ICommand DecloturerLivretCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand DeleteCandidatCommand { get; set; }
        public ICommand DeleteDiplomeCandCommand { get; set; }
        public ICommand LockCommand { get; set; }
        public ICommand UnLockCommand { get; set; }
        public ICommand UnLockAllCommand { get; set; }
        public ICommand ExecSQLCommand { get; set; }
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
        public String rechEtatL1 { get; set; }
        public String rechEtatL2 { get; set; }

        public void Recherche()
        {
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
                    rq = rq.Where(c => c.Nom.Contains(rechNom.Replace("%","")));
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
                rq = rq.Where(c => c.lstLivrets1.Where(L1=>L1.EtatLivret==rechEtatL1).Count()>0);

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
            if (rechbHandicap )
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
                CurrentCandidat = _lstCandidatVM[0];
            }
            else
            {
                CurrentCandidat =null;
            }
            RaisePropertyChanged("lstCandidatVM");
            RaisePropertyChanged("CurrentCandidat");
        }
        public void AjouteDiplomeCand()
        {
            CandidatVM oCandVM = CurrentCandidat;
            oCandVM.AjoutDiplomeCand();


        }

        /// <summary>
        /// Ajout d'un livret1 au candidat
        /// </summary>
        public void AjouteL1()
        {

            CandidatVM oCandVM = CurrentCandidat;
            Livret1VM oLivVM = new Livret1VM(CurrentCandidat.IsLocked);
            oLivVM.LstEtatLivret = LstEtatLivret1;
            oLivVM.EtatLivret = LstEtatLivret1[1];
            oLivVM.DateDemande = DateTime.Now;
            oLivVM.DateValidite = DateTime.Now.AddYears(3);
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
            Livret2VM oLivVM = null;
            try
            {

                CandidatVM oCandVM = CurrentCandidat;
                oLivVM = new Livret2VM(CurrentCandidat.IsLocked);
                oLivVM.LstEtatLivret = LstEtatLivret2;

                oLivVM.EtatLivret = LstEtatLivret2[1];
                oLivVM.DateDemande = DateTime.Now;
                oLivVM.DateValidite = DateTime.Now.AddDays(Properties.Settings.Default.DelaiValidite);
                CurrentCandidat.CurrentLivret = oLivVM;
                if (CurrentCandidat.lstLivrets.Where(l => l.Typestr == Livret2.TYPELIVRET).Count() > 0)
                {
                    int nbL2 = CurrentCandidat.lstLivrets.Where(l => l.Typestr == Livret2.TYPELIVRET).Select(l => ((Livret2VM)l).NumPassage).Max();
                    oLivVM.NumPassage = nbL2 + 1;
                }
                // Récupération du diplome du candidat (si présent)
                DiplomeCand oDiplomeCandidat = CurrentCandidat.TheCandidat.lstDiplomes.Where(d => d.oDiplome.ID == oLivVM.TheLivret.oDiplome.ID).FirstOrDefault();
                if (oDiplomeCandidat == null)
                {
                    oDiplomeCandidat = CurrentCandidat.AjoutDiplomeCand().TheDiplomeCand;
                }

                ((Livret2)oLivVM.TheLivret).InitDCLivrets(oDiplomeCandidat);
                foreach (DCLivret oDCL in ((Livret2)oLivVM.TheLivret).lstDCLivrets)
                {
                    oLivVM.lstDCLivret.Add(new DCLivretVM(oDCL));
                }
                // Récupération du L1Valide pour récupérer le numéro
                Livret1VM oL1 = CurrentCandidat.getL1Valide();
                if (oL1 != null)
                { 
                    oLivVM.Numero = oL1.Numero;
                }

                CurrentCandidat.CurrentLivret = oLivVM;

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
                oLivVM = null;
            }

    }
public void AjoutePJL1()
        {
            Livret1VM oLiv = (Livret1VM)CurrentCandidat.CurrentLivret;
            oLiv.AjoutePJ("L1");
        }
        public void AjoutePJL2()
        {
            Livret2VM oLiv = (Livret2VM)CurrentCandidat.CurrentLivret;
            oLiv.AjoutePJ("L2");
        }
        public void DeletePJ()
        {
            LivretVMBase oLiv = CurrentCandidat.CurrentLivret;
            oLiv.DeletePJ();
        }



        public void CloturerL1etCreerL2()
        {
              Livret1VM oLiv = (Livret1VM)CurrentCandidat.CurrentLivret;
            // CloturerLivret1
            oLiv.IsLivretClos = true;
            ValideretQuitterL1();
            AjouteL2();
            Livret2VM oLiv2 = (Livret2VM)CurrentCandidat.CurrentLivret;
            if (oLiv.IsRecoursDemande )
            {
                oLiv2.IsOuvertureApresRecours = true;
            }
            if (!IsInTest)
            {
                CloseAction();
            }
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
        ///  Appel de la fenêtre de gestion des paramètres
        /// </summary>
        public void CalldlgParam()
        {
            dlgParametre oDlg = new dlgParametre();
            oDlg.setContexte(this);
            oDlg.ShowDialog();
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
            // Validation du conenu du Livret
            oL1VM.Commit();
            // Si le livret est Nouveau => Ajout dans la Collection des Livrets
            if (oL1VM.IsNew)
            {
                CurrentCandidat.AjouLivret1(oL1VM);
            }
            CurrentCandidat.refreshlstLivrets();
            //            _ctx.Histos.Add(new Histo("AjoutCandidat"));
            if (!IsInTest)
            {
                CloseAction();
            }
        }

        public void ValideretQuitterL2()
        {
            Livret2VM oL2VM = (Livret2VM)CurrentCandidat.CurrentLivret;

            // Validation du contenu du Livret
            oL2VM.Commit();
            // Mise à jour du diplome du candidat
            UpdateDiplomeCand(oL2VM);
            // Si le livret est Nouveau => Ajout dans la Collection des Livrets
            if (oL2VM.IsNew)
            {
                CurrentCandidat.AjoutLivret2(oL2VM);
            }
            if (!IsInTest)
            {
                CloseAction();
            }
        }

        private void UpdateDiplomeCand(Livret2VM pLivret)
        {

            DiplomeCandVM oDip = CurrentCandidat.getDiplomeCand(pLivret); 
            if (oDip != null)
            {
                if (pLivret.IsDecisionJuryFavorable)
                {
                    oDip.StatutDiplome = oDip.LstStatutDiplome[0];
                    foreach (DomaineCompetenceCand item in oDip.lstDCCands)
                    {
                        item.Statut = oDip.LstStatutModule[0];
                    }
                    oDip.DateObtentionDiplome = pLivret.DateJury;
                    oDip.NumeroDiplome = pLivret.NumeroDiplome;
                }
                if (pLivret.IsEtatRefuse)
                {
                    oDip.StatutDiplome = oDip.LstStatutDiplome[2];
                    foreach (DomaineCompetenceCand item in oDip.lstDCCands)
                    {
                        item.Statut = oDip.LstStatutModule[1];
                    }
                }
                if (pLivret.IsDecisionJuryPartielle)
                {
                    oDip.StatutDiplome = oDip.LstStatutDiplome[1];
                    foreach (DCLivretVM item in pLivret.lstDCLivretAValider)
                    {
                        DomaineCompetenceCand oDCCand =  oDip.lstDCCands.Where(d => d.NomDomaineCompetence == item.NomDC).FirstOrDefault();
                        if (oDCCand != null)
                        {
                            if (item.isDecisionFavorable)
                            {
                                oDCCand.Statut = "Validé";
                                oDCCand.DateObtention = pLivret.DateJury;
                            }
                            else
                            {
                                oDCCand.Statut = "Refusé";
                                oDCCand.DateObtention = pLivret.DateJury;
                            }
                        }
                    }

                }
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
                    DbEntityEntry  oEntity = oLiv.getEntity();
                    DbPropertyValues oValues = oEntity.CurrentValues;
#if _DEBUG_
                    foreach (String name in oValues.PropertyNames)
                    {
                            Console.WriteLine(String.Format("{0} = Original = {1}, current = {2}", name, oEntity.Property(name).OriginalValue, oEntity.Property(name).CurrentValue));
                    }
#endif
                    ResetCurrentLivret();
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
            return (_ctx.ChangeTracker.HasChanges() || _modelhasChanges);
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
                        CurrentCandidat.UnLock(_ContextID);
                        _ctx.Candidats.Remove(CurrentCandidat.TheCandidat);
                        lstCandidatVM.Remove(CurrentCandidat);
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
                    if (!CurrentCandidat.CurrentDiplomeCand.IsNew)
                    {
                        _ctx.Entry<DiplomeCand>((DiplomeCand)CurrentCandidat.CurrentDiplomeCand.TheDiplomeCand).State = System.Data.Entity.EntityState.Deleted;
                    }
                    else
                    {
                        // Detache l'entity
                        _ctx.Entry<DiplomeCand>((DiplomeCand)CurrentCandidat.CurrentDiplomeCand.TheDiplomeCand).State = System.Data.Entity.EntityState.Detached;
                    }

                    CurrentCandidat.CurrentDiplomeCand.IsDeleted = true;
                    CurrentCandidat.lstDiplomesCandVMs.Remove(CurrentCandidat.CurrentDiplomeCand);

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
        /// <summary>
        /// L'ajout du Livret1 est-il Autorisé sur la candidat Courant
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
                    // L'ajout d'un L1 n'est pas Disponible s'il y en a déja un de Valide
                    bReturn = !  CurrentCandidat.IsL1Valide;
                }
                return bReturn;
            }
        }
        public Boolean IsCurrentCandidatAddL2Available
        {
            get
            {
                Boolean bReturn = false;
                if (CurrentCandidat == null)
                {
                    bReturn = false;
                }
                if (IsCurrentCandidatLocked)
                {
                    // L'ajout d'un L2 est possible s'il y  a un L1 de Valide
                    if (CurrentCandidat.IsL1Valide)
                    {
                        // L'ajout d'un L2 est possible s'il n'y a  pas un autre L2 Valide
                        bReturn = !(CurrentCandidat.IsL2Valide);
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
            String strFilename;
            String Script;
            if (ofd.ShowDialog()== true)
            {
                strFilename = ofd.FileName;
                Script = File.ReadAllText(strFilename);
                IEnumerable<string> commandStrings = Regex.Split(Script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                System.Data.SqlClient.SqlConnection cnx = (SqlConnection)_ctx.Database.Connection;
                cnx.Open();

                try
                {
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command = new SqlCommand(commandString, cnx))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CSDebug.TraceException("ExecSQL", ex);
                }
                cnx.Close();
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
                using (Context ctx = new Context())
                {
                    Param objParam = _ctx.dbParam.FirstOrDefault();
                    if (objParam != null)
                    {
                        nReturn = objParam.NumCandidat;
                    }
                }
                return nReturn;
            }
            set
            {
                if (value != ParamNumCandidat)
                {
                    Context ctx = new Context();
                    Param objParam = _ctx.dbParam.FirstOrDefault();
                    if (objParam != null)
                    {
                        objParam.NumCandidat = value;
                    }
                    ctx.SaveChanges();

                }
            }
        }
        /// <summary>
        /// Prochain Numero de candidat
        /// </summary>
        public Int32 ParamNumLivret
        {
            get
            {
                Int32 nReturn = 0;
                using (Context ctx = new Context())
                {
                    Param objParam = _ctx.dbParam.FirstOrDefault();
                    if (objParam != null)
                    {
                        nReturn = objParam.NumLivret;
                    }
                }
                return nReturn;
            }
            set
            {
                if (value != ParamNumLivret)
                {
                    using (Context ctx = new Context())
                    {
                        Param objParam = _ctx.dbParam.FirstOrDefault();
                        if (objParam != null)
                        {
                            objParam.NumLivret = value;
                        }
                        ctx.SaveChanges();
                    }

                }
            }
        }

    }
}
