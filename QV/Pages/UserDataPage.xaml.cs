using QV.Infrastructure;
using QV.RequestsAndAnswers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDataPage : ContentPage
    {
        User user;
        public UserDataPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            user = App.Data.CurrentUser;
            BindingContext = user.MainData;
            if (user.MainData.Image != null && user.MainData.Image.Length != 0)
                Image.Source = ImageSource.FromStream(() => new MemoryStream(user.MainData.Image));
        }
        private void AcceptButtonClicked(object sender, EventArgs e)
        {
            var newReq = new UpdateUserDataRequest
            {
                User_ID = App.Data.CurrentUser.ID,
                Image = user.MainData.Image
            };

            foreach (var p in newReq.GetType().GetProperties())
            {
                var entry = this.FindByName<InputView>(p.Name);
                if (entry != null)
                    p.SetValue(newReq, entry.Text);
            }

            var res = Connection.RequestToServer<UpdateUserDataRequest, UpdateUserDataAnswer>(newReq, RequestsTypes.ChangeUserData);
            if (res.Result)
            {
                foreach (var p in user.MainData.GetType().GetProperties())
                    p.SetValue(user.MainData,
                               newReq.GetType().GetProperty(p.Name).GetValue(newReq));
                DependencyService.Get<ICanMakeToast>().MakeToast("Данные сохранены!");
            }
            else
                DependencyService.Get<ICanMakeToast>().MakeToast("Что-то пошло не так :(");

            AcceptChangesButton.IsVisible = false;
            Logout.IsVisible = true;
        }

        private async void MainImageClicked(object sender, EventArgs e)
        {
            var streamAsync = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (streamAsync != null)
            {
                var m = new MemoryStream();
                streamAsync.CopyTo(m);
                Image.Source = ImageSource.FromStream(() => new BufferedStream(streamAsync));
                user.MainData.Image = m.ToArray();
            }
        }

        private async void Logout_OnClicked(object sender, EventArgs e)
        {
            Application.Current.Properties["Logged"] = false;
            await Navigation.PushModalAsync(new LoginPage());
        }

        private void EntryTextChanged(object sender, FocusEventArgs focusEventArgs)
        {
            Logout.IsVisible = false;
            AcceptChangesButton.IsVisible = true;
        }
    }
}