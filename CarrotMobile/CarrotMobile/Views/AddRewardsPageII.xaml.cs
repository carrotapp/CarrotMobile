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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

        private void AddRewardsButton_Clicked(object sender, EventArgs e)
        {
            Debug.Print("Clicked on Add Rewards button");
        }

        private void OnCellClicked(object sender, EventArgs e)
        {
            Debug.Print("Clicked on a cell");
        }



    }
    }
