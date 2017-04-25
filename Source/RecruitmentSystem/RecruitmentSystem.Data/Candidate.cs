using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data
{
    public class Candidate
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string CVPath { get; set; }

        public Job Job { get; set; }
    }
}
