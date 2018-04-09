using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CarrotMobile.Models.DTO;
using CarrotMobile.Models.Responses;

namespace CarrotMobile.Services.Rewards
{
    internal class MockRewardService : IRewardService
    {
        public Task<RewardResponse> GetRewards()
        {
            return Task.FromResult(new RewardResponse
            {
                Success = true,

                Rewards = new Models.DTO.Reward
                {
                    Currency = "eb",
                    How = "Ask FNB",
                    InforUrl = "google",
                    Name = "eBucks",
                    ProviderName = "FNB",
                    Ratio = 0,
                    Summary = "Save",
                    Where = "Anywhere"
                }
            });
        }
    }
}