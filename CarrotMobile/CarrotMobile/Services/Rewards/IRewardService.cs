using CarrotMobile.Models.DTO;
using CarrotMobile.Models.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CarrotMobile.Services.Rewards
{
    public interface IRewardService
    {
        Task<RewardResponse> GetUserRewards();
        List<Reward> GetAllRewards();
        List<Reward> FindUserRewards(List<Reward> rewards);
    }
}