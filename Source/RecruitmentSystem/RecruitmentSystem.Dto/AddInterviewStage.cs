using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Dto
{
     public class AddInterviewStage
    {
        public int Id { get; set; }
        public string Title { get; set; }  // interview 1, interview 2
        public string Type { get; set; } // hr, technical, oral
        public int Job_JobID { get; set; }

    }
}
