using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{

    public enum Sexe { F, H };
    public enum EnumTypeCommentaire {
        [Description("Information")]
        INFO,
        [Description("Important")]
        IMPORTANT
    };
    public class Candidat : GestVAEBase
    {
        public String Civilite { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Prenom2 { get; set; }
        public String Prenom3 { get; set; }
        public Sexe? Sexe { get; set; }
        public String IdVAE { get; set; }
        public String IdSiscole { get; set; }
        public String NomJeuneFille { get; set; }
        public String Nationalite { get; set; }
        public DateTime? DateNaissance { get; set; }
        public String CPNaissance { get; set; }
        public String VilleNaissance { get; set; }
        public String DptNaissance { get; set; }
        public String NationaliteNaissance { get; set; }
        public String PaysNaissance { get; set; }
        public String Adresse { get; set; }
        public String CodePostal { get; set; }
        public String Ville { get; set; }
        public String Region { get; set; }
        public String Pays { get; set; }
        public String RegionTravail { get; set; }
        public String CPTravail { get; set; }
        public String VilleTravail { get; set; }
        public String Mail1 { get; set; }
        public String Mail2 { get; set; }
        public String Mail3 { get; set; }
        public String Tel1 { get; set; }
        public String Tel2 { get; set; }
        public String Tel3 { get; set; }
        public Boolean bHandicap { get; set; }
        public String TypeDemande { get; set; }
        public virtual ObservableCollection<DiplomeCand> lstDiplomes { get; set; }
        // Il faut laisser les Virtual sur ces Collections même si on ne fait pas le Lazy Loading
        public virtual ObservableCollection<Livret1> lstLivrets1 { get; set; }
        public virtual ObservableCollection<Livret2> lstLivrets2 { get; set; }
        public Boolean ISPostFormation { get; set; }
        public String Commentaire { get; set; }
        public EnumTypeCommentaire? TypeCommentaire { get; set; }


        public Candidat() :base()
        {
            Nom = "";
            Prenom = "";
            bHandicap = false;
            lstDiplomes = new ObservableCollection<DiplomeCand>();
            lstLivrets1 = new ObservableCollection<Livret1>();
            lstLivrets2 = new ObservableCollection<Livret2>();
            Nationalite = "Française";
            NationaliteNaissance = "Française";
            Pays = "France";
            PaysNaissance = "France";
        }
        public Candidat(String pNom) : this ()
        {
            Nom = pNom;
            Sexe = GestVAEcls.Sexe.H;
        }

        public DiplomeCand AddDiplome(Diplome pDiplome = null, String pStatut = "Validé")
        {
            DiplomeCand oReturn = null;
            if (pDiplome == null)
            {
                pDiplome = Diplome.getDiplomeParDefaut();
            }
            oReturn = new DiplomeCand(pDiplome, DateTime.Now);
            oReturn.Statut = pStatut;
//            oReturn.oCandidat = this;
            this.lstDiplomes.Add(oReturn);

            return oReturn;
        }


        public Livret CreerLivret1(Diplome pDiplome)
        {
            Livret oReturn = null;

            oReturn = new Livret1();
            oReturn.oDiplome = pDiplome;
            return oReturn;
        }
 
    }
}
