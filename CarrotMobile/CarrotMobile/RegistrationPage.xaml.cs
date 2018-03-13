using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarrotMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
			InitializeComponent ();

            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => GoToLogin();
            logInLabel.GestureRecognizers.Add(tgr);

            fullNameEntry.Completed += (sender, args) => { emailEntry.Focus(); };
            emailEntry.Completed += (sender, args) => { passwordEntry.Focus(); };
            passwordEntry.Completed += (sender, args) => { Register(sender, args); };
        }

        private void Register(object sender, EventArgs e) {
            DisplayAlert("Registering", "Your name: " + fullNameEntry.Text + "\nYour email: " + emailEntry.Text + "\nYour password is safe with us...", "Noice!");
        }

        private void GoogleSignUp(object sender, EventArgs e) {
            DisplayAlert("Google", "You clicked the sign up with google button but we're useless devs T_T", "Ohhhh shiiiiit!");
        }

        private void GoToLogin() {
            Navigation.PushAsync(new MainPage());
        }
	}
}