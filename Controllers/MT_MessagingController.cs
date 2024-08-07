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
    public class MT_MessagingController : ControllerBase
    {
        private readonly MT_MessagingService _data;

        public MT_MessagingController(MT_MessagingService data)
        {
            _data = data;
        }

        [HttpPost]
        [Route("AddMessage")]
        public bool AddMessage(MT_MessagingModals newMessage)
        {
            return _data.AddMessage(newMessage);
        }

        [HttpGet]
        [Route("GetAllMessages")]
        public IEnumerable<MT_MessagingModals> GetAllMessages()
        {
            return _data.GetAllMessages();
        }

        [HttpGet]
        [Route("GetMessagesByUserIds/{userId}/{chatterId}")]
        public IEnumerable<MT_MessagingModals> GetMessagesByUserIds(string userId, string chatterId)
        {
            return _data.GetMessagesByUserIds(userId, chatterId);
        }

        [HttpDelete]
        [Route("DeleteMessage")]
        public bool DeleteMessage(MT_MessagingModals blogToDelete)
        {
            return _data.DeleteMessage(blogToDelete);
        }
    }
}