using QV.Infrastructure;
using System.Collections.Generic;
using System.Text.Json;

namespace QV
{
    public partial class App 
    {
        public static AppData Data;
        public App()
        {
            Resources["BackgroundImageSource"] = "nature_background.png";
            Data = new AppData();
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Data.CurrentUser = Properties.ContainsKey("User")
                ? JsonSerializer.Deserialize<User>(Properties["User"] as string)
                : new User
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

            Data.AliensBCs = Properties.ContainsKey("AliensBCsDict")
                ? JsonSerializer.Deserialize<Dictionary<string, BC>>(Properties["AliensBCsDict"] as string)
                : new Dictionary<string, BC>
                {
                    ["1"] = new BC
                    {
                        Id = "1",
                        Data = new UserData
                        {
                            Name = "Egor",
                            Surname = "Chusov",
                            Email = "chusoveg17@gmail.com",
                            FaceBookLink = "FaceBookLink",
                            MiddleName = "MiddleName",
                            TelephoneNumber = "TelephoneNumber",
                            VKLink = "VKLink"
                        },
                        Flags = new DataFlags
                        {
                            Name = true,
                            Surname = true,
                            Email = true,
                            FaceBookLink = true,
                            MiddleName = true,
                            TelephoneNumber = true,
                            VKLink = true,
                        }
                    },
                    ["2"] = new BC
                    {
                        Id = "2",
                        Data = new UserData
                        {
                            Name = "Zhenya",
                            Surname = "Kalygin",
                            Email = "Xz",
                            TelephoneNumber = "8800000000",
                            VKLink = "VKLink2"
                        },
                        Flags = new DataFlags
                        {
                            Name = true,
                            Surname = true,
                            Email = true,
                            TelephoneNumber = true,
                            VKLink = true,
                        }
                    },
                    ["3"] = new BC
                            {
                                Id = "2",
                                Data = new UserData
                                       {
                                           Name = "Stiv Jobs",
                                           Email = "stivchik@",
                                           VKLink = "!235"
                                       }
                            }
                };

            Data.UserBCs = Properties.ContainsKey("UserBCsDict")
                ? JsonSerializer.Deserialize<Dictionary<string, BC>>(Properties["UserBCsDict"] as string)
                : new Dictionary<string, BC>
                {
                    ["3"] = new BC
                    {
                        Id = "3",
                        Data = Data.CurrentUser.Data,
                        Flags = new DataFlags(Data.CurrentUser.Data)
                    },
                    ["4"] = new BC
                    {
                        Id = "4",
                        Data = Data.CurrentUser.Data,
                        Flags = new DataFlags(Data.CurrentUser.Data)
                    },
                };
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}