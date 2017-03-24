 using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_Systeam.Data
{
    class Createjob_DbContext:DbContext
    {

        public DbSet <Job> jobs { get; set; }

    }
}
