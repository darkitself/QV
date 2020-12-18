using QV.Infrastructure;
using System.Collections.Generic;

namespace QV
{
    public partial class App
    {
        public static AppData Data;

        public App()
        {
            Resources["BackgroundImageSource"] = "m.jpg";
            Resources["Converter"] = new DataToBoolConverter();
            Data = new AppData();
            InitializeComponent();
            MainPage = new MainPage();
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
                    ID = 1,
                    Card_Name = "Мальчик красивый",
                    Name = "Egor",
                    Surname = "Chusov",
                    Email = "chusoveg17@gmail.com",
                    Facebook = "zuck",
                    Patronymic = "Alekseevich",
                    Phone_Number = "89014354863",
                    Telegram = "chusoveg",
                    Instagram = "chusoveg_",
                    VK = "egorchusov",
                    Info = "Эта инфа для тестов, смотрим и кайфуем"
                },
                [2] = new AlienCard
                {
                    ID = 2,
                    Name = "Zhenya",
                    Surname = "Kalygin",
                    Email = "Xz",
                    Phone_Number = "8800000000",
                    VK = "VKLink2"
                },
                [3] = new AlienCard
                {
                    ID = 2,
                    Name = "Stiv Jobs",
                    Email = "stivchik@",
                    VK = "!235"
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
                    Image = true,
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
                    Image = true,
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