using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendfoodapi.Models.DTO;
using backendfoodapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendfoodapi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _data;
    public UserController(UserService dataFromService){
        _data = dataFromService;
        
    }

    [HttpPost]
    [Route("Login")]
    public IActionResult Login([FromBody]LoginDTO User){
        return _data.Login(User);
    }

    public bool AddUser(CreateAccountDTO UserToAdd)
    {
        return _data.AddUser(UserToAdd);
    }
    
}
