﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace GestVAEcls
{
    public class GestVAEBase
    {
        public Int32 ID { get; set; }
        public DateTime dateCreation { get; set; }
        public DateTime dateModif { get; set; }
        public Boolean bDeleted { get; set; }
        public String AttSup { get; set; }

        public GestVAEBase()
        {
            bDeleted = false;
            dateCreation = DateTime.Now;
            dateModif = dateCreation;
            AttSup = "";
        }
    }
}
