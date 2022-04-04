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

        [JsonPropertyName("Country")]
        public string Country { get; set; }

        [JsonPropertyName("Gender")]
        public string Gender { get; set; }

        [JsonPropertyName("Position")]
        public string Position { get; set; }

        [JsonPropertyName("TypeAirplane")]
        public string TypeAirplane { get; set; }

        [JsonPropertyName("Person")]
        public string Person { get; set; }

        [JsonPropertyName("Crew")]
        public string Crew { get; set; }

        [JsonPropertyName("CrewPerson")]
        public string CrewPerson { get; set; }

        [JsonPropertyName("Flight")]
        public string Flight { get; set; }

        [JsonPropertyName("Airplane")]
        public string Airplane { get; set; }

        [JsonPropertyName("Luggage")]
        public string Luggage { get; set; }

        [JsonPropertyName("Ticket")]
        public string Ticket { get; set; }

    }

}
