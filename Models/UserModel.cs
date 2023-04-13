using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendfoodapi.Models
{
    public class UserModel
    {
        public int Id  {get; set;}
        public string? Salt {get; set;}
        public string? Hash {get; set;}
        public string? Username { get; set; }
        // public string? UserName { get; internal set; } not sure what this is

        public UserModel(){}

    }
}