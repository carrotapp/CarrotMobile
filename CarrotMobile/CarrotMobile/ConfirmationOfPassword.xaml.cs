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
	public partial class ConfirmationOfPassword : ContentPage
	{
		public ConfirmationOfPassword ()
		{
			InitializeComponent ();


            //var tgr = new TapGestureRecognizer();
            // tgr.Tapped += (s, e) => GoToLogin();
            //loginLbl.GestureRecognizers.Add(tgr);
        }
    }
}