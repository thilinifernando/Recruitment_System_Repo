
using RecruitmentSystem.Data;
using RecruitmentSystem.Data.Repositories;
using RecruitmentSystem.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RecruitmentSysteam.API.Controllers
{
    public class JobsController : ApiController
    {


        IJobsRepository _repository;

        public JobsController()
        {
            _repository = new JobsRepository();
        }

        public IHttpActionResult Post([FromBody]CreateJobRequestDto request)
        {
            try
            {
                Job stud = new Job() { JobTitle = request.JobTitle, Create_User_ID = 1, CreateDate = DateTime.Now };

                InterviewStage dis1 = new InterviewStage() { Title = "Interview 1", Type = " IQ And General Kowdledge " };
                InterviewStage dis2 = new InterviewStage() { Title = "Interview 2", Type = " Technical And HR " };

                stud.InterviewStages = new List<InterviewStage>();

                stud.InterviewStages.Add(dis1);
                stud.InterviewStages.Add(dis2);

                _repository.CreateJob(stud);

                // _repository.AddInterviewStageDefult(dis);

                var x = stud.JobID;

                return Ok(x);
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }

        }

        public IEnumerable<CreateJobResponseDto> Get()
        {


            return
                _repository.GetIDDetails().Select(t => new CreateJobResponseDto { JobID = t.JobID, JobTitle = t.JobTitle , CreateDate = t.CreateDate });

                //_repository.GetIDDetails().Select(t => new CreateJobResponseDto { JobID = t.JobID, JobTitle = t.JobTitle, CreateDate = t.CreateDate });

        }



        

    }
}
