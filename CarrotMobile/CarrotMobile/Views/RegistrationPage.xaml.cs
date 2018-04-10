using CarrotMobile.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarrotMobile
{
	public partial class RegistrationPage : ContentPage
	{
        public IAccountService AccountService = new MockAccountService();

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

        private async void Register(object sender, EventArgs e) {
            generalError.HeightRequest = 0;
            generalError.Text = "";
            emailError.HeightRequest = 0;
            emailError.Text = "";
            passwordError.HeightRequest = 0;
            passwordError.Text = "";

            var fullName = fullNameEntry.Text;
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            if (fullName != null && email != null && password != null) {
                Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match emailMatch = emailRegex.Match(email);

                Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).\S{8,}$");
                Match passwordMatch = passwordRegex.Match(password);
                if (emailMatch.Success) {
                    if (passwordMatch.Success) {
                        AccountService.Register(fullNameEntry.Text, emailEntry.Text, passwordEntry.Text);
                        await DisplayAlert("Success!", "You've been registered successfully", "Neat!");
                        await Navigation.PushAsync(new AddRewardsPage());
                    } else {
                        passwordError.HeightRequest = 60;
                        passwordError.Text = "Password must be atleast 8 characters in length and contain atleast one uppercase, lowercase, numerical and special character.";
                    }
                } else {
                    emailError.HeightRequest = 20;
                    emailError.Text = "Not a valid email address";
                }
            } else {
                generalError.HeightRequest = 20;
                generalError.Text = "Please fill in all the fields";
            }

        }

        private async void GoogleSignUp(object sender, EventArgs e) {
            await DisplayAlert("Google", "You clicked the sign up with google button", "Cool!");
            await Navigation.PushAsync(new AddRewardsPage());
        }

        private void GoToLogin() {
            Navigation.PushAsync(new MainPage());
        }
	}
}