using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Dto
{
   public class AddSkillRequest
    {
        public int SkillID { get; set; }
        public String SkillType { get; set; }
        public int Job_JobID { get; set; }


        public string Description { get; set; }

        public string Qualification { get; set; }

        public int Parent_ID { get; set; }


    }
}
