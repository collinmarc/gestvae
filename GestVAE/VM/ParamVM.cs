using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class ParamVM: VMBase
    {
        public ParamVM(GestVAEcls.Param pParam):base(pParam)
        {
            IsNew = false;
        }
        public Param TheParam {
            get { return (Param)TheItem; }
        }
        public override DbEntityEntry getEntity()
        {
            DbEntityEntry<Param> entry = _ctx.Entry<Param>(TheParam);
            return entry;
        }

        public Int32 NumLivret
        {
            get { return TheParam.NumLivret; }
            set { TheParam.NumLivret= value; }
        }
        public void Commit()
        {
            if (_ctx.Entry<Param>(TheParam).State == System.Data.Entity.EntityState.Detached)
            {
                _ctx.dbParam.Add(TheParam);
            }
            if (_ctx.Entry<Param>(TheParam).State == System.Data.Entity.EntityState.Deleted)
            {
                _ctx.dbParam.Remove(TheParam);
            }
        }

        public static Int32 incrementLivret()
        {
            Context ctx = new Context();
            Param oParam = ctx.dbParam.FirstOrDefault();
            if (oParam == null)
            {
                oParam = new Param();
                oParam.NumLivret = 0;
                ctx.dbParam.Add(oParam);
            }
            Int32 nReturn = oParam.NumLivret++;
            ctx.SaveChanges();
            return nReturn;
        }

    }
}
