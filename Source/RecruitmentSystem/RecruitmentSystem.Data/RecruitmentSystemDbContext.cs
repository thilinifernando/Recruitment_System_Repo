using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data
{
    public class RecruitmentSystemDbContext:DbContext
    {
        public DbSet<Job> Jobs { get; set; }
    }
}
