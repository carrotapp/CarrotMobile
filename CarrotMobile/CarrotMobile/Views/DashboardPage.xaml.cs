using CarrotMobile.Models.DTO;
using CarrotMobile.Models.Responses;
using CarrotMobile.Services.Rewards;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarrotMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public IRewardService RewardService = new MockRewardService();

        //public ObservableCollection<Reward> Items { get; set; }

        public DashboardPage()
        {
            InitializeComponent();

            // Items = new ObservableCollection<Reward>
            //{
            // new Models.DTO.Reward{'eb','bank','google','SmartShopper','Pick n Pay',100,'Grocery','South Africa' }
            //};
            GetUserRewards();
            //MyListView.ItemsSource = new[] { new Reward
            //    {
            //        ProviderName = "FNB",
            //        Image="FNB.png"
            //    },new Reward
            //    {
            //        ProviderName = "Woolworths",
            //     Image="Woolworths.png"
            //    },new Reward
            //    {
            //        ProviderName = "ABSA Rewards",
            //     Image="Absa.png"
            //    } };
            
        }

        protected async void GetUserRewards()
        {
            RewardResponse rewardsResponse = await RewardService.GetUserRewards();
            if (rewardsResponse.Success)
            {
                Debug.Print(rewardsResponse.Success.ToString());
                MyListView.ItemsSource = rewardsResponse.Rewards.ToArray();
            }
            else
            {
                await DisplayAlert("Reward", "You Have No Rewards", "OK");
            }
        }

        private void OnCellClicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            var reward= (Reward)b.CommandParameter;

            Navigation.PushAsync(new MoreInfoPage(reward));


            // await ((ContentPage)((ListView)((ViewCell)((Frame)((Grid)b.Parent).Parent).Parent).Parent).Parent).DisplayAlert("Clicked", t.ProviderName + " button was clicked", "OK");
            // Debug.WriteLine("clicked" + t);
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected async void GoToAddRewards()
        {
            await Navigation.PushAsync(new AddRewardsPage());
        }
    }
}