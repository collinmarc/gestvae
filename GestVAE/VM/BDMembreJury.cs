using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAE.VM
{
    public class BDMembreJury
    {
        [Index(0)]
        public string PROMO { get; set; }

        [Index(1)]
        public string Infos { get; set; }
        [Name("Collège membre")]
        public string College_membre { get; set; }
        [Name("Fonction")] public string Fonction { get; set; }
        [Name("Fonction antérieure")] public string Fonction_anterieure { get; set; }
        [Name("Civilité_Sup")] public string Civilite_Sup { get; set; }
        [Name("Nom_Sup")] public string Nom_Sup { get; set; }
        [Name("Fonction_sup")] public string Fonction_sup { get; set; }
        [Name("MatEHESP")] public string MatEHESP { get; set; }
        [Name("Civilité")] public string Civilite { get; set; }
        [Name("Nom")] public string Nom { get; set; }
        [Name("Prénom")] public string Prenom { get; set; }

        public string Nom_Prenom
            {
            get {
                return Nom + " " + Prenom;
                }
            }
        [Name("Date de naissance")] public string Date_de_naissance { get; set; }
        [Name("Age")] public string Age { get; set; }
        [Name("Informations diverses")] public string Informations_diverses{ get; set; }
        [Name("Secteur d'activité")] public string Secteur_activite{ get; set; }
        [Name("Adresse prioritaire")] public string Adresse_prioritaire{ get; set; }
        [Name("Ets")] public string Ets { get; set; }
        [Name("adresse_prio")] public string Adresse_prio { get; set; }
        [Name("adresse1_prio")] public string Adresse1_prio { get; set; }
        [Name("cp_prio")] public string Cp_prio { get; set; }
        [Name("ville_prio")] public string Ville_prio { get; set; }
        [Name("Tél perso")] public string Tel_perso{ get; set; }
        [Name("Tél pro")] public string Tel_pro{ get; set; }
        [Name("tel portable")] public string Tel_portable{ get; set; }
        [Name("mail")] public string Mail { get; set; }
        [Name("Adresse_nonprio")] public string Adresse_nonprio { get; set; }
        [Name("Ets_non prio")] public string Ets_non_prio{ get; set; }
        [Name("adresse_non prio")] public string Adresse_non_prio{ get; set; }
        [Name("adresse 1_non prio")] public string Adresse1_non_prio { get; set; }
        [Name("cp_non prio")] public string Cp_non_prio{ get; set; }
        [Name("ville_non prio")] public string Ville_non_prio{ get; set; }
        [Name("Region")] public string Region { get; set; }
        [Name("mail_non prio")] public string Mail_non_prio{ get; set; }


        public static List<BDMembreJury> loadFrom(String pFile)
        {
            List<BDMembreJury> olstReturn = new List<BDMembreJury>();
            using (var reader = new StreamReader(pFile, Encoding.GetEncoding(1252)))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    //csv.Configuration.RegisterClassMap<BDMembreJuryMap>();
                    csv.Configuration.Delimiter = ";";
                    //csv.Configuration.HeaderValidated=null;
                    //csv.Configuration.MissingFieldFound = null;
                    //                csv.Configuration.BadDataFound = null;
                    olstReturn = csv.GetRecords<BDMembreJury>().ToList();

                }
            }
            return olstReturn; 
        }

    }//BDMembreJury

    }//NameSpace
