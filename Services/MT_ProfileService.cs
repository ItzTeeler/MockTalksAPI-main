using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockTalksAPI.Models;
using MockTalksAPI.Services.Context;

namespace MockTalksAPI.Services
{
    public class MT_ProfileService
    {
        private readonly DataContext _context;

        public MT_ProfileService(DataContext context)
        {
            _context = context;
        }

        public bool CreateProfileItem(MT_ProfileModels newProfileItem)
        {
            _context.Add(newProfileItem);
            return _context.SaveChanges() != 0;
        }

        public MT_ProfileModels GetProfileItemByUserId(int userId)
        {
            return _context.MT_ProfileInfo.SingleOrDefault(item => item.UserID == userId);
        }

        public IEnumerable<MT_ProfileModels> GetAllProfileItems()
        {
            return _context.MT_ProfileInfo;
        }

        public bool UpdateProfileItem(MT_ProfileModels profileItemUpdate)
        {
            _context.Update<MT_ProfileModels>(profileItemUpdate);
            return _context.SaveChanges() != 0;
        }
    }
}