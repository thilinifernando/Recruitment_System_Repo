using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data.Repositories
{
   public class NewSkillsRepository : INewSkillsRepository
    {
        public NewSkillsRepository()
        {


        }
        public IEnumerable<NewSkill> GetIDDetails()
        {

            var ctx = new RecruitmentSystemDbContext();
            return ctx.NewSkills.ToList();

        }
    }
}
