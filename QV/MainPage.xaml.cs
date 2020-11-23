using QV.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QV
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AlienCardDetailsPage), typeof(AlienCardDetailsPage));
            Routing.RegisterRoute(nameof(UserCardDetailsPage), typeof(UserCardDetailsPage));
            if (!Application.Current.Properties.TryGetValue("Logged", out var logged) || (logged is null) || !(bool)logged)
                Navigation.PushModalAsync(new LoginPage());
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["Logged"] = false;
            Application.Current.SavePropertiesAsync();
            Current.FlyoutIsPresented = false;
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}
