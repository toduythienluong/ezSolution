using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Http;
using ezApiStrategy.Message;

namespace EZT.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxReturnController : ControllerBase
{
    [HttpPost]
    [Route("")]
    public StartTaxReturnResponse StartTaxReturn([FromRoute] int userId, [FromBody] StartTaxReturnRequest request)
    {
        return new StartTaxReturnResponse();
    }

    [HttpGet]
    [Route("{taxReturnId}")]
    public TaxReturn GetTaxReturn(int taxReturnId)
    {
        return new TaxReturn();
    }

    [HttpPost]
    [Route("clone")]
    public CloneTaxReturnResponse CloneTaxReturn([FromRoute] int taxReturnIdToClone)
    {
        return new CloneTaxReturnResponse();
    }

    [HttpPost]
    [Route("TurboTaxFile")]
    public TurboTaxDataFile UploadTurboTaxReturnFile(IFormFile file)
    {
        return new TurboTaxDataFile();
    }


    [HttpPost]
    [Route("{taxReturnIdToClone}/clone/{turboTaxFileDataId}")]
    public CloneTaxReturnResponse CloneTaxReturnFromTurboTax([FromRoute] int taxReturnIdToClone, [FromBody] CloneTaxReturnRequest request)
    {
        return new CloneTaxReturnResponse();
    }
}