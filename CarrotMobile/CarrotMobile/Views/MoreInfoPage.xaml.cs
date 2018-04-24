using CarrotMobile.Models.DTO;
using CarrotMobile.Services.Rewards;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarrotMobile.Views
{

    public partial class MoreInfoPage : ContentPage
    {
        Reward CurrentReward;
        IRewardService rewardService = new MockRewardService();

        public MoreInfoPage(Reward reward)
        {
            InitializeComponent();

            CurrentReward = reward;
            BindingContext = CurrentReward;

        }

        protected async void DeleteReward(object sender, EventArgs e)
        {
            AddRewardResponse response = await rewardService.RemoveReward(CurrentReward.Key);

            if (response.Success)
            {
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Failure", "Could not delete reward.", "Oh my!");
            }
        }

    }
}