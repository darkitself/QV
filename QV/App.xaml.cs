using QV.Infrastructure;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text.Json;

namespace QV
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();

            var user = new User
            {
                Login = "Login",
                Password = "123456",
                Data = new UserData
                {
                    Name = "Name2",
                    Surname = "Surname2",
                    Email = "Email2",
                    TelephoneNumber = "TelephoneNumber2",
                    VKLink = "VKLink2"
                }
            };

            var AlienBCsDict = new Dictionary<string, BC>
            {
                ["1"] = new BC
                {
                    Id = "1",
                    Data = new UserData
                    {
                        Name = "Name",
                        Surname = "Surname",
                        Email = "Email",
                        FaceBookLink = "FaceBookLink",
                        MiddleName = "MiddleName",
                        TelephoneNumber = "TelephoneNumber",
                        VKLink = "VKLink"
                    },
                },
                ["2"] = new BC
                {
                    Id = "2",
                    Data = new UserData
                    {
                        Name = "Name2",
                        Surname = "Surname2",
                        Email = "Email2",
                        TelephoneNumber = "TelephoneNumber2",
                        VKLink = "VKLink2"
                    }
                },
            };
            var MyBCsDict = new Dictionary<string, BC>
            {
                ["3"] = new BC
                {
                    Id = "3",
                    Data = new UserData
                    {
                        Name = "Name",
                        Surname = "Surname",
                        Email = "Email",
                        FaceBookLink = "FaceBookLink",
                        MiddleName = "MiddleName",
                        TelephoneNumber = "TelephoneNumber",
                        VKLink = "VKLink"
                    }
                },
                ["4"] = new BC
                {
                    Id = "4",
                    Data = new UserData
                    {
                        Name = "Name2",
                        Surname = "Surname2",
                        Email = "Email2",
                        TelephoneNumber = "TelephoneNumber2",
                        VKLink = "VKLink2"
                    }
                },
            };

            Properties["User"] = JsonSerializer.Serialize<User>(user);
            Properties["AlienBCsDict"] = JsonSerializer.Serialize<Dictionary<string, BC>>(AlienBCsDict);
            Properties["MyBCsDict"] = JsonSerializer.Serialize<Dictionary<string, BC>>(MyBCsDict);
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
