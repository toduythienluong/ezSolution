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
//public class SmsOtpController : ControllerBase
//{

//    [HttpPost]
//    [Route("")]
//    public IActionResult SendSmsMessage([FromBody] SmsOtpMessage message)
//    {
//        return Ok(new SmsOtpMessage());
//    }

//    [HttpPost]
//    [Route("Matching")]
//    public IActionResult StartTaxReturn([FromBody] SmsOtpMessage request)
//    {
//        return Ok(true);
//    }
//}