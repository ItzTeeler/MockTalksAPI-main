using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockTalksAPI.Models
{
    public class MT_ProfileModels
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public string ExperienceLevel { get; set; }
        public string JobInterviewLevel { get; set; }
        public string Locationed { get; set; }
        public string ProfileImg { get; set; }

        public MT_ProfileModels()
        {

        }
    }
}