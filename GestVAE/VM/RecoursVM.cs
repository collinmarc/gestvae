using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class RecoursVM : VMBase
    {
        private Recours TheRecours;
        public RecoursVM(GestVAEcls.Recours pRecours) : base(pRecours)
        {
            TheRecours = pRecours;
            IsNew = false;
        }

        public RecoursVM() : base()
        {
            TheRecours = new Recours();
            TheItem = TheRecours;

            IsNew = true;
        }
        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<Recours> entry = _ctx.Entry<Recours>(TheRecours);
            return entry;
        }

        public DateTime? DateDepot
        {
            get { return TheRecours.DateDepot; }
            set { TheRecours.DateDepot = value; RaisePropertyChanged(); }
        }
        public DateTime? DateJury
        {
            get { return TheRecours.DateJury; }
            set { TheRecours.DateJury = value; RaisePropertyChanged(); }
        }
        public EnumTypeRecours TypeRecours
        {
            get { return TheRecours.TypeRecours; }
            set { TheRecours.TypeRecours = value; RaisePropertyChanged(); }
        }
        public String MotifRecoursCommentaire
        {
            get { return TheRecours.MotifRecoursCommentaire; }
            set { TheRecours.MotifRecoursCommentaire = value; RaisePropertyChanged(); }
        }
        public String MotifRecours
        {
            get { return TheRecours.MotifRecours; }
            set { TheRecours.MotifRecours = value; RaisePropertyChanged(); }
        }
        public DateTime? DateLimiteJury
        {
            get { return TheRecours.DateLimiteJury; }
            set { TheRecours.DateLimiteJury = value; RaisePropertyChanged(); }
        }
        public String NomJury
        {
            get { return TheRecours.NomJury; }
            set { TheRecours.NomJury = value; RaisePropertyChanged(); }
        }
        public String LieuJury
        {
            get { return TheRecours.LieuJury; }
            set { TheRecours.LieuJury = value; RaisePropertyChanged(); }
        }
        public String Decision
        {
            get { return TheRecours.Decision; }
            set { TheRecours.Decision = value; RaisePropertyChanged(); }
        }
        public String MotifGeneral
        {
            get { return TheRecours.MotifGeneral; }
            set { TheRecours.MotifGeneral = value; RaisePropertyChanged(); }
        }
        public String MotifDetail
        {
            get { return TheRecours.MotifDetail; }
            set { TheRecours.MotifDetail = value; RaisePropertyChanged(); }
        }
        public String MotifCommentaire
        {
            get { return TheRecours.MotifCommentaire; }
            set { TheRecours.MotifCommentaire = value; RaisePropertyChanged(); }
        }

    }
}
