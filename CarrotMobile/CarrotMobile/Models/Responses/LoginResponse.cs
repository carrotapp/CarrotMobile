using CarrotMobile.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarrotMobile.Models.Responses
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public User User { get; set; }
    }
}
