using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data.Repositories
{
    public class JobsRepository : IJobsRepository
    {

        public JobsRepository()
        {

        }

        public void CreateJob(Job stud)
        {
            using (var ctx = new RecruitmentSystemDbContext())
            {
                ctx.Jobs.Add(stud);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Job> GetAll()
        {

            var ctx = new RecruitmentSystemDbContext();
            return ctx.Jobs.ToList();
            
        }
    }
}
