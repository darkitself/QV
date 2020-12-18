using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QV.CustomElements;
using QV.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LongClickImageButton), typeof(ImageButtonLongClickRenderer))]
namespace QV.Droid
{
    public class ImageButtonLongClickRenderer : ImageButtonRenderer
    {
        LongClickImageButton view;

        public ImageButtonLongClickRenderer(Context context) : base(context)
        {
            this.LongClick += (sender, args) => {
                view.HandleLongPress(sender, args);
            };
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ImageButton> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                view = e.NewElement as LongClickImageButton;
            }
        }
    }
}