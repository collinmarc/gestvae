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
    public class BDPays
    {
        [Name("COG")] public string COG { get; set; }
        [Name("ACTUAL")] public string Actual { get; set; }
        [Name("CAPAY")] public string CAPAY { get; set; }
        [Name("CRPAY")] public string CRPAY { get; set; }
        [Name("ANI")] public string ANI { get; set; }
        [Name("LIBCOG")] public string LIBCOG { get; set; }
        [Name("LIBENR")] public string LIBENR { get; set; }
        [Name("ANCNOM")] public string ANCNOM { get; set; }
        [Name("CODEISO2")] public string CODEISO2 { get; set; }
        [Name("CODEISO3")] public string CODEISO3 { get; set; }
        [Name("CODENUM3")] public string CODENUM3 { get; set; }


        public static List<BDPays> loadFrom(String pFile)
        {
            List<BDPays> olstReturn = new List<BDPays>();
            using (var reader = new StreamReader(pFile, Encoding.GetEncoding(1252)))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    //csv.Configuration.RegisterClassMap<BDPaysMap>();
                    csv.Configuration.Delimiter = ",";
                    //csv.Configuration.HeaderValidated=null;
                    //csv.Configuration.MissingFieldFound = null;
                    //                csv.Configuration.BadDataFound = null;
                    // ON FILTRE SUR LE CODE ACTUAL = 1 pour ne prendre que les pays
                    olstReturn = csv.GetRecords<BDPays>().Where(p => p.Actual.Equals("1")).ToList();

                }
            }
            return olstReturn; 
        }

        public bool IsPaysFrance {
            get
            {
                return LIBCOG.Equals("FRANCE");
            }
        }
    }//BDPAYS

    }//NameSpace
