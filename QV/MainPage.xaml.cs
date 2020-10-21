using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QV
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BCDetailsPage), typeof(BCDetailsPage));
            Navigation.PushModalAsync(new LoginPage());
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}
