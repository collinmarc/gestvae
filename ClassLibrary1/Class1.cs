using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Context : DbContext
    {
        DbSet<obj> dbobj;
    }

    public class obj
    {
        public int ID{ get; set; }
    }
}
