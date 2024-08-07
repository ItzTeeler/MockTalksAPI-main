using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockTalksAPI.Models
{
    public class MT_ScheduleModals
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int PartnerID { get; set; }
        public string InterviewPractice { get; set; }
        public string TypePractice { get; set; }
        public string TypeExperience { get; set; }
        public string SelectedDate { get; set; }
        public string Timezone { get; set; }


        public string TestQuestions { get; set; }
        public string Language { get; set; }


        public bool IsPartnered { get; set; }
        public bool IsDeleted { get; set; }

        public MT_ScheduleModals()
        {

        }
    }
}