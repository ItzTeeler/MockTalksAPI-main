using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockTalksAPI.Models;
using MockTalksAPI.Services.Context;

namespace MockTalksAPI.Services
{
    public class MT_MessagingService
    {
        private readonly DataContext _context;

        public MT_MessagingService(DataContext context)
        {
            _context = context;
        }

        public bool AddMessage(MT_MessagingModals newMessage)
        {
            _context.Add(newMessage);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<MT_MessagingModals> GetMessagesByUserIds(string userId, string chatterId)
        {
            return _context.MT_MessagingInfo.Where(item => item.SenderID == int.Parse(userId) && item.ReceiverID == int.Parse(chatterId) || item.SenderID == int.Parse(chatterId) && item.ReceiverID == int.Parse(userId));
        }

        public bool DeleteMessage(MT_MessagingModals messageToDelete)
        {
            messageToDelete.IsDeleted = true;
            _context.Update<MT_MessagingModals>(messageToDelete);
            return _context.SaveChanges() != 0;
        }

        // public bool PermDeleteMessage(MT_MessagingModals messageToDelete)
        // {
        //     _context.Remove<MT_MessagingModals>(messageToDelete);
        //     return _context.SaveChanges() != 0;
        // }

        public IEnumerable<MT_MessagingModals> GetAllMessages()
        {
            return _context.MT_MessagingInfo;
        }
    }
}