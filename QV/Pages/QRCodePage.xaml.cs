using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QV.Infrastructure;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
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
    }
}