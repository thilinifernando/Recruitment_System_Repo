using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitmentSystem.Dto
{
    public class CreateJobRequestDto
    {
       
        public String JobTitle { get; set; }
        public int Create_User_ID { get; set; }
        public DateTime CreateDate { get; set; }
    }
} 