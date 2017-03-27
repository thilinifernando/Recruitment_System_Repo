
using RecruitmentSystem.Data;
using RecruitmentSystem.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecruitmentSysteam.API.Controllers
{
    public class JobsController : ApiController
    {
        [HttpPost]
        public CreateJobResponseDto CreateJob([FromBody]CreateJobRequestDto request)
        {

            using (var ctx = new RecruitmentSystemDbContext())
            {
                Job  stud = new Job () {JobID = request.JobID ,  JobTitle= request.JobTitle ,Create_User_ID = request.Create_User_ID   ,CreateDate= DateTime.Today };

                ctx.Jobs.Add(stud);
                ctx.SaveChanges();
            }

            return new CreateJobResponseDto();
        }

        //[HttpGet]
        //public List<JobDto> GetAllJobs()
        //{
        //    return new List<JobDto> { new JobDto { Name = "jobname", Id = 1 }, new JobDto { Name = "jobname", Id = 2 } };
        //}
    }
}
