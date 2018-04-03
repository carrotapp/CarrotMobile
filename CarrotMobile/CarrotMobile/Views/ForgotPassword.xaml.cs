using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarrotMobile
{
	public partial class ForgotPassword : ContentPage
	{
		public ForgotPassword ()
		{
			InitializeComponent ();

            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => GoToLogin();
            loginLabel.GestureRecognizers.Add(tgr);

            emailAddressEntry.Completed += (sender, args) => { ResetPassword(sender, args); };
		}

        async void ResetPassword(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Password reset", "Check your email for further instructions on how to reset your password", "Got It", "Back to login");
            if (!answer)
            {
                GoToLogin();
            }
        }

        public void GoToLogin()
        {
            Navigation.PushAsync(new MainPage());
        }
	}
}