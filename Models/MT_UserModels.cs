using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockTalksAPI.Models
{
    public class MT_UserModels
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }

        public MT_UserModels()
        {

        }
    }
}