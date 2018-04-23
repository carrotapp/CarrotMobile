using CarrotMobile.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace CarrotMobile.Services.Accounts {
    class MockAccountService : IAccountService {
        public void ForgotPassword() {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> Login(string email, string password) {
            var loginResponse = new LoginResponse();
            var user = new Models.DTO.User() { Email = email, Password = password };
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "Users.json");
            string details = "";
            using (var streamReader = new StreamReader(filePath)) {
                details = streamReader.ReadToEnd();
            }
            if (details != null) {
                user = JsonConvert.DeserializeObject<Models.DTO.User>(details);
                Debug.Print(details);
            }

            //bool loginCon = false;

            if (user.Password == password && user.Email == email) {
                Debug.Print("checking Valid:True");
                loginResponse.Success = true;
                loginResponse.User = user;
            } else {
                Debug.Print("checking Valid:False");
                loginResponse.Success = false;
            }
            return Task.FromResult(
            loginResponse

            );
        }

        public void Register(string name, string email, string password) {
            var user = new Models.DTO.User() { FullName = name, Email = email, Password = password, Rewards = new[] { "-KtW0RA8mHkt24UM9Hb8", "-KtW0ozg6YHtTuKd2OPE" } };
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "Users.json");

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw)) {
                serializer.Serialize(writer, user);
            }
        }
    }
}
