using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        public SkillsRepository()
        {

        }

        public IEnumerable<Skill> GetIDDetails()
        {

            var ctx = new RecruitmentSystemDbContext();
            return ctx.Skills.ToList();

        }

    }
}
