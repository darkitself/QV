
using Android.App;
using Android.Content;
using Android.Provider;
using QV.Droid;
using QV.Infrastructure;
[assembly:Xamarin.Forms.Dependency(typeof(ContactSaver))]

namespace QV.Droid
{
    public class ContactSaver : IContactSaver
    {
        public void SaveContact(UserData userData)
        {
            var intent = new Intent(Intent.ActionInsert);
            intent.SetFlags(ActivityFlags.NewTask);
            intent.SetType(ContactsContract.Contacts.ContentType);
            intent.PutExtra(ContactsContract.Intents.Insert.Name,$"{userData.Surname} {userData.Name} {userData.Patronymic}");
            intent.PutExtra(ContactsContract.Intents.Insert.Email, userData.Email);
            intent.PutExtra(ContactsContract.Intents.Insert.Phone, userData.Phone_Number);
            intent.PutExtra(ContactsContract.Intents.Insert.Notes, userData.Info);
            Application.Context.StartActivity(intent);
        }
    }
}