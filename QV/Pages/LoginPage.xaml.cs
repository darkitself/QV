using System;
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
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
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