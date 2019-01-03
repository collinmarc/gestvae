using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class MyViewModel
    {
        private Context _ctx;
        public List<Candidat> candidats;
        public Candidat candidatSelected;

        public void getData()
        {
            _ctx = new Context();
            candidats = _ctx.Candidats.ToList<Candidat>();
            foreach (Candidat item in candidats)
            {
                if (item.Sexe == null)
                {
                    item.Sexe = Sexe.H;
                }
            } 
        }
        public void saveData()
        {
            _ctx.SaveChanges();
        }
    }
}
