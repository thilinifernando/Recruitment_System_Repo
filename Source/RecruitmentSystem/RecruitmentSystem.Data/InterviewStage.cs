using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data
{
    public class InterviewStage
    {
        public int Id { get; set; }

        public string Title { get; set; }  // interview 1, interview 2

        public string Type { get; set; } // hr, technical, oral

        public List<Skill> Skills { get; set; } // stage specific skills

        //public List<Job> Jobs { get; set; }

        public List<Interviewer> Interviewers { get; set; }
    }
}


