using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public abstract class Livret : GestVAE
    {
        public DateTime? DateEcheance { get; set; }
        [NotMapped]
        public String Typestr { get; set; }
        public Boolean isContrat { get; set; }
        public String TypeDemande { get; set; }
        public String OrigineDemande { get; set; }

        public String EtatLivret { get; set; }
        public DateTime? DateEnvoiEHESP { get; set; }
        public DateTime? DateEnvoiCandidat { get; set; }
        public DateTime? DateReceptEHESP { get; set; }
        public DateTime? DateReceptCandidat { get; set; }
        public Boolean isEnvoiEHESP_AR { get; set; }
        public Boolean isEnvoiCand_AR { get; set; }
        public  virtual ObservableCollection<Jury> lstJurys { get; set; }
        public Livret()
        {
            EtatLivret = "";
            Typestr = "";
            lstJurys = new ObservableCollection<Jury>();
        }


    }
    public class Livret1 : Livret
    {
        public String Numero { get; set; }
        public DateTime? DateDemande { get; set; }


        public virtual ObservableCollection<PieceJointeL1> lstPiecesJointes { get; set; }
        public virtual ObservableCollection<EchangeL1> lstEchanges { get; set; }
        [Required]
        public virtual Candidat oCandidat { get; set; }

        public Livret1():base()
        {
            Typestr = "LIVRET1";
            lstPiecesJointes = new ObservableCollection<PieceJointeL1>();
            lstEchanges = new ObservableCollection<EchangeL1>();
        }


    }
    public class Livret2 : Livret
    {

        public int Numero { get; set; }
        public DateTime? DateDemande { get; set; }

        public virtual ObservableCollection<PieceJointeL2> lstPiecesJointes { get; set; }
        public virtual ObservableCollection<EchangeL2> lstEchanges { get; set; }
        [Required]
        public virtual Candidat oCandidat { get; set; }

        public Livret2():base()
        {
            Typestr = "LIVRET2";
            lstPiecesJointes = new ObservableCollection<PieceJointeL2>();
            lstEchanges = new ObservableCollection<EchangeL2>();
        }

    }
}
