using System.Collections.Generic;

namespace xf_v5.Models
{
    public class CorsOptions
    {
        public string[] AllowedHosts { get; set; }
    }
    public class XForwardedOptions
    {
        public bool Enabled { get; set; }
        public int ForwardLimit { get; set; }
    }

    public class ConnectionInfo
    {
        public string LocalIpAddress { get; set; }
        public int LocalPort { get; set; }
        public string RemoteIpAddress { get; set; }
        public int RemotePort { get; set; }
        public string RequestHost { get; set; }
        public string RequestScheme { get; set; }
        public Dictionary<string, string> HeaderData { get; set; }
        public Dictionary<string, string> QueryData { get; set; }
        public Dictionary<string, string> FormData { get; set; }
    }
}
