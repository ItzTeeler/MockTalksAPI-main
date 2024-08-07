using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockTalksAPI.Models;
using MockTalksAPI.Services;

namespace MockTalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MT_ScheduleController : ControllerBase
    {
        private readonly MT_ScheduleService _data;

        public MT_ScheduleController(MT_ScheduleService data)
        {
            _data = data;
        }

        [HttpPost]
        [Route("CreateScheduledMeeting")]
        public bool CreateScheduledMeeting(MT_ScheduleModals newMeeting)
        {
            return _data.CreateScheduledMeeting(newMeeting);
        }

        [HttpGet]
        [Route("GetMeetingsByUserId/{userId}")]
        public IEnumerable<MT_ScheduleModals> GetMeetingsByUserId(int userId)
        {
            return _data.GetMeetingsByUserId(userId);
        }

        [HttpPut]
        [Route("DeleteMeeting")]
        public bool DeleteMeeting(MT_ScheduleModals meetingToDelete)
        {
            return _data.DeleteMeeting(meetingToDelete);
        }

        [HttpPut]
        [Route("UpdateScheduleTime")]
        public bool UpdateScheduleTime(MT_ScheduleModals meetingToUpdate)
        {
            return _data.UpdateScheduleTime(meetingToUpdate);
        }

        [HttpGet]
        [Route("GetAllMeetings")]
        public IEnumerable<MT_ScheduleModals> GetAllMeetings()
        {
            return _data.GetAllMeetings();
        }

        [HttpGet]
        [Route("GetMeetingById/{id}")]
        public MT_ScheduleModals GetMeetingById(int id)
        {
            return _data.GetMeetingById(id);
        }
    }
}