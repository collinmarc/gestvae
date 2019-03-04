using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class RegionVM: VMBase
    {
        private Region TheRegion;
        public RegionVM(GestVAEcls.Region pRegion):base(pRegion)
        {
            TheRegion = pRegion;
            IsNew = false;
        }

        public RegionVM():base()
        {
            TheRegion = new Region();
            IsNew = true;
        }
        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<Region> entry = _ctx.Entry<Region>(TheRegion);
            return entry;
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
