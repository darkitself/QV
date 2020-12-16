using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using QRCodeEncoder;
using QV.Infrastructure;
using QV.RequestsAndAnswers;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
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
        public ObservableCollection<UserCard> Items { get; set; } = new ObservableCollection<UserCard>();

        public QRCodePage()
        {
            InitializeComponent();
            CarouselView.ItemsSource = Items;
            Scanner.IsAnalyzing = true;
            Scanner.IsScanning = true;
            Scanner.OnScanResult += OnScanResult;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Items.Clear();
            App.Data.UserCards.Values.ForEach(e => Items.Add(e));
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
                DependencyService.Get<ICanMakeToast>().MakeToast( "Карточка не существует");
                return;
            }

            App.Data.AliensCards[answer.Card.ID] = answer.Card;
            DependencyService.Get<ICanMakeToast>().MakeToast( "Карточка получена");
        }

        private void ElementChanged(object sender, CurrentItemChangedEventArgs e)
        {
            QRImage.Source = (e.CurrentItem as UserCard)?.GetQrCodeSource();
        }
    }
}