using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data
{
    public class Comment
    {
        public int ID { get; set; }

        public Interviewer CommentedBy { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentedTime { get; set; }

        public InterviewStage Stage { get; set; }

        public Candidate Candidate { get; set; }

    }
}
