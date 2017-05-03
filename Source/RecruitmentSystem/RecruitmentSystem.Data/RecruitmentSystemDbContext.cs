using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data
{
    public class RecruitmentSystemDbContext:DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<InterviewStage> InterviewStages { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public DbSet<NewSkill> NewSkills { get; set; }

    }
}
