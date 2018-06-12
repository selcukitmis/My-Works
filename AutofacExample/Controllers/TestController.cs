using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutofacExample.Services;

namespace AutofacExample.Controllers
{
    public class TestController : ApiController
    {
        private readonly TestService _testService;

        public TestController(TestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("ping")]
        public async Task<HttpResponseMessage> GetPing()
        {
            var ping = await _testService.GetPing();
            return Request.CreateResponse(HttpStatusCode.OK, ping);
        }
    }
}
