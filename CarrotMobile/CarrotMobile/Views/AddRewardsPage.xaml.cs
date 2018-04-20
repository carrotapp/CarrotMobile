using CarrotMobile.Models.DTO;
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
        public AddRewardsPage()
        {
            InitializeComponent();

            MyListView.ItemsSource = new[] 
            {
                new Reward
                {
                    ProviderName = "FNB",
                    Image="FNB.png"
                },
                new Reward
                {
                   ProviderName = "Woolworths",
                    Image="Woolworths.png"
             },
                new Reward
               {
                    ProviderName = "ABSA Rewards",
                    Image="Absa.png"
                }
            };

        }
    }
}