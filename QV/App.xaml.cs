using QV.Infrastructure;
using System.Collections.Generic;
using System.Text.Json;
using Xamarin.Forms;

namespace QV
{
    public partial class App 
    {
        public static AppData Data;
        public App()
        {
            Resources["BackgroundImageSource"] = "m.jpg";
            Data = new AppData();
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Data.CurrentUser = new User
            {
                ID = 1,
                MainData = new UserData
                {
                    Surname = "UserSurname",
                    Name = "UserName",
                    Patronymic = "UserPatronymic",
                    Email = "UserEmail",
                    Phone_Number = "UserPhone_Number",
                    Telegram = "UserTelegram",
                    VK = "UserVK",
                    Facebook = "UserFacebook",
                    Instagram = "UserInstagram",
                    Info = "UserInfo",
                }
            };

            Data.AliensCards = new Dictionary<long, AlienCard>
                {
                    [1] = new AlienCard
                    {
                        Id = "1",
                        Data = new UserData
                        {
                            Name = "Egor",
                            Surname = "Chusov",
                            Email = "chusoveg17@gmail.com",
                            FaceBookLink = "zuck",
                            MiddleName = "Alekseevich",
                            TelephoneNumber = "89014354863",
                            VKLink = "egorchusov"
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
                    [2] = new AlienCard
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

            Data.UserCards = new Dictionary<long, UserCard>
                {
                    [3] = new UserCard
                    {
                        ID = 3,
                        Card_Name = "My 3 Card",
                        Alt_Data = false,
                        Surname = true,
                        Name = true,
                        Patronymic = true,
                        Image = false,
                        Email = true,
                        Phone_Number = false,
                        Telegram = true,
                        VK = false,
                        Facebook = true,
                        Instagram = false,
                        Info = true,
                    },
                [4] = new UserCard
                {
                    ID = 4,
                    Card_Name = "My 4 Card",
                    Alt_Data = false,
                    Surname = true,
                    Name = true,
                    Patronymic = false,
                    Image = false,
                    Email = true,
                    Phone_Number = false,
                    Telegram = true,
                    VK = false,
                    Facebook = true,
                    Instagram = false,
                    Info = true,
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