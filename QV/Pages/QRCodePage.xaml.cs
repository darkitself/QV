using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using QV.Infrastructure;
using QV.RequestsAndAnswers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodePage : ContentPage
    {
        public QRCodePage()
        {
            InitializeComponent();
        }

        private async void StartScanning_OnClicked(object sender, EventArgs e)
        {
            var result = await QRHelper.Scan();
            QrScanningResult.Text = $"Результат сканирования:\n {result}";
        }
        private async void GetDataByLink_OnClicked(object sender, EventArgs e)
        {
            var card = Connection.RequestToServer<GetCardRequest, AlienCard>(new GetCardRequest { UserID = App.Data.CurrentUser.ID, CardID = Convert.ToInt64(this.LinkRequest.Text) }, "10");
            App.Data.AliensCards[card.ID] = card;
            await DisplayAlert("", "Карточка получена", "OK");
            return;
        }
    }
}