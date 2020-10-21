using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = new NavigationPage(new MainPage());
            page.PushAsync(new LoginPage());
            MainPage = page;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
