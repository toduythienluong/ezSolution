//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
//using System.Text.RegularExpressions;
//using static System.Collections.Specialized.BitVector32;
//using System.Data;
//using System.Data.Common;
//using Microsoft.AspNetCore.Http;
//using ezApiStrategy.Message;

//namespace EZT.API.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class SecurityController : ControllerBase
//{
//    [HttpPost]
//    [Route("user/authentication")]
//    public LoginResponse Login([FromBody] LoginRequest request)
//    {
//        return new LoginResponse();
//    }

//    [HttpPost]
//    [Route("user/registration")]
//    public RegisterResponse Register([FromBody] RegisterRequest request)
//    {
//        return new RegisterResponse();
//    }

//    [HttpPost]
//    [Route("user/password-recovery")]
//    public ForgotpasswordResponse Forgotpassword([FromBody] ForgotpasswordRequest request)
//    {
//        return new ForgotpasswordResponse();
//    }

//    [HttpGet]
//    [Route("users")]
//    public IList<User> GetUsers()
//    {
//        return new List<User>() {
//            new User()
//        };
//    }

//    [HttpGet]
//    [Route("users/{user-id}")]
//    public User GetUser([FromRoute] string userId)
//    {
//        return new User();
//    }

//    [HttpPost]
//    [Route("users/{user-id}/password")]
//    public IActionResult UpdateUserPassord([FromBody] UpdatePasswordRequest request)
//    {
//        return Ok();
//    }

//    [HttpPut]
//    [Route("users")]
//    public User UpdateUserInformation([FromBody] User user)
//    {
//        return new User();
//    }

//    [HttpGet]
//    [Route("user/username-recovery")]
//    public IList<TaxFiler> SearchUserByRecoverySetup([FromQuery] string question1, [FromQuery] string answer1, [FromQuery] string question2, [FromQuery] string answer2, [FromQuery] string question3, [FromQuery] string answer3)
//    {
//        return new List<TaxFiler> { new TaxFiler() };
//    }
//}

//public class UpdatePasswordRequest
//{
//    public string UserName { get; set; }
//    public string OldPassword { get; set; }
//    public string NewPassword { get; set; }
//    public string NewPasswordConfirmed { get; set; }
//}

//public class ForgotpasswordResponse
//{

//}

//public class ForgotpasswordRequest
//{
//    public string UserName { get; set; }
//}
//public class RegisterRequest
//{
//    public string UserName { get; set; }
//}

//public class RegisterResponse
//{

//}

//public class LoginRequest
//{
//    public string UserName { get; set; }
//    public string Password { get; set; }

//}

//public class LoginResponse
//{
//    public string access_token { get; set; }
//}