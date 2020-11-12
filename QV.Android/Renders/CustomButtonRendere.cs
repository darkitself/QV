using Android.Graphics.Drawables;
using QV;
using QV.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace QV.Droid.Renders
{
    
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;
            Control.Background = Resources.GetDrawable(Resource.Drawable.button_background);
            
            
        }
    }
}