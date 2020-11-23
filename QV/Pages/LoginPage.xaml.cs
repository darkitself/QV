using QV.Infrastructure;
using QV.RequestsAndAnswers;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading;
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
            LogoImage.Source = ImageSource.FromResource("QV.Images.QvLogoWithoutBoard.png");
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            var user = Connection.RequestToServer<AuthorizationRequest, AuthorizationAnswer>(new AuthorizationRequest()
            { Login = this.Login.Text, Password = this.Password.Text }, "01");
            App.Data.CurrentUser.ID = user.ID;
            App.Data.CurrentUser.MainData = user.Data;
            App.Data.CurrentUser.AltData = user.Alt_Data;
            App.Data.AliensCards = user.Alien_Cards.ToDictionary(c => c.ID);
            App.Data.UserCards = user.User_Cards.ToDictionary(c => c.ID);
            Application.Current.Properties["Logged"] = true;
            await Application.Current.SavePropertiesAsync();
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