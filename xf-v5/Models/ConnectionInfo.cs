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

    public class StringKeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class ConnectionInfo
    {
        public string LocalIpAddress { get; set; }
        public int LocalPort { get; set; }
        public string RemoteIpAddress { get; set; }
        public int RemotePort { get; set; }
        public string RequestHost { get; set; }
        public string RequestScheme { get; set; }
        public List<StringKeyValue> HeaderData { get; set; }
    }
}
