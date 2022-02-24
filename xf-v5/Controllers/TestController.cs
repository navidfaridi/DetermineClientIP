using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using xf_v5.Models;

namespace xf_v5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetClientIp()//[FromHeader(Name = "X-Forwarded-For")] string xf )
        {
            var connectionInfo = new Models.ConnectionInfo
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
                connectionInfo.HeaderData.Add(new StringKeyValue()
                {
                    Key = k,
                    Value = HttpContext.Request.Headers[k]
                });
            //connectionInfo.HeaderData.Add(new StringKeyValue() { Key = "xf", Value = xf });
            return Ok(connectionInfo);
        }
    }
}
