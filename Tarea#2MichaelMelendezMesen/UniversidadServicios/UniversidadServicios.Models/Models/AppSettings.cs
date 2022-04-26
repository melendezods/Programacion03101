using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UniversidadServicios.Models.Models
{
    public class AppSettings
    {
        [JsonPropertyName("SecretKey")]
        public string SecretKey { get; set; }

        [JsonPropertyName("EmailFrom")]
        public string EmailFrom { get; set; }
        [JsonPropertyName("PasswordEmail")]
        public string PasswordEmail { get; set; }
        [JsonPropertyName("Host")]
        public string Host { get; set; }
        [JsonPropertyName("Port")]
        public int Port { get; set; }
        [JsonPropertyName("NameEmail")]
        public string NameEmail { get; set; }
    }
}
