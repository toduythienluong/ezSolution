using Microsoft.AspNetCore.Mvc;
using EZT.API.Message;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using EZT.Model;
using System.Data.Common;
using EZT.Data.Service;
using Microsoft.AspNetCore.Http;

namespace EZT.API.Controllers;

[ApiController]
[Route("[controller]")]
public class Securityontroller : ControllerBase
{


    public Securityontroller()
    {

    }

    [HttpPost]
    [Route("login")]
    public LoginResponse Login([FromBody] LoginRequest formDef)
    {
        return new LoginResponse();
    }

}

public class LoginRequest
{
}

public class LoginResponse
{
}