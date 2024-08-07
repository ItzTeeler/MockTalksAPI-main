using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using MockTalksAPI.Models;
using MockTalksAPI.Models.DTO;
using MockTalksAPI.Services.Context;

namespace MockTalksAPI.Services
{
    public class MT_UserService : ControllerBase
    {
        private readonly DataContext _context;

        public MT_UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string Username)
        {
            return _context.MT_UserInfo.SingleOrDefault(user => user.Username == Username) != null;
        }

        public bool AddUser(MT_CreateAccountDTO UserToAdd)
        {
            bool result = false;

            if (!DoesUserExist(UserToAdd.Username))
            {
                MT_UserModels newUser = new MT_UserModels();

                var hashPassword = HashPassword(UserToAdd.Password);

                newUser.ID = UserToAdd.ID;
                newUser.Username = UserToAdd.Username;
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;

                _context.Add(newUser);

                result = _context.SaveChanges() != 0;
            }

            return result;
        }

        public MT_PasswordDTO HashPassword(string password)
        {
            MT_PasswordDTO newHashPassword = new MT_PasswordDTO();

            byte[] SaltByte = new byte[64];

            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

            provider.GetNonZeroBytes(SaltByte);

            string salt = Convert.ToBase64String(SaltByte);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);

            string hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashPassword.Salt = salt;
            newHashPassword.Hash = hash;

            return newHashPassword;
        }

        public bool VerifyUsersPassword(string? password, string? storedHash, string? storedSalt)
        {
            byte[] SaltBytes = Convert.FromBase64String(storedSalt);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);

            string newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return newHash == storedHash;
        }

        public IActionResult Login(MT_LoginDTO User)
        {
            IActionResult Result = Unauthorized();

            if (DoesUserExist(User.Username))
            {
                MT_UserModels foundUser = GetUserByUsername(User.Username);

                if (VerifyUsersPassword(User.Password, foundUser.Hash, foundUser.Salt))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(), // Claims can be added here if needed
                        expires: DateTime.Now.AddMinutes(30), // Set token expiration time (e.g., 30 minutes)
                        signingCredentials: signinCredentials // Set signing credentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                    Result = Ok(new { Token = tokenString });
                }
            }
            return Result;
        }

        public MT_UserModels GetUserByUsername(string username)
        {
            return _context.MT_UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public bool UpdateUserPassword(string username, string newPassword)
        {
            MT_UserModels foundUser = _context.MT_UserInfo.SingleOrDefault(user => user.Username == username); ;

            var hashPassword = HashPassword(newPassword);

            foundUser.Salt = hashPassword.Salt;
            foundUser.Hash = hashPassword.Hash;

            _context.Update<MT_UserModels>(foundUser);
            return _context.SaveChanges() != 0;
        }

        public MT_UserModels GetUserById(int id)
        {
            return _context.MT_UserInfo.SingleOrDefault(user => user.ID == id);
        }

        // public bool UpdateUsername(int id, string username)
        // {
        //     MT_UserModels foundUser = GetUserById(id);

        //     bool result = false;

        //     if (foundUser != null)
        //     {
        //         foundUser.Username = username;
        //         _context.Update<MT_UserModels>(foundUser);
        //         result = _context.SaveChanges() != 0;
        //     }

        //     return result;
        // }

        // public bool DeleteUser(string userToDelete)
        // {
        //     MT_UserModels foundUser = GetUserByUsername(userToDelete);

        //     bool result = false;

        //     if (foundUser != null)
        //     {
        //         _context.Remove<MT_UserModels>(foundUser);
        //         result = _context.SaveChanges() != 0;
        //     }
        //     return result;
        // }

        // public MT_UserIdDTO GetUserIdDTOByUsername(string username)
        // {
        //     MT_UserIdDTO MT_UserInfo = new MT_UserIdDTO();

        //     MT_UserModels foundUser = _context.MT_UserInfo.SingleOrDefault(user => user.Username == username);

        //     MT_UserInfo.UserId = foundUser.ID;
        //     MT_UserInfo.PublicName = foundUser.Username;

        //     return MT_UserInfo;
        // }
    }
}