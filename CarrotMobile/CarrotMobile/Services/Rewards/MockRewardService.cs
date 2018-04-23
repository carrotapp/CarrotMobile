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
        public Task<RewardResponse> GetUserRewards() {
            List<Reward> userRewards = FindUserRewards(GetAllRewards());

            RewardResponse rewardResponse = new RewardResponse {
                Success = true,
                Rewards = userRewards
            };

            return Task.FromResult(rewardResponse);
        }

        public List<Reward> GetAllRewards() {
            var assembly = typeof(Views.DashboardPage).Assembly;
            String[] stream = assembly.GetManifestResourceNames();
            string details = null;

            List<Reward> rewards = new List<Reward>();
            Reward reward;
            for (int i = 0; i < stream.Length; i++) {
                if (stream[i].EndsWith("_rewards.json")) {
                    Stream s = assembly.GetManifestResourceStream(stream[i]);
                    using (var streamReader = new StreamReader(s)) {
                        details = streamReader.ReadToEnd();
                        if (details != null) {
                            reward = JsonConvert.DeserializeObject<Models.DTO.Reward>(details);
                            rewards.Add(reward);
                        }
                    }
                }
            }
            return rewards;
        }

        public List<Reward> FindUserRewards(List<Reward> rewards) {
            List<Reward> userRewards = new List<Reward>();

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "Users.json");
            string details = "";
            using (var streamReader = new StreamReader(filePath)) {
                details = streamReader.ReadToEnd();
            }
            if (details != null) {
                User user = JsonConvert.DeserializeObject<Models.DTO.User>(details);
                String[] userRewardsKeys = user.Rewards;
                for (int i = 0; i < rewards.Count; i++) {
                    for (int j = 0; j < userRewardsKeys.Length; j++) {
                        if (rewards[i].Key.Equals(userRewardsKeys[j])) {
                            userRewards.Add(rewards[i]);
                        }
                    }
                }
            }

            return userRewards;
        }

        public Task<AddRewardResponse> AddReward(String key) {
            AddRewardResponse rewardResponse = new AddRewardResponse();
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "Users.json");
            string details = "";
            using (var streamReader = new StreamReader(filePath)) {
                details = streamReader.ReadToEnd();
            }
            if (details != null) {
                User user = JsonConvert.DeserializeObject<User>(details);
                user.Rewards.Add(key);

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(filePath))
                using (JsonWriter writer = new JsonTextWriter(sw)) {
                    serializer.Serialize(writer, user);
                }
                rewardResponse.Success = true;
            } else {
                rewardResponse.Success = false;
            }

            return Task.FromResult(rewardResponse);
        }

        public Task<AddRewardResponse> RemoveReward(String key) {
            AddRewardResponse rewardResponse = new AddRewardResponse();
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "Users.json");
            string details = "";
            using (var streamReader = new StreamReader(filePath)) {
                details = streamReader.ReadToEnd();
            }
            if (details != null) {
                User user = JsonConvert.DeserializeObject<User>(details);
                user.Rewards.Remove(key);

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(filePath))
                using (JsonWriter writer = new JsonTextWriter(sw)) {
                    serializer.Serialize(writer, user);
                }
                rewardResponse.Success = true;
            } else {
                rewardResponse.Success = false;
            }

            return Task.FromResult(rewardResponse);
        }
    }
}