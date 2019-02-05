using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class RegionVM: VMBase
    {
        private Region TheRegion;
        public RegionVM(GestVAEcls.Region pRegion)
        {
            TheRegion = pRegion;
            IsNew = false;
        }

        public RegionVM()
        {
            TheRegion = new Region();
            IsNew = true;
        }

        public String Nom
        {
            get { return TheRegion.Nom; }
            set { TheRegion.Nom = value; }
        }

        public Region RegionItem
        {
            get { return TheRegion; }
        }
        public void Commit()
        {
            if (_ctx.Entry<Region>(TheRegion).State == System.Data.Entity.EntityState.Detached)
            {
                _ctx.Regions.Add(TheRegion);
            }
            if (_ctx.Entry<Region>(TheRegion).State == System.Data.Entity.EntityState.Deleted)
            {
                _ctx.Regions.Remove(TheRegion);
            }
        }

    }
}
