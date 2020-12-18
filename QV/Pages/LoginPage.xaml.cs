using QV.Infrastructure;
using QV.RequestsAndAnswers;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage 
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            Application.Current.Properties["Logged"] = true;
            var answer = Connection.RequestToServer<AuthorizationRequest, AuthorizationAnswer>(new AuthorizationRequest()
            { Login = this.Login.Text, Password = this.Password.Text }, RequestsTypes.Autorization);
            if (!answer.Success)
            {
                await DisplayAlert("Неверный логин", "Или пароль", "OK");
                return;
            }
            var data = Connection.RequestToServer<GetUserDataRequest, GetUserDataAnswer>(new GetUserDataRequest()
            { ID = answer.ID}, RequestsTypes.GetAllUserData);
            App.Data.CurrentUser.ID = answer.ID;
            App.Data.CurrentUser.MainData = data.Data;
            App.Data.CurrentUser.AltData = data.Alt_Data;
            App.Data.AliensCards = data.Alien_Cards.ToDictionary(c => c.ID);
            App.Data.UserCards = data.User_Cards.ToDictionary(c => c.ID);
            Application.Current.Properties["Logged"] = true;
            await Application.Current.SavePropertiesAsync();
            await Shell.Current.GoToAsync($"//TabBar/QRCodePage");
            DependencyService.Get<ICanMakeToast>().MakeToast("Успех");
            await Navigation.PopModalAsync();
        }
        private void RegistrationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrationPage());
        }
        
        private void LoginUnfocused(object sender, FocusEventArgs e)
        {
            //TODO icon that would be show is email right
        }
    }
}