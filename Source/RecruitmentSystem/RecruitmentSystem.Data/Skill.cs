using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data
{
    public class Skill
    {
        public int SkillID { get; set; }
        public String SkillType { get; set; }


        //Foreign key
        public int JobId { get; set; }
        public virtual Job Job { get; set; }


        public string Description { get; set; }

        public string Qualification { get; set; }

        public int Parent_ID { get; set; }






    }
}
