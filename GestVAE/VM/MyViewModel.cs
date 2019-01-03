
using GestVAEcls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestVAE.VM
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private Context _ctx;
        private ObservableCollection<Candidat> _candidats;
        public Candidat candidatSelected;

        public event PropertyChangedEventHandler PropertyChanged;
        public MyViewModel()
        {
            _candidats = new ObservableCollection<Candidat>();
        }
        public ObservableCollection<Candidat> Lst
        {
            get => _candidats;
            set
            {
                if (value != _candidats)
                {
                    _candidats = value;
                    NotifyPropertyChanged();
                };
            }
        }

        public void NotifyPropertyChanged([CallerMemberName] string pNom = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pNom));
            }
        }


        public void getData()
        {
            _ctx = new Context();
            _candidats.Clear();
            foreach (Candidat item in _ctx.Candidats)
            {
                if (item.Sexe == null)
                {
                    item.Sexe = Sexe.H;
                }
                _candidats.Add(item);
            } 
        }
        public void saveData()
        {
            _ctx.SaveChanges();
        }

        public ICommand SaveCommand
        {
            get;
            internal set;
        }

        private bool CanExecuteSaveCommand()
        {
            return _ctx.ChangeTracker.HasChanges();
        }

        private void CreateSaveCommand()
        {
           // SaveCommand = new SaveCommand(SaveExecute, CanExecuteSaveCommand);
        }

        public void SaveExecute()
        {
            _ctx.SaveChanges();
        }
    }
}
