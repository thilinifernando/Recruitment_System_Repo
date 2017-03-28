
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
       
        public CreateJobResponseDto Post ([FromBody]CreateJobRequestDto request)
        {
            Job stud = new Job() { JobID = request.JobID, JobTitle = request.JobTitle, Create_User_ID = request.Create_User_ID, CreateDate = DateTime.Today };
            _repository.CreateJob(stud);

            return new CreateJobResponseDto();
        }

        public IEnumerable<JobDto> Get()
        { 

             
            return
                _repository.GetAll().Select(t=>new JobDto { JobID = t.JobID, CreateDate = t.CreateDate, JobTitle = t.JobTitle});
        }
    }
}
