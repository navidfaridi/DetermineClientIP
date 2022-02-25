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
            
            connectionInfo.HeaderData = new Dictionary<string, string>();
            foreach (var k in HttpContext.Request.Headers.Keys)
            {
                var v = HttpContext.Request.Headers[k];
                connectionInfo.HeaderData.Add(k, v);              
            }
            
            return Ok(connectionInfo);
        }
    }
}
