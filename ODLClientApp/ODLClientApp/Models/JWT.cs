using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ODLClientApp.Models
{
    public class JWT
    {
            [JsonProperty("token")]
            public string Token { get; set; }
        }
    
}
