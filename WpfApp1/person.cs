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
    public class person : INotifyPropertyChanged
    {

        private String nom;
        private String prenom;
        private Int32 age;
        private String sexe;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string pNom = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pNom));
            }
        }

        public person(String pNom)
        {
            Nom = pNom;
        }
        public string Nom
        {
            get => nom;
            set
            {
                if (nom != value)
                {
                    nom = value;
                    NotifyPropertyChanged();

                }
            }
        }
        public string Prenom
        {
            get => prenom;
            set
            {
                if (prenom != value)
                {
                    prenom = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Int32 Age
        {
            get => age;
            set
            {
                if (age != value)
                {
                    age = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public String Sexe
        {
            get => sexe;
            set
            {
                if (sexe != value)
                {
                    sexe = value;
                    NotifyPropertyChanged();
                }
            }
        }

    }
}
