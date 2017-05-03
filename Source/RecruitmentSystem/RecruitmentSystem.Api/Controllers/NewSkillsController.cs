using RecruitmentSystem.Data;
using RecruitmentSystem.Data.Repositories;
using RecruitmentSystem.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RecruitmentSystem.API.Controllers
{
    public class NewSkillsController : ApiController
    {
        // GET: NewSkills
        private RecruitmentSystemDbContext db = new RecruitmentSystemDbContext();

        INewSkillsRepository _repository;

        public NewSkillsController()
        {
            _repository = new NewSkillsRepository();

        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
         public IEnumerable <AddNewSkillResponse> Get ()
        {

            return

                 _repository.GetIDDetails().Select(t => new AddNewSkillResponse {NewSkillType = t.NewSkillType, Description = t.Description, Qualification = t.Qualification
                 });
        }
    }
}