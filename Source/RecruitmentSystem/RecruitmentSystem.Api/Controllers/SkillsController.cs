using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RecruitmentSystem.Data;
using RecruitmentSystem.Dto;
using RecruitmentSystem.Data.Repositories;

namespace RecruitmentSystem.API.Controllers
{
    public class SkillsController : ApiController
    {
        private RecruitmentSystemDbContext db = new RecruitmentSystemDbContext();
        // POST: api/Skills
        ISkillsRepository _repository;


        public SkillsController()
        {
            _repository = new SkillsRepository();
        }

        public IHttpActionResult PostSkill(AddSkillRequest skill)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          //  Skill stud = new Skill() { SkillID = request.SkillID, Create_User_ID = 1, CreateDate = DateTime.Now };

            db.Skills.Add(new Skill() { JobId = skill.Job_JobID, SkillType = skill.SkillType });
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skill.SkillID }, skill);


        }


        public IEnumerable <AddSkillResponse> Get ()
        {

            return

                 _repository.GetIDDetails().Select(t => new AddSkillResponse { SkillID = t.SkillID, SkillType = t.SkillType, Description = t.Description, Qualification = t.Qualification
                 });
        }

    }
}
