using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using CarrotMobile.Models.Responses;

namespace CarrotMobile.Services.Accounts
{
    class FirebaseAccountService : IAccountService {
        public void ForgotPassword() {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> Login(string email, string password) {
            return Task.FromResult(new LoginResponse
            {
                Success = false,
                User = new Models.DTO.User
                {
                    Name = "Ernst",
                    Surname = "Kaese" }
            });
        }

        public void Register() {
            throw new NotImplementedException();
        }
    }
}
