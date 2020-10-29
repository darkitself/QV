using System;
using QV.Infrastructure;
using Xamarin.Forms;

namespace QV
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Navigation.PushModalAsync(new LoginPage());
            Routing.RegisterRoute(nameof(BCDetailsPage), typeof(BCDetailsPage));
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}
