using Android.Widget;
using QV.Droid;

[assembly:Xamarin.Forms.Dependency(typeof(AndroidToastNotifications))]
namespace QV.Droid
{
    public class AndroidToastNotifications : ICanMakeToast
    {
        public AndroidToastNotifications()
        {
        }

        public void MakeToast(string message )
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short)?.Show();
        }
    }
}