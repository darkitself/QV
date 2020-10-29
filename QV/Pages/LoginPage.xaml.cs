using System;
using System.Net.Mail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage 
    {
        public LoginPage()
        {
            InitializeComponent();
            LogoImage.Source = ImageSource.FromResource("QV.Images.qvlogo.png");

        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            App.Current.Properties["Logged"] = true;
            await App.Current.SavePropertiesAsync();
            await Navigation.PopModalAsync();
        }
        private void RegistrationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrationPage());
        }
        
        private void LoginUnfocused(object sender, FocusEventArgs e)
        {
            IsRightEmail = new Image();
            //TODO icon that would be show is email right
        }
    }
}