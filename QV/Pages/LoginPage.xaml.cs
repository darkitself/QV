using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            LogoImage.Source = ImageSource.FromResource("QV.Images.qvlogo.png");
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        private void LoginUnfocused(object sender, FocusEventArgs e)
        {
            IsRightEmail = new Image();
            
        }
    }
}