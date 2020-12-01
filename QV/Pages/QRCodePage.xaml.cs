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
            var id = Convert.ToInt64(this.LinkRequest.Text);
            if (App.Data.AliensCards.ContainsKey(id))
            {
                await DisplayAlert("", "У вас уже есть эта карточка", "OK");
                return;
            }
            var answer = Connection.RequestToServer<GetCardRequest, GetCardAnswer>(new GetCardRequest { User_ID = App.Data.CurrentUser.ID, Card_ID = Convert.ToInt64(this.LinkRequest.Text) }, RequestsTypes.ReceiveCard);
            if (!answer.Result)
            {
                await DisplayAlert("", "Карточка не существует", "OK");
                return;
            }
            App.Data.AliensCards[answer.Card.ID] = answer.Card;
            await DisplayAlert("", "Карточка получена", "OK");
            return;
        }
    }
}