using System;
using System.Text.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(Bc), nameof(Bc))]
    public partial class BCDetailsPage : ContentPage
    {
        public string Bc
        {
            set 
            {
                bc = JsonSerializer.Deserialize<BC>(value.Replace("%7B", "{")
                                                         .Replace("%22", "\"")
                                                         .Replace("%7D", "}"));
                BindingContext = bc;
                InitializeComponent();
            }
        }
        private BC bc { get; set; }
        public BCDetailsPage()
        {
        }

        private async void MailButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(new Uri($"mailto:{bc.Data.Email}"));
        }

        private async void TelephoneButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync($"tel:{bc.Data.TelephoneNumber}");
        }

        private async void FacebookButtonClicked(object sender, EventArgs e)
        {
            if (await Launcher.CanOpenAsync("fb://"))
                await Launcher.OpenAsync(new Uri($"fb://page/{bc.Data.FaceBookLink}"));
            else
                await Launcher.OpenAsync(bc.Data.FacebookReference);
        }

        private async void VkButtonClicked(object sender, EventArgs e)
        {
            if (await Launcher.CanOpenAsync("vk://"))
                await Launcher.OpenAsync($"vk://vk.com/{bc.Data.VKLink}");
            else
                await Launcher.OpenAsync(bc.Data.VkReference);
        }

        private async void FacebookCopy(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(bc.Data.FacebookReference);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопировано");

        }

        private async void VkCopy(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(bc.Data.VkReference);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопировано");

        }

        private async void EmailCopy(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(bc.Data.Email);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопировано");

        }

        private async void NumberCopy(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(bc.Data.TelephoneNumber);
            DependencyService.Get<ICanMakeToast>().MakeToast("Скопировано");
        }
    }
}