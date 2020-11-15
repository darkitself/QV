using Android.Graphics;
using Android.Graphics.Drawables;
using QV.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZXing.Net.Mobile.Forms;
using Color = Android.Graphics.Color;

[assembly:ExportRenderer(typeof(ZXingScannerView), typeof(ZxingRenderer))]
namespace QV.Droid.Renders
{
    public class ZxingRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;
            var drawable = Control.Background as GradientDrawable;
            drawable?.SetStroke(3, Color.Green);
        }
    }
}