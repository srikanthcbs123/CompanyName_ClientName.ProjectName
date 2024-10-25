using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CompanyName_ClientName.ProjectName.Controllers
{
    [Route("api/[controller]")]//parent route declare here
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]//get api method
        [Route("Getstringdata")]//child routes define here
        public string listofdata()
        {
            var result = "It Department";
            return result;
        }
        [HttpPost]//post api method
        [Route("insertdata")]//child routes define here
        public int insertdata(int a, int b)
        {
            return a + b;
        }
        [HttpPut]//update api method
        [Route("update data")]//child routes define here
        public int updatedata(int a, int b)
        {
            return a - b;
        }
        [HttpDelete]//delete api method 
        [Route("deletedata")]//child routes define here
        public int deletedata(int a, int b)
        {
            return a - b;

        }
    }
}
