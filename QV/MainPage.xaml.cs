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
            if (!App.Current.Properties.ContainsKey("Logged"))
                App.Current.Properties["Logged"] = false;
            InitializeComponent();
            Routing.RegisterRoute(nameof(BCDetailsPage), typeof(BCDetailsPage));
            if (App.Current.Properties.TryGetValue("Logged", out object logged) && !(bool)logged)
                Navigation.PushModalAsync(new LoginPage());
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["Logged"] = false;
            App.Current.SavePropertiesAsync();
            Shell.Current.FlyoutIsPresented = false;
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}
