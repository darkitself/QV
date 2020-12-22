using Android.App;
using Android.Content;
using Android.Provider;
using Android.Widget;
using QV.Droid;
using QV.Infrastructure;

[assembly: UsesPermission(Android.Manifest.Permission.ReadContacts)]
[assembly: Xamarin.Forms.Dependency(typeof(ContactSaver))]

namespace QV.Droid
{
    public class ContactSaver : IContactSaver
    {
        public void SaveContact(UserData userData)
        {
            if (IsContactsContainNumber(userData.Phone_Number))
            {
                Toast.MakeText(Application.Context, "Такой контакт уже существует",
                               ToastLength.Long)?.Show();
                return;
            }

            if (string.IsNullOrEmpty(userData.Phone_Number))
            {
                Toast.MakeText(Application.Context, "У визитки нет номера телефона",
                               ToastLength.Long)?.Show();
                return;
            }

            StartContactSaveActivity(userData);
        }

        private void StartContactSaveActivity(UserData userData)
        {
            var intent = new Intent(Intent.ActionInsert);
            intent.SetFlags(ActivityFlags.NewTask);
            intent.SetType(ContactsContract.Contacts.ContentType);
            intent.PutExtra(ContactsContract.Intents.Insert.Name,
                            $"{userData.Surname} {userData.Name} {userData.Patronymic}");
            intent.PutExtra(ContactsContract.Intents.Insert.Email, userData.Email);
            intent.PutExtra(ContactsContract.Intents.Insert.Phone, userData.Phone_Number);
            intent.PutExtra(ContactsContract.Intents.Insert.Notes, userData.Info);
            Application.Context.StartActivity(intent);
        }

        private bool IsContactsContainNumber(string phoneNumber)
        {
            using var phones =
                Application.Context.ContentResolver.Query(
                                                          ContactsContract.CommonDataKinds.Phone
                                                              .ContentUri,
                                                          null,
                                                          ContactsContract.CommonDataKinds.Phone
                                                              .InterfaceConsts.DisplayName,
                                                          null,
                                                          null);
            if (phones == null) return false;
            while (phones.MoveToNext())
            {
                var number =
                    phones.GetString(phones.GetColumnIndex(ContactsContract.CommonDataKinds.Phone
                                                               .Number));
                if (number == null || !number.Equals(phoneNumber)) continue;
                return true;
            }

            return false;
        }
    }
}