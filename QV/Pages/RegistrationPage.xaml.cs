using QV.Infrastructure;
using QV.RequestsAndAnswers;
using System;
using Xamarin.Forms.Xaml;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegistrationButtonClicked(object sender, EventArgs e)
        {
            var id = Connection.RequestToServer<RegistrationRequest, RegistrationAnswer>(new RegistrationRequest()
            { Login = this.Login.Text, Password = this.Password.Text }, RequestsTypes.Registration).ID;
            if (id < 0)
                await DisplayAlert("", "Вы не зарегестрированы", "OK");
            else
            {
                await DisplayAlert("", "Вы зарегестрированы", "OK");
                await Navigation.PopModalAsync();
            }
        }
    }
}