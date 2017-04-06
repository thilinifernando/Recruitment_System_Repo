using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentSystem.Data;


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

        public IEnumerable<Job> GetIDDetails()
        {

            var ctx = new RecruitmentSystemDbContext();
            return ctx.Jobs.ToList();

        }

        public InterviewStage AddInterviewStageDefult(InterviewStage dis)
        {
            using (var ctx = new RecruitmentSystemDbContext())
            {
                InterviewStage s = ctx.InterviewStages.Add(dis);
                ctx.SaveChanges();
                return s;

            }
        }


    }
}
