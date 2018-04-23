using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CarrotMobile.Models.DTO;
using CarrotMobile.Models.Responses;
using Newtonsoft.Json;

namespace CarrotMobile.Services.Rewards {
    internal class MockRewardService : IRewardService {
        public Task<RewardResponse> GetRewards() {
            //var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //var filePath = Path.Combine("../../JSON/", "Users.json");
            var assembly = typeof(Views.DashboardPage).Assembly;
            Stream stream = assembly.GetManifestResourceStream("CarrotMobile.JSON.Rewards.json");
            string details = "";
            using (var streamReader = new StreamReader(stream)) {
                details = streamReader.ReadToEnd();
            }
            if (details != null) {
                //user = JsonConvert.DeserializeObject<Models.DTO.User>(details);
                //Reward rewards = JsonConvert.DeserializeObject<Models.DTO.Reward>(details);
                List<Reward> rewards = new List<Reward>();
                String[] rewardsJson = details.Split('}');
                for(int i=0; i<rewardsJson.Length; i++) {
                    //Debug.Print(rewardsJson[i]);
                    //rewards.Add(JsonConvert.DeserializeObject<Models.DTO.Reward>(rewardsJson[i]));
                    //Debug.Print(rewards.ToArray()[i].ProviderName);
                }
            }

            return Task.FromResult(new RewardResponse {
                Success = true,

                Rewards = null
            });
        }
    }
}