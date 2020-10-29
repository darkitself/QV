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
            QrCode.Icon = ImageSource.FromResource("QV.Images.QR.png");
            AliensBc.Icon = ImageSource.FromResource("QV.Images.AllAliensBusinessCards.png");
            OwnBCs.Icon = ImageSource.FromResource("QV.Images.AllMyBusinessCards.png");
            Logo.Source = ImageSource.FromResource("QV.Images.qvlogo.png");
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
