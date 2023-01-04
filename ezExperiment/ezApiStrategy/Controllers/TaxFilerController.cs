using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;
using System.Data;
//using System.Data.Common;
//using Microsoft.AspNetCore.Http;
//using ezApiStrategy.Message;

//namespace EZT.API.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class TaxFilerController : ControllerBase
//{
//    [HttpPost]
//    [Route("")]
//    public TaxFiler CreateRecoverySetupForCustomer([FromBody] TaxFiler customer)
//    {
//        return new TaxFiler();
//    }

//    [HttpPost]
//    [Route("{taxFilerId}/RecoverySetup")]
//    public RecoverySetup CreateRecoverySetupForCustomer([FromRoute] int taxFilerId, [FromBody] RecoverySetup request)
//    {
//        return new RecoverySetup();
//    }

//    [HttpGet]
//    [Route("")]
//    public IList<TaxFiler> SearchCustomerByRecoverySetup([FromQuery] string question1, [FromQuery] string answer1, [FromQuery] string question2, [FromQuery] string answer2, [FromQuery] string question3, [FromQuery] string answer3)
//    {
//        return new List<TaxFiler> { new TaxFiler() };
//    }
//}