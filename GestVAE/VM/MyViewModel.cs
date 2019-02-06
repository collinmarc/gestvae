
using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
        private Boolean _isBusy;
        private CandidatVM _candidatVM;
        private LivretVMBase _LivretVM;
        public Action CloseAction { get; set; }

        public CandidatVM CurrentCandidat
        {
            get { return _candidatVM; }
            set { _candidatVM = value;RaisePropertyChanged(); }
        }

        public LivretVMBase CurrentLivret
        {
            get { return _LivretVM; }
            set { _LivretVM = value; RaisePropertyChanged(); }
        }

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


        public MyViewModel()
        {
            _ctx = Context.instance;
            _lstCandidatVM = new ObservableCollection<CandidatVM>();
            _lstRegionVM = new ObservableCollection<RegionVM>();
            _lstDiplomeVM = new ObservableCollection<DiplomeVM>();
            _lstPieceJointeCategorie = new ObservableCollection<PieceJointeCategorie>();

            _SaveCommand = new SaveCommand(o => {   saveData(); },
                                           o => { return hasChanges(); }
                                          );
            _RefreshCommand = new RelayCommand<CandidatVM>(o => { getData(); } 
                                          );
           _PopulateCommand = new RelayCommand<CandidatVM>(o => { populate(); }
                                          );
            _AddCandidatCommand = new RelayCommand<CandidatVM>(o => { AddCandidat(); }
                                           );
            _dlgParamCommand = new RelayCommand<MyViewModel>(o => { CalldlgParam(); }
                                           );
            _RechercherCommand = new RelayCommand<MyViewModel>(o => { Recherche(); }
                                           );
            AjouteDiplomeCandCommand = new RelayCommand<MyViewModel>(o => { AjouteDiplomeCand(); }
                                           );
            AjouteL1Command = new RelayCommand<MyViewModel>(o => { AjouteL1(); }
                                           );
            AjoutePJL1Command = new RelayCommand<MyViewModel>(o => { AjoutePJL1(); }
                                           );
            AjouteL2Command = new RelayCommand<MyViewModel>(o => { AjouteL2(); }
                                           );
            dlgDiplomeCommand = new RelayCommand<MyViewModel>(o => { GestionDiplome(); }
                                           );
            ValideretQuitterL1Command = new RelayCommand<MyViewModel>(o => { ValideretQuitterL1(); }
                                           );
            CloseCommand = new RelayCommand<MyViewModel>(o => { CloseWindowL1(); }
                                           );

            //getData();
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
        public void saveData()
        {
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
            _ctx.SaveChanges();
        }


        public void getData()
        {
            IsBusy = true;
            Context.Reset();
            _ctx = Context.instance;

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
            CurrentCandidat = _lstCandidatVM[0];

            RaisePropertyChanged("lstCandidatVM");
            RaisePropertyChanged("CurrentCandidat");

              IsBusy = true;
  
            IsBusy = false;

        }

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
                if (item.lstLivrets1.Count ==1)
                { 
                Livret1 oL1 = item.lstLivrets1[0];
                oL1.OrigineDemande = tabvecteurs[oRand.Next(0, 20)];
                }
            }
            
            RaisePropertyChanged("lstCandidatsVM");
        }
        public void AddCandidat()
        {
            Candidat oCand = new Candidat("...");
            _ctx.Candidats.Add(oCand);
            CandidatVM oCandVM = new CandidatVM(oCand);
            lstCandidatVM.Add(oCandVM);
            CurrentCandidat = oCandVM;
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
       private ICommand _RefreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return _RefreshCommand;
            }
        }

        private ICommand _PopulateCommand;

        public ICommand PopulateCommand
        {
            get { return _PopulateCommand; }
        }

        private ICommand _AddCandidatCommand;

        public ICommand AddCandidatCommand
        {
            get { return _AddCandidatCommand; }
        }
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
        public ICommand AjouteL2Command { get; set; }
        public ICommand ValideretQuitterL1Command { get; set; }
        public ICommand CloseCommand { get; set; }
        public String rechIdentifiantVAE { get; set; }
        public String rechNom { get; set; }
        public String rechPrenom { get; set; }
        public String rechVille { get; set; }
        public DateTime? rechDateNaissance { get; set; }
        public DateTime? rechDateReceptL1Deb { get; set; }
        public DateTime? rechDateReceptL1Fin { get; set; }
        public DateTime? rechDateReceptL2Deb { get; set; }
        public DateTime? rechDateReceptL2Fin { get; set; }

        public void Recherche()
        {
            IQueryable<Candidat> rq = _ctx.Candidats;
            if (!String.IsNullOrEmpty(rechIdentifiantVAE))
            {
                rq = rq.Where(c => c.IdVAE.Equals(rechIdentifiantVAE));
            }
            if (!String.IsNullOrEmpty(rechNom))
            {
                rq = rq.Where(c => c.Nom.Equals(rechNom));
            }
            if (rechDateNaissance!= null)
            {
                rq = rq.Where(c => c.DateNaissance.Value.Equals(rechDateNaissance.Value));

            }
            _lstCandidatVM.Clear();
            foreach (Candidat item in rq)
            {

               CandidatVM oCand = new CandidatVM(item);
                _lstCandidatVM.Add(oCand);
            }
            RaisePropertyChanged("lstCandidatVM");
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
            Livret1 oLiv = (Livret1)oCandVM.TheCandidat.CreerLivret1(Diplome.getDiplomeParDefaut());
            Livret1VM oLivVM = new Livret1VM(oLiv);
            this.CurrentLivret = oLivVM;

            frmLivret1 odlg = new frmLivret1();

            odlg.setContexte(this);

            odlg.ShowDialog();
        }//AjouteL1
        public void AjoutePJL1()
        {
            CandidatVM oCandVM = CurrentCandidat;
            Livret1VM oLiv = (Livret1VM) CurrentLivret;
            oLiv.AjoutePJ();
        }

        /// <summary>
        /// Ajout d'un Livret2
        /// </summary>
        public void AjouteL2()
        {
            CandidatVM oCandVM = CurrentCandidat;
            Livret2VM oLivVM = oCandVM.AjoutLivret2();
            frmLivret2 odlg = new frmLivret2();

            odlg.setContexte(oLivVM);

            odlg.ShowDialog();
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

        public void ValideretQuitterL1()
        {
            Livret1VM oL1VM = (Livret1VM)CurrentLivret;
            CurrentCandidat.lstLivrets.Add(oL1VM);
            CurrentCandidat.TheCandidat.lstLivrets1.Add((Livret1)oL1VM.TheLivret);
            RaisePropertyChanged("lstLivrets");
            CloseAction();
        }


        public void CloseWindowL1()
        {
            var lstEnt = _ctx.ChangeTracker.Entries<Livret1>().Where(i=>i.Entity.ID== CurrentLivret.TheLivret.ID);
            foreach (var oLiv in lstEnt)
            {
                if (oLiv.State == EntityState.Modified)
                {
                    oLiv.CurrentValues.SetValues(oLiv.OriginalValues);
                }
            }
            CurrentCandidat.refreshlstLivrets();
            CloseAction();
        }
        public bool hasChanges()
        {
            return (_ctx.ChangeTracker.HasChanges() || _modelhasChanges);
        }
        public void ModelHasChanges()
        {
            _modelhasChanges = true;
        }

    }
}
