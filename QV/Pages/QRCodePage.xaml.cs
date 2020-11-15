using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QV.Infrastructure;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodePage : ContentPage
    {
        public QRCodePage()
        {
            InitializeComponent();
            Overlay.ShowFlashButton = true;
            Overlay.IsVisible = false;
            Scanner.Options = new MobileBarcodeScanningOptions
                              {
                                  AutoRotate = true,
                                  TryHarder = true,
                                  TryInverted = true
                              };
            Scanner.IsAnalyzing = false;
            Scanner.IsScanning = false;
            Scanner.IsVisible = false;
            Scanner.OnScanResult += result =>
                                    {
                                        Scanner.IsTorchOn = !Scanner.IsTorchOn;
                                        Scanner.IsVisible = false;
                                        Button.Text = result.Text;
                                    };
            Overlay.FlashButtonClicked += (sender, args) => Scanner.ToggleTorch();

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            Scanner.IsVisible = true;
            Scanner.IsAnalyzing = true;
            Scanner.IsScanning = true;
        }
    }
}