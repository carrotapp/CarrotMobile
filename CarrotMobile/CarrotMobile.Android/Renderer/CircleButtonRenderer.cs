using Android.Content;
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
                Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
            }
        }
    }
}