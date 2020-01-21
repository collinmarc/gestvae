using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public abstract class VMBase : NotifyUIBase
    {

        protected Context _ctx = Context.instance;
        protected ContextParam _ctxParam = new ContextParam();
        private bool isNew = true;
        public GestVAEBase TheItem { get; set; }
        public bool IsNew
        {
            get { return isNew; }
            set
            {
                isNew = value;
                RaisePropertyChanged();
            }
        }
        private bool isSelected = false;

        public bool IsSelected
        {
            get { return isSelected; }
            set 
            { 
                isSelected = value;
                RaisePropertyChanged();
            }
        }
        private bool isDeleted = false;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set
            {
                isDeleted = value;
                RaisePropertyChanged();
            }
        }

        public virtual Boolean IsLocked { get; set; }
        public Boolean IsUnlocked {
            get { return !IsLocked; }
        }

        public VMBase()
        {
            IsNew = true;
            IsDeleted = false;
            IsSelected = false;
        }
        public VMBase(GestVAEBase pItem)
        {
            IsNew = false;
            IsDeleted = false;
            IsSelected = false;
            TheItem = pItem;
        }


        public Int32 ID
        {
            get { return TheItem.ID; }
        }
        public DateTime DateCreation
        {
            get { return TheItem.dateCreation; }
            set
            {
                if (value != DateCreation)
                {
                    TheItem.dateCreation = value;
                    RaisePropertyChanged();
                }
            }
        }

        public abstract DbEntityEntry getEntity();

        public virtual Boolean Reset()
        {
            try
            {
                DbEntityEntry entry = getEntity();
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }//Reset

        public virtual Boolean HasChanges()
        {
            Boolean bReturn = false;
            EntityState state = getEntity().State;
            bReturn = (state != System.Data.Entity.EntityState.Unchanged);
            return bReturn;

        }

    }
}
