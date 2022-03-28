using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Universidad.Models
{
    public class AppSettings
    {
        public Url url { get; set; }

    }

    public class Url
    {

        [JsonPropertyName("SaveUser")]
        public string SaveUser { get; set; }

        [JsonPropertyName("getUser")]
        public string GetUser { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("verifyCode")]
        public string VerifyCode { get; set; }
    }

}
