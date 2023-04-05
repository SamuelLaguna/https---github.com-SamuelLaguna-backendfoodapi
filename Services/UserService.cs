using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendfoodapi.Models;
using backendfoodapi.Models.DTO;
using backendfoodapi.Services.Context;
using System.Security.Cryptography;

namespace backendfoodapi.Services
{
    public class UserService
    {

        private readonly DataContext _context;
        public UserService(DataContext context){
            _context = context;
        }

        public bool DoesUserExists(string? Username){
            return _context.UserInfo.SingleOrDefault(user => user.Username == Username) !=null;

        }






        public bool AddUser(CreateAccountDTO UserToAdd){
            bool result = false;
            if(!DoesUserExists(UserToAdd.Username))
            {
                UserModel newUser = new UserModel();
                result = true;
            }

            return result;
        }


        public PasswordDTO HashPassword(string password)
        {
            PasswordDTO newHashedPasword = new PasswordDTO();

            byte[] SaltByte = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltByte);


            var Salt = Convert.ToBase64String(SaltByte);

        }
       
    }
}