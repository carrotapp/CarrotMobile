using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarrotMobile.Models.DTO {
    public class User {
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Rewards")]
        public List<string> Rewards { get; set; }
}
}
