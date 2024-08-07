using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockTalksAPI.Models;
using MockTalksAPI.Services.Context;

namespace MockTalksAPI.Services
{
    public class MT_ScheduleService
    {
        private readonly DataContext _context;

        public MT_ScheduleService(DataContext context)
        {
            _context = context;
        }

        public bool CreateScheduledMeeting(MT_ScheduleModals newMeeting)
        {
            _context.Add(newMeeting);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<MT_ScheduleModals> GetMeetingsByUserId(int userId)
        {
            return _context.MT_ScheduleInfo.Where(item => item.UserID == userId && item.IsDeleted == false);
        }

        public bool DeleteMeeting(MT_ScheduleModals meetingToDelete)
        {
            meetingToDelete.IsDeleted = true;
            meetingToDelete.IsPartnered = false;
            meetingToDelete.PartnerID = 0;
            _context.Update<MT_ScheduleModals>(meetingToDelete);
            return _context.SaveChanges() != 0;
        }

        // update schedule meeting
        // get all meetings
        // get singular meeting

        public bool UpdateScheduleTime(MT_ScheduleModals meetingToUpdate)
        {
            _context.Update<MT_ScheduleModals>(meetingToUpdate);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<MT_ScheduleModals> GetAllMeetings()
        {
            return _context.MT_ScheduleInfo;
        }

        public MT_ScheduleModals GetMeetingById(int id)
        {
            return _context.MT_ScheduleInfo.SingleOrDefault(item => item.ID == id);
        }
    }
}