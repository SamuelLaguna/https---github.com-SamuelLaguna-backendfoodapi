using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendfoodapi.Models;
using backendfoodapi.Models.DTO;
using backendfoodapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendfoodapi.Controllers {


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _data;
    public UserController(UserService dataFromService){
        _data = dataFromService;
        
    }


    [HttpPost]
    [Route("AddUser")]
    public bool AddUser(CreateAccountDTO UserToAdd)
    {
        return _data.AddUser(UserToAdd);
    }
    

    [HttpPost]
    [Route("UpdateUser")]
    public bool UpdateUser(UserModel userToUpdate){
        return _data.UpdateUser(userToUpdate);
    }

    [HttpPost]
    [Route("UpdateUser/{id}/{username}")]
    public bool UpdateUser(int id, string username){
      return _data.UpdateUsername(id, username);


    }

    [HttpDelete]
    [Route("DeleteUser/{userToDelete}")]
    public bool DeleteUser(string userToDelete){
        return _data.DeleteUser(userToDelete);
        
    }

}
    
    
}
