﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestVAEcls
{
    public class GestVAE
    {
        public int ID { get; set; }
        public DateTime dateCreation { get; set; }
        public DateTime dateModif { get; set; }
        public Boolean bDeleted { get; set; }

        public GestVAE()
        {
            bDeleted = false;
            dateCreation = DateTime.Now;
            dateModif = dateCreation;
        }
    }
}