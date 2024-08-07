using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockTalksAPI.Models;
using MockTalksAPI.Models.DTO;
using MockTalksAPI.Services;

namespace MockTalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MT_UserController : ControllerBase
    {
        private readonly MT_UserService _data;

        public MT_UserController(MT_UserService data)
        {
            _data = data;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] MT_LoginDTO User)
        {
            return _data.Login(User);
        }

        [HttpPost]
        [Route("NewUser")]
        public bool AddUser(MT_CreateAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);
        }

        [HttpPut]
        [Route("UpdateUserPassword/{username}/{newPassword}")]
        public bool UpdateUserPassword(string username, string newPassword)
        {
            return _data.UpdateUserPassword(username, newPassword);
        }

        [HttpGet]
        [Route("GetUserByUserName/{username}")]
        public MT_UserModels GetUserByUsername(string username)
        {
            return _data.GetUserByUsername(username);
        }

        // Currently unnecessary
        // [HttpPut]
        // [Route("UpdateUsername/{id}/{username}")]
        // public bool UpdateUser(int id, string username)
        // {
        //     return _data.UpdateUsername(id, username);
        // }

        // Currently unnecessary
        // [HttpDelete]
        // [Route("DeleteUser/{userToDelete}")]
        // public bool DeleteUser(string userToDelete)
        // {
        //     return _data.DeleteUser(userToDelete);
        // }
    }
}