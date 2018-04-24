using CarrotMobile.Models.DTO;
using CarrotMobile.Models.Responses;
using CarrotMobile.Services.Rewards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarrotMobile
{
    public partial class AddRewardsPage : ContentPage
    {

        IRewardService RewardService = new MockRewardService();
        public AddRewardsPage()
        {
            InitializeComponent();

            GetRewards();

        }

        private void GetRewards()
        {
            List<Reward> rewards = RewardService.GetAllRewards();
            MyListView.ItemsSource = rewards.ToArray();

        }

        //private async void AddReward(Object sender, EventArgs e)
        //{
        //    await RewardResponse rewardResponse = RewardService.AddReward();
        //}
    }
}