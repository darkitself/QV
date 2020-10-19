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
                ["1"] = new BC {
                    Id = "1",
                    Name = "Name",
                    Surname = "Surname",
                    Email = "Email",
                    FaceBookLink = "FaceBookLink",
                    MiddleName = "MiddleName",
                    TeleponeNumber = "TelephoneNumber",
                    VKLink = "VKLink"
                },
                ["2"] = new BC
                {
                    Id = "2",
                    Name = "Name2",
                    Surname = "Surname2",
                    Email = "Email2",
                    TeleponeNumber = "TelephoneNumber2",
                    VKLink = "VKLink2"
                },
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
