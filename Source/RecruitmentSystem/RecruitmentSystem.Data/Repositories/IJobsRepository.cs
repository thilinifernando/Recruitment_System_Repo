using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data.Repositories
{
    public interface IJobsRepository
    {
        void CreateJob(Job stud);


        IEnumerable<Job> GetIDDetails();


        InterviewStage AddInterviewStageDefult(InterviewStage dis);
    }
}
