﻿using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class DCLivretVM : VMBase
    {
        public DCLivret TheDCLivret;

        public DCLivretVM():base()
        {
            TheDCLivret = new DCLivret();
        }

        public DCLivretVM(DCLivret pDCLivret):base(pDCLivret)
        {
            TheDCLivret = pDCLivret;
        }
        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<DCLivret> entry = _ctx.Entry<DCLivret>(TheDCLivret);
            return entry;
        }

        public String NomDC
        {
            get
            {
                return TheDCLivret.NomDC;
            }
        }
        public String Statut
        {
            get
            {
                return TheDCLivret.Statut;
            }
            set
            {
                if (Statut != value)
                {
                    TheDCLivret.Statut = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String ModeObtention
        {
            get
            {
                return TheDCLivret.ModeObtention;
            }
        }
        public DateTime? DateObtention
        {
            get
            {
                return TheDCLivret.DateObtention;
            }
        }
        public String Commentaire
        {
            get
            {
                return TheDCLivret.Commentaire;
            }
        }
        public String Decision
        {
            get
            {
                return TheDCLivret.Decision ;
            }
            set
            {
                if (value != Decision)
                {
                    TheDCLivret.Decision= value;
                    if (IsDecisionFavorable)
                    {
                        MotifGeneral = "";
                        MotifDetaille = "";
                        MotifCommentaire = "";
                        Statut = "Validé";
                    }
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsDecisionFavorable");
                    RaisePropertyChanged("IsDecisionDefavorable");
                }
            }
        }
        public Boolean IsDecisionFavorable
        {
            get {
                if (getNumDecision() > 0)
                {
                    return (getNumDecision() < (int)MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE);
                }
                else
                { // si pas de decision =< Pas favorable
                    return false;
                }
            }
            set
            {

                if (value != IsDecisionFavorable)
                {
                    if (value)
                    {
                        Decision = new Livret2VM(false).DecisionL2ModuleFavorable;
                    }
                    else
                    {
                        Decision = new Livret2VM(false).DecisionL2ModuleDeFavorable;
                    }
                }
            }
        }
        public Boolean IsDecisionDefavorable
        {
            get
            {
                    if (getNumDecision() > 0)
                    {
                        return (getNumDecision() == (int)MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE);
                    }
                    else
                    { // si pas de decision =< Pas défavorable
                        return true;
                    }
            }
            set
            {

                if (value != IsDecisionDefavorable)
                {
                    IsDecisionFavorable = !value;
                }
            }
        }
        public String MotifGeneral
        {
            get
            {
                return TheDCLivret.MotifGeneral;
            }
            set
            {
                if (value != MotifGeneral)
                {
                    TheDCLivret.MotifGeneral = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("lstMotifDetaille");
                }
            }
        }
        public String MotifDetaille
        {
            get
            {
                return TheDCLivret.MotifDetail;
            }
            set
            {
                if (value != MotifDetaille)
                {
                    TheDCLivret.MotifDetail = value;
                    RaisePropertyChanged();
                }
            }
        }

        public String MotifCommentaire
        {
            get
            {
                return TheDCLivret.MotifCommentaire;
            }
            set
            {
                if (value != MotifCommentaire)
                {
                    TheDCLivret.MotifCommentaire = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Boolean IsAValider
        {
            get { return TheDCLivret.IsAValider; }
            set
            {
                if (value != IsAValider)
                {
                    TheDCLivret.IsAValider = value;
                    RaisePropertyChanged();
                }
            }
        }
        public String PropositionDecision
        {
            get { return TheDCLivret.PropositionDecision; }
            set
            {
                if (value != PropositionDecision)
                {
                    TheDCLivret.PropositionDecision = value;
                    RaisePropertyChanged();
                }
            }
        }
        /// <summary>
        /// Liste des Motifs Détaillés pour le Motif General
        /// </summary>
        public List<String> lstMotifDetaille
        {
            get
            {
                List<String> oReturn = new List<String>();
                MotifGeneralL2 oPJMotifG= (from item in _ctxParam.dbMotifGeneralL2
                        where item.Libelle == MotifGeneral 
                        select item).FirstOrDefault();
                if (oPJMotifG != null)
                {
                    oReturn = (from item in oPJMotifG.lstMotifDetaille
                               select item.Libelle).ToList<String>();
                }

                return oReturn;
            }
        }
        private int getNumDecision()
        {
            int nReturn = 0;
            try
            {
                nReturn = Convert.ToInt32(this.Decision.Split('-')[0]);
            }
            catch (Exception)
            {
                nReturn = 0;
            }
            return nReturn;
        }

        public Boolean isDecisionFavorable
        {
            get
            {
                if (getNumDecision() > 0)
                {
                    return (getNumDecision() < (int)MyEnums.DecisionJuryL2.DECISION_L2_DEFAVORABLE);
                }
                else
                { // si pas de decision =< Pas favorable
                    return false;
                }

            }
        }


    }

}
