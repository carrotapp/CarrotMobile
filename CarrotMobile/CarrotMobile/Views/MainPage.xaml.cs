using CarrotMobile.Services.Accounts;
using CarrotMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarrotMobile
{
    public partial class MainPage : ContentPage
    {
        public IAccountService AccountService = new MockAccountService();

        public MainPage()
        {
            InitializeComponent();

            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => GoToRegister();
            registerLbl.GestureRecognizers.Add(tgr);

            var passwordg = new TapGestureRecognizer();
            passwordg.Tapped += (s, e) => GoToForgotPassword();
            forgotPswLbl.GestureRecognizers.Add(passwordg);
        }

        async protected void Login(object s, EventArgs e)
        {
            var loginResponse = await AccountService.Login(emailEntry.Text, passwordEntry.Text);

            generalError.HeightRequest = 0;
            generalError.Text = "";
            emailError.HeightRequest = 0;
            emailError.Text = "";

            var email = emailEntry.Text;
            var password = passwordEntry.Text;
            if (password != null && email != null)
            {
                Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match emailMatch = emailRegex.Match(email);
                if (emailMatch.Success)
                {
                    if (loginResponse.Success)
                    {
                        await DisplayAlert("You have Successfully loged in", loginResponse.User.FullName, "take me dashboard");
                        await Navigation.PushAsync(new DashboardPage());
                    }
                    else
                    {
                        await DisplayAlert("Failed", "", "Oh no");
                    }
                }
                else
                {
                    emailError.HeightRequest = 20;
                    emailError.Text = "Not a valid email address";
                }
            }
            else
            {
                generalError.HeightRequest = 20;
                generalError.Text = "Please fill in all the fields";
            }
        }

        protected void GoogleSignIn(object s, EventArgs e)
        {
            Navigation.PushAsync(new EmptyDashboardPage());
            //  DisplayAlert("Google login Works", "This will log you in with google", "OK Cool.");
        }

        private void GoToForgotPassword()
        {
            Navigation.PushAsync(new ForgotPassword());

            //DisplayAlert("Forgot password works", "This will take you to the 'Forgot Password' page", "OK Cool.");
        }

        private void GoToRegister()
        {
            Navigation.PushAsync(new RegistrationPage());

            //DisplayAlert("Register works","This will take you to the 'Registration' page", "OK Cool.");
        }
    }
}