using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

            var AlienBCsDict = new Dictionary<string, BC>
                       {
                           ["1"] = new BC {
                                              Id = "1",
                                              Name = "Name",
                                              Surname = "Surname",
                                              Email = "Email",
                                              FaceBookLink = "FaceBookLink",
                                              MiddleName = "MiddleName",
                                              TelephoneNumber = "TelephoneNumber",
                                              VKLink = "VKLink"
                                          },
                           ["2"] = new BC
                                   {
                                       Id = "2",
                                       Name = "Name2",
                                       Surname = "Surname2",
                                       Email = "Email2",
                                       TelephoneNumber = "TelephoneNumber2",
                                       VKLink = "VKLink2"
                                   },
                       };
            var MyBCsDict = new Dictionary<string, BC>
            {
                ["3"] = new BC
                {
                    Id = "3",
                    Name = "Name",
                    Surname = "Surname",
                    Email = "Email",
                    FaceBookLink = "FaceBookLink",
                    MiddleName = "MiddleName",
                    TelephoneNumber = "TelephoneNumber",
                    VKLink = "VKLink"
                },
                ["4"] = new BC
                {
                    Id = "4",
                    Name = "Name2",
                    Surname = "Surname2",
                    Email = "Email2",
                    TelephoneNumber = "TelephoneNumber2",
                    VKLink = "VKLink2"
                },
            };

            Properties["AlienBCsDict"] = AlienBCsDict;
            Properties["MyBCsDict"] = MyBCsDict;
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
