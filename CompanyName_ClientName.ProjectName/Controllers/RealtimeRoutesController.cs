using CompanyName_ClientName.ProjectName.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyName_ClientName.ProjectName.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtimeRoutesController : ControllerBase
    {
        #region FromRoute AttributeUsage
        //api method usage
        //Usage1:    //  [HttpGet("Sip-details/{SipId}/{SiphealthCheckType}")]
        //Usage2:
        //Usage1 and usage2 both are same.Usage1 is shortcutway of writing the routes.
        [HttpGet]
        [Route("Sip-details/{SipId}/{SiphealthCheckType}")]
        public async Task<IActionResult> Details([FromRoute]string SipId, [FromRoute]string SiphealthCheckType)
        {
            var Id = SipId;
            var checkType = SiphealthCheckType;

            return Ok(Id+'-'+ checkType);
        }
        [HttpGet]
        [Route("Sip-details/{SipId}/{SiphealthCheckType}/{a}/{b}/{c}")]
        public async Task<IActionResult> EmployeeDetails([FromRoute] string SipId, [FromRoute] string SiphealthCheckType, [FromRoute] string a, [FromRoute] string b, [FromRoute] string c)
        {
            var Id = SipId;
            var checkType = SiphealthCheckType;

            return Ok(Id + '-' + checkType+'-'+a+'-'+b+'-'+'-'+c);
        }
        [HttpGet(Name = "GetEmployeesQueryString")]
        public string GetData([FromQuery] string a, [FromQuery] string b, [FromQuery] string c, [FromQuery] string d, [FromQuery] string e)
        {
            return a + b + c + d + e;

        }
            [HttpGet("Sip-comment/{SiphealthCheckDetailId}")]
        public async Task<IActionResult> SipComment([FromRoute]long SiphealthCheckDetailId)
        {
            var checkType = SiphealthCheckDetailId;
            return Ok(checkType);
        }
        /// <returns></returns>
        [HttpGet("Sip-QuestionResponse/healthCheckDetailId/{SiphealthCheckDetailId}/healthCheckType/{SiphealthCheckType}/folderId/{SipfolderId}")]
        public async Task<IActionResult> SipQuestionResponse([FromRoute] int SiphealthCheckDetailId, [FromRoute] string SiphealthCheckType, string SipfolderId)
        {
            return Ok(SiphealthCheckDetailId+' '+ SiphealthCheckType+' '+ SipfolderId);
        }

        [HttpGet("SipEngagementSelection/healthCheckDetailId/{healthCheckDetailId}/questionId/{questionId}")]
        public async Task<IActionResult> SipGet([FromRoute] int healthCheckDetailId, [FromRoute] int questionId)
        {

            return Ok(healthCheckDetailId + ' ' + questionId);

        }

        #endregion


        #region FromQuery AttributeUsage
        //Querystring means route starts with ?(question mark firsttimeonly)
        // Route: GET /api/RealtimeRoutes/search?name=Phone&category=Electronics
        [HttpGet("SearchProducts1")]
        public IActionResult SearchProducts1([FromQuery] string name,[FromQuery] string category)
        {
            //the below one is the string concadination
            return Ok($"Searching for {name} in {category} category.");
        }
        // Route: GET /api/RealtimeRoutes/search?name=Phone
        [HttpGet("SearchProducts2")]
        public IActionResult SearchProducts2([FromQuery] string name)
        {
            //the below one is the string concadination
            return Ok($"Searching for {name}.");
        }
        //Example: Combining [FromRoute] and [FromQuery]
        // Route: http://localhost:5228/api/RealtimeRoutes/123?status=pen
        [HttpGet("{orderId:int}")]
        public IActionResult GetOrderDetails(
            [FromRoute] int orderId,
            [FromQuery] string status)
        {
            return Ok($"Order ID: {orderId}, Status: {status}");
        }

        //Complex binding with [FromQuery]
        // Route: http://localhost:5228/api/RealtimeRoutes/filter?Name=hyd&Category=book&MinPrice=10&MaxPrice=20
        [HttpGet("filter")]
        public IActionResult FilterProducts([FromQuery] ProductFilter filter)
        {
            return Ok($"Filtering {filter.Name} with min price {filter.MinPrice}.");
        }
        #endregion


    }
}