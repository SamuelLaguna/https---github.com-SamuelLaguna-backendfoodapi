using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendfoodapi.Models;
using backendfoodapi.Models.DTO;
using backendfoodapi.Services.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backendfoodapi.Services
{
    public class UserService : ControllerBase
    {

        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExists(string? Username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == Username) != null;

        }






        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            bool result = false;
            if (!DoesUserExists(UserToAdd.Username))
            {
                UserModel newUser = new UserModel();
                // Create are hash and salt password
                var hashPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.id;
                newUser.UserName = UserToAdd.Username;
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;

                //Adding new user to our database 
                _context.Add(newUser);

                //This saves to our database and returns the number of entriees written in our database.
                // _context.SavedChanges();

                result = _context.SaveChanges() !=0;            
            }

            return result;
        }


        public PasswordDTO HashPassword(string? password)
        {
            PasswordDTO newHashedPasword = new PasswordDTO();

            byte[] SaltByte = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltByte);


            var Salt = Convert.ToBase64String(SaltByte);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);

            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashedPasword.Salt = Salt;
            newHashedPasword.Hash = Hash;

            return newHashedPasword;


        }

        public bool VerifyUserPassword(string? Password, string storedHash, string storedSalt)
        {
            //Get our existing salt and change it to base 64 string
            var SaltBytes = Convert.FromBase64String(storedSalt);
            // We are making the password that the user inputed and using the stored salt
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);

            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            // Checking if the new hash is the same as the stored hash
            return newHash == storedHash;

        }


        public IActionResult Login(LoginDTO User){
        //Want to return error is user does not have vallid username or password
        IActionResult Result = Unauthorized();

        if(DoesUserExists(User.Username)){
            UserModel foundUser = GetUserByUserName(User.Username);

            if(VerifyUserPassword(User.Password, foundUser.Hash, foundUser.Salt)){
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    Result = Ok(new { Token = tokenString });
            }
        }

        return Result; 
    }

    public UserModel GetUserByUserName(string username){
        return _context.UserInfo.SingleOrDefault(user => user.UserName == username);

    }
    

        public bool UpdateUser(int id, UserModel userToUpdate)
        {
            //This one is sending pver the whole object to be updated
            _context.Update<UserModel>(userToUpdate);
            return _context.SaveChanges() !=0;
        }


        public bool UpdateUsername(int id, string username){
            UserModel foundUser = GetUserById(id);
            bool result = false;
            if(foundUser != null){
                foundUser.UserName = username;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() !=0; 
            }
            return result;
        }

        public UserModel GetUserById(int id){
            return _context.UserInfo.SingleOrDefault(user => user.Id == id);

        }

        public bool DeleteUser(string userToDelete){
            UserModel foundUser = GetUserByUserName(userToDelete);
            bool result = false;
            if(foundUser != null){
                _context.Remove<UserModel>(founderUser);
                result = _context.SaveChanges() !=0;
            }
            return result;
        }

}
}