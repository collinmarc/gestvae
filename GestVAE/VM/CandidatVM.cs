using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestVAE.VM
{
    public class CandidatVM:VMBase
    {

        const String cstDEIS = "DEIS";
        const String cstCAFERUIS = "CAFERUIS";
        const String cstCAFDES = "CAFDES";
        public Candidat TheCandidat { get; set; }
        public ObservableCollection<DiplomeCandVM> lstDiplomesCandVMs { get; set; }
        public ObservableCollection<LivretVMBase> lstLivrets { get; set; }
        public CandidatVM(Candidat pCandidat)
        {
            TheCandidat = pCandidat;
            lstDiplomesCandVMs = new ObservableCollection<DiplomeCandVM>();
            lstLivrets = new ObservableCollection<LivretVMBase>();
            foreach (DiplomeCand item in pCandidat.lstDiplomes)
            {
                DiplomeCandVM oDipCand = new DiplomeCandVM(item);
                lstDiplomesCandVMs.Add(oDipCand);
            }
            foreach (Livret1 item in pCandidat.lstLivrets1)
            {
                Livret1VM oLivret = new Livret1VM(item);
                lstLivrets.Add(oLivret);
            }
            foreach (Livret2 item in pCandidat.lstLivrets2)
            {
                Livret2VM oLivret = new Livret2VM(item);
                lstLivrets.Add(oLivret);
            }

        }
        public CandidatVM()
        {
            TheCandidat = new Candidat();
            lstDiplomesCandVMs = new ObservableCollection<DiplomeCandVM>();
            lstLivrets = new ObservableCollection<LivretVMBase>();
            foreach (DiplomeCand item in TheCandidat.lstDiplomes)
            {
                DiplomeCandVM oDipCand = new DiplomeCandVM(item);
                lstDiplomesCandVMs.Add(oDipCand);
            }
            foreach (Livret1 item in TheCandidat.lstLivrets1)
            {
                Livret1VM oLivret = new Livret1VM(item);
                lstLivrets.Add(oLivret);
            }
            foreach (Livret2 item in TheCandidat.lstLivrets2)
            {
                Livret2VM oLivret = new Livret2VM(item);
                lstLivrets.Add(oLivret);
            }

        }

        private DiplomeCandVM diplomeCAFDESCandidat
        {
            get
            {
                return (from oDiplomeCand in lstDiplomesCandVMs
                        where oDiplomeCand.oDiplome.Nom == cstCAFDES
                        select oDiplomeCand).FirstOrDefault<DiplomeCandVM>();
            }
        }
        private DiplomeCandVM diplomeDEISCandidat
        {
            get
            {
                return (from oDiplomeCand in lstDiplomesCandVMs
                        where oDiplomeCand.oDiplome.Nom == cstDEIS
                        select oDiplomeCand).FirstOrDefault<DiplomeCandVM>();
            }
        }
        private DiplomeCandVM diplomeCAFERUISCandidat
        {
            get
            {
                return (from oDiplomeCand in lstDiplomesCandVMs
                        where oDiplomeCand.oDiplome.Nom == cstCAFERUIS
                        select oDiplomeCand).FirstOrDefault<DiplomeCandVM>();
            }
        }
        public Boolean IsDEIS
        {
            get
            {
                return (diplomeDEISCandidat != null);
            }
            set
            {
                if (value != IsDEIS)
                {
                    if (value)
                    {
                        Diplome oDiplome = (from o in _ctx.Diplomes where o.Nom == cstDEIS select o).FirstOrDefault<Diplome>();
                        DiplomeCandVM oDip = AjoutDiplomeCand(oDiplome);
                    }
                    else
                    {
                        DiplomeCandVM oDip = diplomeDEISCandidat;
                        _ctx.DiplomeCands.Remove(oDip.TheDiplomeCand);
//                        diplomeDEISCandidat.TheDiplomeCand.bDeleted = true;
                        lstDiplomesCandVMs.Remove(oDip);
                        
                    }
                }
            }
        }
        public DateTime? DateObtentionDEIS
        {
            get
            {
                if (diplomeDEISCandidat != null)
                { return diplomeDEISCandidat.DateObtentionDiplome; }
                else

                { return null; }
            }
            set
            {
                if (value != DateObtentionDEIS)
                {
                    diplomeDEISCandidat.DateObtentionDiplome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String NumeroDEIS
        {
            get
            {
                if (diplomeDEISCandidat != null)
                { return diplomeDEISCandidat.NumeroDiplome; }
                else

                { return ""; }
            }
            set
            {
                if (value != NumeroDEIS)
                {
                    diplomeDEISCandidat.NumeroDiplome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsCAFERUIS
        {
            get
            {
                return (diplomeCAFERUISCandidat != null);
            }
            set
            {
                if (value != IsCAFERUIS)
                {
                    if (value)
                    {

                        Diplome oDiplome = (from o in _ctx.Diplomes where o.Nom == cstCAFERUIS select o).FirstOrDefault<Diplome>();
                        DiplomeCandVM oDip = AjoutDiplomeCand(oDiplome);
                    }
                    else
                    {
                        DiplomeCandVM oDip = diplomeCAFERUISCandidat;
                        _ctx.DiplomeCands.Remove(oDip.TheDiplomeCand);
                        //                        diplomeDEISCandidat.TheDiplomeCand.bDeleted = true;
                        lstDiplomesCandVMs.Remove(oDip);
                    }
                }
            }
        }
        public DateTime? DateObtentionCAFERUIS
        {
            get
            {
                if (diplomeCAFERUISCandidat != null)
                { return diplomeCAFERUISCandidat.DateObtentionDiplome; }
                else

                { return null; }
            }
            set
            {
                if (value != DateObtentionCAFERUIS)
                {
                    diplomeCAFERUISCandidat.DateObtentionDiplome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String NumeroCAFERUIS
        {
            get
            {
                if (diplomeCAFERUISCandidat != null)
                { return diplomeCAFERUISCandidat.NumeroDiplome; }
                else

                { return ""; }
            }
            set
            {
                if (value != NumeroCAFERUIS)
                {
                    diplomeCAFERUISCandidat.NumeroDiplome = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Boolean IsCAFDES
        {
            get
            {
                return (diplomeCAFDESCandidat != null);
            }
            set
            {
                if (value != IsCAFDES)
                {
                    if (value)
                    {
                         Diplome oDiplome = (from o in _ctx.Diplomes where o.Nom == cstCAFDES select o).FirstOrDefault<Diplome>();
                        DiplomeCandVM oDip = AjoutDiplomeCand(oDiplome);
                    }
                    else
                    {
                        DiplomeCandVM oDip = diplomeCAFDESCandidat;
                        _ctx.DiplomeCands.Remove(oDip.TheDiplomeCand);
                        //                        diplomeDEISCandidat.TheDiplomeCand.bDeleted = true;
                        lstDiplomesCandVMs.Remove(oDip);
                    }
                }
            }
        }

        public DiplomeCandVM AjoutDiplomeCand()
        {
            DiplomeCand oDiplCand = TheCandidat.AddDiplome();
            DiplomeCandVM oDiplomeCand = new DiplomeCandVM(oDiplCand);
            lstDiplomesCandVMs.Add(oDiplomeCand);
            RaisePropertyChanged("lstDiplomesCandVMs");
            return oDiplomeCand;
        }

        public DiplomeCandVM AjoutDiplomeCand(Diplome pDiplome)
        {
            DiplomeCand oDiplCand = TheCandidat.AddDiplome(pDiplome);
            DiplomeCandVM oDiplomeCand = new DiplomeCandVM(oDiplCand);
            lstDiplomesCandVMs.Add(oDiplomeCand);
            RaisePropertyChanged("lstDiplomesCandVMs");
            return oDiplomeCand;
        }

        public Livret1VM AjoutLivret1()
        {
            Livret1 oLiv = new Livret1();
            oLiv.Numero = DateTime.Now.ToString("yyyyMMddHHmm");
            Livret1VM oLivVM = new Livret1VM(oLiv);
            TheCandidat.lstLivrets1.Add(oLiv);
            lstLivrets.Add(oLivVM);
            RaisePropertyChanged("lstLivrets");
            return oLivVM;
        }

        public Livret2VM AjoutLivret2()
        {
            Diplome oDiplome = Diplome.getDiplomeParDefaut();
            Livret2 oLiv = new Livret2(oDiplome);
            oLiv.EtatLivret = "0-Demandé";
            oLiv.DateDemande = DateTime.Now;
            oLiv.Numero = TheCandidat.lstLivrets2.Count() + 1;
            TheCandidat.lstLivrets2.Add(oLiv);
            Livret2VM oLiv2VM = new Livret2VM(oLiv);
            lstLivrets.Add(oLiv2VM);
            RaisePropertyChanged("lstLivrets");
            return oLiv2VM;
        }
        public Livret2VM AjoutLivret2(Diplome pDiplome)
        {
            Livret2 oLiv = new Livret2(pDiplome);
            oLiv.EtatLivret = "0-Demandé";
            oLiv.DateDemande = DateTime.Now;
            oLiv.Numero = TheCandidat.lstLivrets2.Count() + 1;
            TheCandidat.lstLivrets2.Add(oLiv);
            Livret2VM oLiv2VM = new Livret2VM(oLiv);
            lstLivrets.Add(oLiv2VM);
            RaisePropertyChanged("lstLivrets");
            return oLiv2VM;
        }

        public void Commit()
        {
            foreach (DiplomeCandVM item in lstDiplomesCandVMs)
            {
                item.Commit();
            }
            if (_ctx.Entry<Candidat>(TheCandidat).State == System.Data.Entity.EntityState.Detached)
            {
                _ctx.Candidats.Add(TheCandidat);
            }
            if (_ctx.Entry<Candidat>(TheCandidat).State == System.Data.Entity.EntityState.Deleted)
            {
                _ctx.Candidats.Remove(TheCandidat);
            }
        }

    }
}
