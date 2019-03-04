using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class JuryVM : VMBase
    {
        private Jury TheJury;
        public ObservableCollection<RecoursVM> lstRecoursVM;

        public JuryVM(GestVAEcls.Jury pJury) : base(pJury)
        {
            TheJury = pJury;
            lstRecoursVM = new ObservableCollection<RecoursVM>();
            foreach (var item in TheJury.lstRecours)
            {
                RecoursVM oRecours = new RecoursVM(item);
                lstRecoursVM.Add(oRecours);
            }
            IsNew = false;
        }

        public JuryVM() : base()
        {
            TheJury = new Jury();
            TheItem = TheJury;
            lstRecoursVM = new ObservableCollection<RecoursVM>();
            IsNew = true;
            create1erRecours();

        }
        private void create1erRecours()
        {
            lstRecoursVM.Add(new RecoursVM());
        }
        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<Jury> entry = _ctx.Entry<Jury>(TheJury);
            return entry;
        }

        public Int32 NumeroOrdre
        {
            get { return TheJury.NumeroOrdre; }
            set { TheJury.NumeroOrdre = value; RaisePropertyChanged(); }
        }
        public String Nom
        {
            get { return TheJury.NomJury; }
            set { TheJury.NomJury = value; RaisePropertyChanged(); }
        }
        public DateTime? DateJury
        {
            get { return TheJury.DateJury; }
            set { TheJury.DateJury = value; RaisePropertyChanged(); }
        }
        public DateTime? HeureJury
        {
            get { return TheJury.HeureJury; }
            set { TheJury.HeureJury = value; RaisePropertyChanged(); }
        }
        public DateTime? HeureConvoc
        {
            get { return TheJury.HeureConvoc; }
            set { TheJury.HeureConvoc = value; RaisePropertyChanged(); }
        }
        public DateTime? DateLimiteRecours
        {
            get { return TheJury.DateLimiteRecours; }
            set { TheJury.DateLimiteRecours = value; RaisePropertyChanged(); }
        }
        public String LieuJury
        {
            get { return TheJury.LieuJury; }
            set { TheJury.LieuJury = value; RaisePropertyChanged(); }
        }
        public String Decision
        {
            get { return TheJury.Decision; }
            set { TheJury.Decision = value; RaisePropertyChanged(); }
        }
        public String MotifGeneral
        {
            get { return TheJury.MotifGeneral; }
            set { TheJury.MotifGeneral = value; RaisePropertyChanged(); }
        }
        public String MotifDetail
        {
            get { return TheJury.MotifDetail; }
            set { TheJury.MotifDetail = value; RaisePropertyChanged(); }
        }
        public String MotifCommentaire
        {
            get { return TheJury.MotifCommentaire; }
            set { TheJury.MotifCommentaire = value; RaisePropertyChanged(); }
        }
        public DateTime? DateNotificationJury
        {
            get { return TheJury.DateNotificationJury; }
            set { TheJury.DateNotificationJury = value; RaisePropertyChanged(); }
        }
        public DateTime? DateNotificationJuryRecours
        {
            get { return TheJury.DateNotificationJuryRecours; }
            set { TheJury.DateNotificationJuryRecours = value; RaisePropertyChanged(); }
        }
        public Boolean IsRecours
        {
            get { return TheJury.IsRecours; }
            set { TheJury.IsRecours = value; RaisePropertyChanged(); }
        }
        public RecoursVM oRecours
        {
            get
            {
                if (lstRecoursVM.Count == 0)
                {
                    create1erRecours();
                }
                return lstRecoursVM[0];
            }
        }

        public override Boolean HasChanges()
        {
            Boolean bReturn = false;
            EntityState state  = (getEntity().State);
            bReturn = (state == System.Data.Entity.EntityState.Modified);
            if (!bReturn)
            {
                if (lstRecoursVM.Count>0)
                {
                    RecoursVM oRecours = lstRecoursVM[0];
                    bReturn = oRecours.HasChanges();
                }
            }
            return bReturn;

        }

        public override Boolean Reset()
        {
            try
            {
                base.Reset();
                foreach (RecoursVM item in lstRecoursVM)
                {
                    item.Reset();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }//Reset
        public virtual void Commit()
        {
            foreach (RecoursVM item in lstRecoursVM)
            {
                Recours obj = (Recours)item.TheItem;
                if (_ctx.Entry<Recours>(obj).State == System.Data.Entity.EntityState.Detached)
                {
                    TheJury.lstRecours.Add(obj);
                }
            }


        }

    }
}
