using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitmentSystem.Dto
{
    public class CreateJobResponseDto
    {
        public int JobID { get; set; }
        public String JobTitle { get; set; }
        public DateTime CreateDate { get; set; }
    }
}