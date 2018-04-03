using CarrotMobile.Models.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CarrotMobile.Services.Accounts
{
    class MockAccountService : IAccountService {
        public void ForgotPassword() {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> Login(string email, string password) {
            return Task.FromResult(new LoginResponse {
                Success = true,
                User = new Models.DTO.User {
                    Name = "Ernst",
                    Surname = "Kaese"
                }
            });
        }

        public void Register() {
            throw new NotImplementedException();
        }
    }
}
