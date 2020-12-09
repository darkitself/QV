using System.IO;
using System.Threading.Tasks;
using Android.Content;
using QV.Droid;
using QV.Infrastructure;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoPickerService))]

namespace QV.Droid
{
    public class PhotoPickerService : IPhotoPickerService
    {
        public Task<Stream> GetImageStreamAsync()
        {
            var intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            MainActivity.mainActivity.StartActivityForResult(
                                                             Intent.CreateChooser(intent, "Select Picture"),
                                                             MainActivity.PickImageId);
            MainActivity.mainActivity.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();
            return MainActivity.mainActivity.PickImageTaskCompletionSource.Task;
        }
    }
}