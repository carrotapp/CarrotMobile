using CarrotMobile.Services.Accounts;
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

        private void Register(object sender, EventArgs e) {
            //DisplayAlert("Registering", "Your name: " + fullNameEntry.Text + "\nYour email: " + emailEntry.Text + "\nYour password is safe with us...", "Nice!");
            bool response = AccountService.Register(fullNameEntry.Text, emailEntry.Text, passwordEntry.Text);
            if (response) {
                DisplayAlert("Success!", "You've been registered successfully.", "Neat!");
            } else {
                DisplayAlert("Oops!", "Please make sure that all the fields are filled in and try again.", "Okay");
            }
        }

        private void GoogleSignUp(object sender, EventArgs e) {
            DisplayAlert("Google", "You clicked the sign up with google button", "Cool!");
        }

        private void GoToLogin() {
            Navigation.PushAsync(new MainPage());
        }
	}
}