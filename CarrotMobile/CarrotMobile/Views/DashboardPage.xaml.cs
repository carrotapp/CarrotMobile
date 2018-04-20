using CarrotMobile.Models.DTO;
using CarrotMobile.Models.Responses;
using CarrotMobile.Services.Rewards;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

            AddRewardsButton.Clicked += AddRewardsButton_Clicked;

            MyListView.ItemsSource = new[] { new Reward
                {
                    ProviderName = "FNB",
                    Image="FNB.png"
                },new Reward
                {
                    ProviderName = "Woolworths",
                 Image="Woolworths.png"
                },new Reward
                {
                    ProviderName = "ABSA Rewards",
                 Image="Absa.png"
                } };
        }

        private void AddRewardsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddRewardsPage());
        }

        protected  async void GetUserRewards()
        {
            var rewardsResponse = await RewardService.GetRewards();
            if (rewardsResponse.Success)
            {
                await DisplayAlert("Reward", rewardsResponse.Rewards + "", "OK");
            }
            else
            {
                await DisplayAlert("Reward", "You Have No Rewards", "OK");
            }
        }

        private async void OnCellClicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            var t = (Reward)b.CommandParameter;

            await ((ContentPage)((ListView)((ViewCell)((Frame)((Grid)b.Parent).Parent).Parent).Parent).Parent).DisplayAlert("Clicked", t.ProviderName + " button was clicked", "OK");
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

        //protected async void GoToAddRewards()
        //{
        //    await Navigation.PushAsync(new AddRewardsPage());
        //}
    }
}