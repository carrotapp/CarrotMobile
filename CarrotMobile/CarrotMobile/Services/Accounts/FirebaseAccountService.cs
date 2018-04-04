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
                    FullName = "Ernst Kaese",
                    Email = "ernstkaese@gmail.com",
                    Password = "password123"
                }
            });
        }

        public bool Register(string name, string email, string password) {
            throw new NotImplementedException();
        }
    }
}
