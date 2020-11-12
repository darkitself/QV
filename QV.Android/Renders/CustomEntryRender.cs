
using Android.Graphics;
using Android.Graphics.Drawables;
using QV.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRender))]
namespace QV.Droid.Renders
{
    public class CustomEntryRender : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null) return;
               
            Control.Background = Resources?.GetDrawable(Resource.Drawable.rounded_corner_entry);
        }
    }
}