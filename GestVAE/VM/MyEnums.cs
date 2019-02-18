using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
   public  class MyEnums
    {

        public enum EtatL1
        {
            ETAT_L1_DEMANDE = 10,
            ETAT_L1_ENVOYE = 20,
            ETAT_L1_RECU_INCOMPLET = 30,
            ETAT_L1_RECU_COMPLET = 40,
            ETAT_L1_REFUSE = 50,
            ETAT_L1_RECOURS = 60,
            ETAT_L1_ACCEPTE = 70,
            ETAT_L1_CLOTURER = 90
        }
        public enum DecisionJuryL1
        {
            DECISION_L1_FAVORABLE = 10,
            DECISION_L1_DEFAVORABLE = 20
        }
        public enum DecisionJuryL2
        {
            DECISION_L2_FAVORABLE = 10,
            DECISION_L2_DEFAVORABLE = 20,
            DECISION_L2_PARTIELLE = 30
        }

    }
}
