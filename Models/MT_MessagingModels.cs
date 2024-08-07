using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockTalksAPI.Models
{
    public class MT_MessagingModals
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Text { get; set; }
        public string DateSent { get; set; }
        public bool IsDeleted { get; set; }

        public MT_MessagingModals()
        {

        }
    }
}