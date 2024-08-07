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
    public class MT_ProfileController : ControllerBase
    {
        private readonly MT_ProfileService _data;

        public MT_ProfileController(MT_ProfileService data)
        {
            _data = data;
        }

        [HttpPost]
        [Route("CreateProfileItem")]
        public bool CreateProfileItem(MT_ProfileModels newProfileItem)
        {
            return _data.CreateProfileItem(newProfileItem);
        }

        [HttpGet]
        [Route("GetProfileItemByUserId/{id}")]
        public MT_ProfileModels GetProfileItemByUserId(int id)
        {
            return _data.GetProfileItemByUserId(id);
        }

        [HttpGet]
        [Route("GetAllProfileItems")]
        public IEnumerable<MT_ProfileModels> GetAllProfileItems()
        {
            return _data.GetAllProfileItems();
        }

        [HttpPut]
        [Route("UpdateProfileItem")]
        public bool UpdateProfileItem(MT_ProfileModels profileItemUpdate)
        {
            return _data.UpdateProfileItem(profileItemUpdate);
        }

    }
}