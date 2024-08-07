using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockTalksAPI.Models.DTO
{
    public class MT_PasswordDTO
    {
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}