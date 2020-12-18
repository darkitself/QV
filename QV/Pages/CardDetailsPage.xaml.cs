using QV.Infrastructure;
using QV.RequestsAndAnswers;
using QV.CustomElements;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(CardId), nameof(CardId))]
    public partial class CardDetailsPage : ContentPage
    {
        private string CardName;
        private long Type;
        private long ID;

        public string CardId
        {
            set
            {
                Type = Convert.ToInt64(value[0]);
                ID = Convert.ToInt64(value.Remove(0, 1));
                if (Type - 48 == 0)
                {
                    var card = App.Data.AliensCards[ID];
                    var data = new UserData();
                    Title = CardName = card.Card_Name;
                    foreach (var p in data.GetType().GetProperties())
                        p.SetValue(data, card.GetType().GetProperty(p.Name).GetValue(card));
                    userData = data;
                    BindingContext = this;
                    InitializeComponent();
                }

                if (Type - 48 == 1)
                {
                    var card = App.Data.UserCards[ID];
                    var tData = card.Alt_Data
                        ? App.Data.CurrentUser.AltData
                        : App.Data.CurrentUser.MainData;
                    var data = new UserData();
                    Title = CardName = card.Card_Name;
                    foreach (var p in data.GetType().GetProperties())
                        if (p.Name != "Image_Ext" && p.Name != "ImageStream" &&
                            (bool) card.GetType().GetProperty(p.Name).GetValue(card))
                            p.SetValue(data, tData.GetType().GetProperty(p.Name).GetValue(tData));
                    userData = data;
                    BindingContext = this;
                    InitializeComponent();
                }
            }
        }

        public UserData userData { get; set; }
        public CardDetailsPage()
        {
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var newName = await DisplayPromptAsync("Enter new name: ", "");
            if (newName != null)
            {
                if (Type == 0)
                {
                    var result = Connection
                        .RequestToServer<ChangeReceivedCardNameRequest, ChangeReceivedCardNameAnswer>
                            (new ChangeReceivedCardNameRequest {Card_ID = ID, Card_Name = newName, User_ID = App.Data.CurrentUser.ID},
                             RequestsTypes.ChangeReceivedCardName);
                    if (result.Success)
                        Title = App.Data.AliensCards[ID].Card_Name = newName;
                }

                if (Type == 1)
                {
                    var result = Connection
                        .RequestToServer<ChangeUserCardNameRequest, ChangeUserCardNameAnswer>
                            (new ChangeUserCardNameRequest {ID = ID, Card_Name = newName},
                             RequestsTypes.ChangeUserCardName);
                    if (result.Success)
                        Title = App.Data.AliensCards[ID].Card_Name = newName;
                }
            }
        }

        private async void EmailButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(new Uri($"mailto:{userData.Email}"));
        }

        private async void EmailButtonLongPress(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(userData.Email);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопирована почта");
        }

        private async void TelephoneButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync($"tel:{userData.Phone_Number}");
        }

        private async void TelephoneButtonLongPress(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(userData.Phone_Number);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопирован номер");
        }

        private async void FacebookButtonClicked(object sender, EventArgs e)
        {
            if (await Launcher.CanOpenAsync("fb://"))
                await Launcher.OpenAsync(new Uri($"fb://page/{userData.Facebook}"));
            else
                await Launcher.OpenAsync($"https://ru-ru.facebook.com/{userData.Facebook}");
        }

        private async void FacebookButtonLongPress(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(userData.Facebook);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопирован facebook");
        }

        private async void VkButtonClicked(object sender, EventArgs e)
        {
            if (await Launcher.CanOpenAsync("vk://"))
                await Launcher.OpenAsync($"vk://vk.com/{userData.VK}");
            else
                await Launcher.OpenAsync($"https://vk.com/{userData.VK}");
        }

        private async void VkButtonLongPress(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(userData.VK);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопирован VK");
        }

        private async void TelegramButtonClicked(object sender, EventArgs e)
        {
            if (await Launcher.CanOpenAsync("tg://"))
                await Launcher.OpenAsync($"tg://{userData.Telegram}");
            else
                await Launcher.OpenAsync($"https://t.me/{userData.Telegram}");
        }

        private async void TelegramButtonLongPress(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(userData.Telegram);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопирован telegram");
        }

        private async void InstagramButtonClicked(object sender, EventArgs e)
        {
            if (await Launcher.CanOpenAsync("in://"))
                await Launcher.OpenAsync($"in://{userData.Instagram}");
            else
                await Launcher.OpenAsync($"https://www.instagram.com/{userData.Instagram}/");
        }

        private async void InstagramButtonLongPress(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(userData.Instagram);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопирован Instagram");
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            DependencyService.Get<IContactSaver>().SaveContact(userData);
        }
    }
}