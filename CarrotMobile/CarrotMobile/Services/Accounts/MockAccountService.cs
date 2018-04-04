using CarrotMobile.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarrotMobile.Services.Accounts {
    class MockAccountService : IAccountService {
        public void ForgotPassword() {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> Login(string email, string password) {
            return Task.FromResult(new LoginResponse {
                Success = true,
                User = new Models.DTO.User {
                    FullName = "Ernst Kaese",
                    Email = "ernstkaese@gmail.com",
                    Password = "password123"
                }
            });
            //var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //var filePath = Path.Combine(documentsPath, "Users.json");
            //string text = File.ReadAllText(filePath);
            //Models.DTO.User user = JsonConvert.DeserializeObject<Models.DTO.User>(text);
        }

        public bool Register(string name, string email, string password) {
            if (name != null && email != null && password != null) {
                var user = new Models.DTO.User() { FullName = name, Email = email, Password = password };
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, "Users.json");

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(filePath))
                using (JsonWriter writer = new JsonTextWriter(sw)) {
                    serializer.Serialize(writer, user);
                }
                return true;
            } else {
                return false;
            }
        }
    }
}
