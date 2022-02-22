using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WA_XForward_Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClientIp()
        {
            var connectionInfo = new ConnectionInfo
            {
                LocalIpAddress = HttpContext.Connection.LocalIpAddress.ToString(),
                LocalPort = HttpContext.Connection.LocalPort,
                RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                RemotePort = HttpContext.Connection.RemotePort,
                RequestHost = HttpContext.Request.Host.ToString(),
                RequestScheme = HttpContext.Request.Scheme
            };
            connectionInfo.HeaderData = new List<StringKeyValue>();
            foreach (var k in HttpContext.Request.Headers.Keys)
                connectionInfo.HeaderData.Add(new StringKeyValue() { Key = k, Value = HttpContext.Request.Headers[k] }); 
            return Ok(connectionInfo);
        }
    }
}
