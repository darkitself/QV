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
                        Card_Name = "1 Alien Card",
                        ID = 1,
                        Name = "Name1",
                        Surname = "Surname1",
                        Email = "Email1",
                        Instagram = "Inst1",
                        Phone_Number = "Phone_Number1",
                        VK = "VK1"
                    },
                    [2] = new AlienCard
                    {
                        Card_Name = "2 Alien Card",
                        ID = 2,
                        Name = "Name2",
                        Surname = "Surname2",
                        Email = "Email2",
                        Phone_Number = "TelephoneNumber2",
                        VK = "VKLink2"
                    },
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