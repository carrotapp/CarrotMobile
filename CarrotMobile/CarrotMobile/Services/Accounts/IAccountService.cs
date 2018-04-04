using CarrotMobile.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarrotMobile.Services.Accounts
{
    public interface IAccountService
    {
        Task<LoginResponse> Login(string email, string password);
        bool Register(string name, string email, string password);
        void ForgotPassword();
    }
}
