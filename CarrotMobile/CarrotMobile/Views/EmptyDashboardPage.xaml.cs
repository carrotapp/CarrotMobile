using CarrotMobile.Models.DTO;
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
    public partial class EmptyDashboardPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public EmptyDashboardPage()
        {
            InitializeComponent();

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

        protected async void GoToAddRewards()
        {
            await Navigation.PushAsync(new AddRewardsPage());
        }
    }
}