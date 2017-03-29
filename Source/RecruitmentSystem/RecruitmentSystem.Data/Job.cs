using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data
{
    public class Job
    {
       
        public int JobID { get; set; }

        public String JobTitle { get; set; }
        public int Create_User_ID { get; set; }
        public DateTime CreateDate { get; set; }

        public String  ReferenceID { get; set; }

        public List<InterviewStage> InterviewStages { get; set; }

        public List<Skill> Skills { get; set; } //advertised Skills
    }

}
