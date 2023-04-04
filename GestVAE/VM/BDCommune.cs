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
    public class BDCommune
    {
        [Name("code_commune_insee")]
        public string code_commune_insee { get; set; }

        [Name("nom_de_la_commune")]
        public string nom_commune { get; set; }
        [Name("code_postal")]
        public string code_postal { get; set; }
        [Name("ligne_5")] public string ligne5 { get; set; }
        [Name("libelle_d_acheminement")] public string libelleAcheminement{ get; set; }
        [Name("coordonnees_gps")] public string coordonnees_gps { get; set; }
  

        public static List<BDCommune> loadFrom(String pFile)
        {
            List<BDCommune> olstReturn = new List<BDCommune>();
            using (var reader = new StreamReader(pFile, Encoding.GetEncoding(1252)))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    //csv.Configuration.RegisterClassMap<BDMembreJuryMap>();
                    csv.Configuration.Delimiter = ";";
                    //csv.Configuration.HeaderValidated=null;
                    //csv.Configuration.MissingFieldFound = null;
                    //                csv.Configuration.BadDataFound = null;
                    olstReturn = csv.GetRecords<BDCommune>().ToList();

                }
            }
            return olstReturn; 
        }

    }//BDCommune

    }//NameSpace
