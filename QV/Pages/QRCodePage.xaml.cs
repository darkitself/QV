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
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodePage
    {
        private readonly MobileBarcodeScanningOptions options = new MobileBarcodeScanningOptions
                                                       {
                                                           AutoRotate = true,
                                                           TryHarder = true,
                                                           TryInverted = true,
                                                           PossibleFormats = new[] {BarcodeFormat.QR_CODE}
                                                       };
        private readonly QrCodeEncodingOptions qrCodeEncodingOptions = new QrCodeEncodingOptions
                                                                {
                                                                    Height = 300,
                                                                    Width = 300,
                                                                    PureBarcode = true
                                                                };

        public QRCodePage()
        {
            InitializeComponent();
            Scanner.IsTorchOn = false;
            Overlay.IsVisible = false;
            Scanner.Options = options;
            Scanner.IsAnalyzing = false;
            Scanner.IsScanning = false;
            Scanner.IsVisible = false;
            Scanner.OnScanResult += OnScanResult;
            QRCode.BarcodeOptions = qrCodeEncodingOptions;
        }

        private void OnScanResult(Result result)
        {
            DisplayAlert("Result:", result.Text, "Ok");
            //ToDo message to user than scanning is success 
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Scanner.IsVisible = true;
            Scanner.IsScanning = true;
            Overlay.IsVisible = true;
            Scanner.IsAnalyzing = true;
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