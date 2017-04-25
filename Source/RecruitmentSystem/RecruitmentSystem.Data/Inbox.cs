using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Data
{
  public  class Inbox
    {
        public int InboxID { get; set; }

        public String EmailName { get; set; }

        public String EmailSubject { get; set; }

        public String EmailBodyText { get; set; }

        public String CvPath { get; set; }

        public DateTime ArrivalTime { get; set; }



    }
}
