using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data.Repositories
{
  public  interface INewSkillsRepository
    {
        IEnumerable<NewSkill> GetIDDetails();
    }
}
