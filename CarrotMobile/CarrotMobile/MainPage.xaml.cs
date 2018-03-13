using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarrotMobile
{
	public partial class MainPage : ContentPage
	{
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
            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            await DisplayAlert("Login Works","Email: "+email +", Password: "+password + " This will log you in", "OK Cool.");
        }

        protected void GoogleSignIn(object s, EventArgs e)
        {
            DisplayAlert("Google login Works", "This will log you in with google", "OK Cool.");
        }

        private void GoToForgotPassword()
        {
            //Navigation.PushAsync(new RegistrationPage);

            DisplayAlert("Forgot password works", "This will take you to the 'Forgot Password' page", "OK Cool.");
        }

        private void GoToRegister()
        {
            //Navigation.PushAsync(new RegistrationPage);

            DisplayAlert("Register works","This will take you to the 'Registration' page", "OK Cool.");
        }
	}
}
