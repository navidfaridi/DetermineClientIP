using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using xf_v5.Models;

namespace xf_v5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetClientIp()
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
                connectionInfo.HeaderData.Add(k, HttpContext.Request.Headers[k]);
            
            connectionInfo.QueryData = new Dictionary<string, string>();
            foreach(var k in Request.Query.Keys)
                connectionInfo.QueryData.Add(k, Request.Query[k]);


            if (Request.HasFormContentType)
            {
                connectionInfo.FormData = new Dictionary<string, string>();
                foreach (var k in Request.Form.Keys)
                    connectionInfo.FormData.Add(k, Request.Form[k]);
            }

            return Ok(connectionInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Read()
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
                connectionInfo.HeaderData.Add(k, HttpContext.Request.Headers[k]);

            connectionInfo.QueryData = new Dictionary<string, string>();
            foreach (var k in Request.Query.Keys)
                connectionInfo.QueryData.Add(k, Request.Query[k]);

            connectionInfo.FormData = new Dictionary<string, string>();
            if (Request.HasFormContentType)
            {                
                foreach (var k in Request.Form.Keys)
                    connectionInfo.FormData.Add(k, Request.Form[k]);             
            }
            if(Request.Body != null)
            {
                var bodyStr = "";
                using (StreamReader reader
                  = new StreamReader(Request.Body, Encoding.UTF8, true, 1024, true))
                {                    
                    bodyStr =await reader.ReadToEndAsync();
                }
                connectionInfo.FormData.Add("body", @bodyStr.Replace("\r\n", "")
                    .Replace("\n", "")
                    .Replace("\r", "")                    
                    .Trim());
            }
            return Ok(connectionInfo);
        }
    }
}
