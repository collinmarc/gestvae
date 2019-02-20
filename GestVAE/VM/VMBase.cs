using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class VMBase : NotifyUIBase
    {

        protected Context _ctx = Context.instance;
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

        public  VMBase()
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
    }
}
