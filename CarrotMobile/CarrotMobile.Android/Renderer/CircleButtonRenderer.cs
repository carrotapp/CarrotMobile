using Android.Content;
using Android.Graphics.Drawables;
using CarrotMobile;
using CarrotMobile.CustomRenderers;
using CarrotMobile.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircleButton), typeof(CircleButtonRenderer))]

namespace CarrotMobile.Droid.Renderer
{
    internal class CircleButtonRenderer : ButtonRenderer
    {
        public CircleButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var button = e.NewElement;

                button.BorderRadius = 25;
                button.BackgroundColor = Color.FromHex("#FBB400");
                button.WidthRequest = 50;
                button.HeightRequest = 50;
                button.Text = "+";
                button.TextColor = Color.White;
            }
        }
    }
}