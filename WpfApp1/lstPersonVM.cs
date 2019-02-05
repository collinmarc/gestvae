using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class lstPersonVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string pNom = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pNom));
            }
        }

        private ObservableCollection<person> _lst;

        public ObservableCollection<person> Lst
        {
            get => _lst;
            set
            {
                if (value != _lst)
                {
                    _lst = value;
                    NotifyPropertyChanged();
                };
            }
        }

        private person _item;

        public person Item
        {
            get { return _item; }
            set
            {
                if (value != Item)
                {
                    _item = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public lstPersonVM()
        {
            Lst = new ObservableCollection<person>();
            person p  = new person("Collin");
            p.Prenom = "Marc";
            p.Age = 45;
            p.Sexe = "H";
            Lst.Add(p);

            //_razItem = new RelayCommand<person>((client) =>
            //{
            //    client.Nom = "";
            //    client.Prenom = "";
            //    client.Age = 0;
            //    client.Sexe = "";
            //}
            //);
            _razItem = new RAZPersonCommand((obj) =>
            {
                obj.Nom = "rien";
                obj.Prenom = "rien";
                obj.Age = -1;
                obj.Sexe = "?";
            }, (obj) => { return (obj != null);}
            );

            _addItem = new RAZPersonCommand((obj) =>
            {
                Lst.Add(new person("test"));
            }
            );

            _removeItem = new RAZPersonCommand((pitem) =>
            {
                Lst.Remove(pitem);
                Item = null;
            });

            _editItem = new RAZPersonCommand((pitem) =>
            {
                Item = pitem;
            });
        }

        private ICommand _razItem;
        public ICommand RAZItem
        {
            get
            {
                return _razItem;
            }
        }
        private ICommand _addItem;
        public ICommand ADDItem
        {
            get
            {
                return _addItem;
            }

        }
        private ICommand _removeItem;
        public ICommand REMOVEItem
        {
            get
            {
                return _removeItem;
            }

        }
        private ICommand _editItem;
        public ICommand EDITItem
        {
            get
            {
                return _editItem;
            }

        }
    }

}
