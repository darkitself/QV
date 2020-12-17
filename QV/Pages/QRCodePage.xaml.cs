using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodePage
    {
        private bool isSecondPageActive = true;
        public QRCodePage()
        { 
            InitializeComponent();
            Scanner.IsAnalyzing = false;
            Scanner.IsScanning = false;
            Scanner.IsVisible = false;
            Scanner.Options = MobileBarcodeScanningOptions.Default;
            Overlay.IsVisible = false;
            Scanner.OnScanResult += OnScanResult;
            CurrentCard.ItemsSource = Items;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Items.Clear();
            App.Data.UserCards.Values.ForEach(c => Items.Add(c));
            CreateQR(); 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Refresh();
        }


        public void Refresh()
        {
            var encoder = new Encoder();
            var encoderRes = encoder.Encode("Egor was here!!", CorrectionLevel.H);
        public void CreateQR(string data = null)
        {
            var encoder = new Encoder();
            var encoderRes = encoder.Encode(data ?? "", CorrectionLevel.H);
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
            DependencyService.Get<ICanMakeToast>().MakeToast("Готово");
            // GetDataByLink(result.Text);
        }

        private void GetDataByLink_OnClicked(object sender, EventArgs e)
        {
            GetDataByLink(LinkRequest.Text);
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
                    .RequestToServer<GetCardRequest, GetCardAnswer
                    >(new GetCardRequest {User_ID = App.Data.CurrentUser.ID, Card_ID = Convert.ToInt64(link)},
                      RequestsTypes.ReceiveCard);
            if (!answer.Result)
            {
                DependencyService.Get<ICanMakeToast>().MakeToast("Карточка не существует");
                return;
            }

            App.Data.AliensCards[answer.Card.ID] = answer.Card;
            DependencyService.Get<ICanMakeToast>().MakeToast("Карточка получена");
        }

        private void PageChanged(object sender, EventArgs e)
        {
            isSecondPageActive = !isSecondPageActive;
            if (isSecondPageActive)
            {
                Scanner.IsScanning = true;
                Overlay.IsVisible = true;
                Scanner.IsVisible = true;
                Scanner.IsAnalyzing = true;
            }
            else
            {
                Scanner.IsScanning = false;
                Overlay.IsVisible = false;
                Scanner.IsVisible = false;
                Scanner.IsAnalyzing = false;
            }
        }

        private void CurrentCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Link.Text = ((UserCard)CurrentCard.ItemsSource[CurrentCard.SelectedIndex]).ID.ToString();
            CreateQR(Link.Text);
        }
    }
}