using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            var dict = new Dictionary<string, BC>
            {
                ["1"] = new BC { Id = "1", Text = "Item 1" },
                ["2"] = new BC { Id = "2", Text = "Item 2" },
                ["3"] = new BC { Id = "3", Text = "Item 3" },
                ["4"] = new BC { Id = "4", Text = "Item 4" },
                ["5"] = new BC { Id = "5", Text = "Item 5" }
            };

            Properties["AlienBCsDict"] = dict;
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
