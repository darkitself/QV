using QV.Infrastructure;
using QV.RequestsAndAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            Image.Source = ImageSource.FromResource("QV.Images.qvlogo.png");
        }

        private async void RegistrationButtonClicked(object sender, EventArgs e)
        {
            var id = Connection.RequestToServer<RegistrationRequest, RegistrationAnswer>(new RegistrationRequest()
            { Login = this.Login.Text, Password = this.Password.Text }, "02").ID;
            if (id < 0)
                await DisplayAlert("", "Вы не зарегестрированы", "OK");
            else await DisplayAlert("", "Вы зарегестрированы", "OK");
        }
    }
}