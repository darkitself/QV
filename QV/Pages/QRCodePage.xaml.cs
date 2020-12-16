using System;
using System.IO;
using QRCodeEncoder;
using QV.Infrastructure;
using QV.RequestsAndAnswers;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Mobile;
using ZXing.QrCode;
using Encoder = QV.Infrastructure.Encoder;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodePage
    {
        private readonly MobileBarcodeScanningOptions options = new MobileBarcodeScanningOptions
                                                                {
                                                                    AutoRotate = true,
                                                                    TryHarder = true,
                                                                    DisableAutofocus = false,
                                                                    UseNativeScanning = true,
                                                                    TryInverted = true,
                                                                    PossibleFormats = new []
                                                                        {
                                                                            BarcodeFormat.QR_CODE
                                                                        }
                                                                };


        public QRCodePage()
        {
            InitializeComponent();
            Scanner.Options = options;
            Scanner.OnScanResult += OnScanResult;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Refresh(); 
        }

        public void Refresh()
        {
            var encoder = new Encoder();
            var encoderRes = encoder.Encode("Egor aws here!!!", CorrectionLevel.H);
            var renderer = new QrRenderer();
            var qrCodeImgStream = renderer.Draw(encoderRes.Data,
                                                encoderRes.Version,
                                                CorrectionLevel.H, 
                                                SKColors.Black,
                                                new SKColor(239,51,36));
            QRImage.Source = ImageSource.FromStream(() => new BufferedStream(qrCodeImgStream));
        }

        private void OnScanResult(Result result)
        {
            DependencyService.Get<ICanMakeToast>().MakeToast(result.Text);
            //ToDo message to user than scanning is success 
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Scanner.IsTorchOn = true;
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

            var answer =
                Connection
                    .RequestToServer<GetCardRequest, GetCardAnswer
                    >(new GetCardRequest {User_ID = App.Data.CurrentUser.ID, Card_ID = Convert.ToInt64(this.LinkRequest.Text)},
                      RequestsTypes.ReceiveCard);
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