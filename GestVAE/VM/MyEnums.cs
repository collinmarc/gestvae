using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
   public  class MyEnums
    {

        public enum EtatLivret
        {
            ETAT_Lv_SANS_SUITE = 05,
            ETAT_Lv_DEMANDE = 10,
            ETAT_Lv_ENVOYE = 20,
            ETAT_Lv_RECU_INCOMPLET = 30,
            ETAT_Lv_RECU_COMPLET = 40,
            ETAT_Lv_REFUSE = 50,
            ETAT_Lv_RECOURS = 60,
            ETAT_Lv_ACCEPTE = 70,
            ETAT_Lv_CLOTURER = 90
        }
        public enum DecisionJuryL1
        {
            DECISION_L1_FAVORABLE = 10,
            DECISION_L1_DEFAVORABLE = 20,
            DECISION_L1_PARTIELLE = 30,
        }
        public enum DecisionJuryL2
        {
            DECISION_L2_FAVORABLE = 10,
            DECISION_L2_DEFAVORABLE = 20,
            DECISION_L2_PARTIELLE = 30
        }

    }
}
