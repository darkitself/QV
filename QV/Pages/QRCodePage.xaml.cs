using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using QRCodeEncoder;
using QV.Infrastructure;
using QV.RequestsAndAnswers;
using SkiaSharp;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using Encoder = QV.Infrastructure.Encoder;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodePage
    {
        private bool isScannerOpen = false;
        private readonly MobileBarcodeScanningOptions options = new MobileBarcodeScanningOptions
                                                                {
                                                                    AutoRotate = true,
                                                                    TryHarder = true,
                                                                    DisableAutofocus = false,
                                                                    UseNativeScanning = false,
                                                                    TryInverted = true,
                                                                    PossibleFormats = new []
                                                                        {
                                                                            BarcodeFormat.QR_CODE
                                                                        }
                                                                };
        public ObservableCollection<UserCard> Items { get; set; } =
            new ObservableCollection<UserCard>();

        public QRCodePage()
        {
            InitializeComponent();
            CurrentCard.ItemsSource = Items;
            CreateQR();
        }

        protected override bool OnBackButtonPressed()
        {
            if (isScannerOpen)
            {
                isScannerOpen = false;
                Navigation.PopModalAsync();
            }
            return base.OnBackButtonPressed();
        }

        protected override void OnAppearing()
        {
            Items.Clear();
            App.Data.UserCards.Values.ForEach(c => Items.Add(c));
            base.OnAppearing();
        }

        public void CreateQR(string data = null)
        {
            var encoder = new Encoder();
            var encoderRes = encoder.Encode(data ?? "", CorrectionLevel.H);
            var renderer = new QrRenderer();
            var qrCodeImgStream = renderer.Draw(encoderRes.Data,
                                                encoderRes.Version,
                                                CorrectionLevel.H,
                                                SKColors.Black,
                                                new SKColor(239, 51, 36));
            QRImage.Source = ImageSource.FromStream(() => new BufferedStream(qrCodeImgStream));
        }

        private void OnScanResult(Result result)
        {
            isScannerOpen = false;
            Navigation.PopModalAsync();
            GetDataByLink(result.Text);
        }

        private void GetDataByLink_OnClicked(object sender, EventArgs e)
        {
            GetDataByLink(LinkEntry.Text);
        }

        private void GetDataByLink(string link)
        {
            var id = Convert.ToInt64(link);
            if (App.Data.AliensCards.ContainsKey(id))
            {
                DependencyService.Get<ICanMakeToast>().MakeToast("У вас уже есть эта карточка");
                return;
            }

            var answer =
                Connection
                    .RequestToServer<GetCardRequest, GetCardAnswer>(new GetCardRequest {User_ID = App.Data.CurrentUser.ID, Card_ID = Convert.ToInt64(link)},
                          RequestsTypes.ReceiveCard);
            if (!answer.Result)
            {
                DependencyService.Get<ICanMakeToast>().MakeToast("Карточка не существует");
                return;
            }

            App.Data.AliensCards[answer.Card.ID] = answer.Card;
            DependencyService.Get<ICanMakeToast>().MakeToast("Карточка получена");
        }

        private void CurrentCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentCard.SelectedIndex != -1)
            {
                CreateQR(((UserCard)CurrentCard.ItemsSource[CurrentCard.SelectedIndex]).ID.ToString());
            }
        }

        private async void ScanButton_OnClicked(object sender, EventArgs e)
        {
            var page = new ZXingScannerPage(options);
            page.IsAnalyzing = true;
            page.IsScanning = true;
            page.OnScanResult += OnScanResult;
            await Navigation.PushModalAsync(page);
            isScannerOpen = true;
        }

        private async void CopyLinkButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentCard.SelectedIndex == -1)
            {
                DependencyService.Get<ICanMakeToast>().MakeToast("Визитка не выбрана");
                return;
            }
            await Clipboard.SetTextAsync(((UserCard)CurrentCard.ItemsSource[CurrentCard.SelectedIndex]).ID.ToString());
            DependencyService.Get<ICanMakeToast>().MakeToast("Ссылка скопирована");
        }
    }
}