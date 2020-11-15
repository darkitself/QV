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
            Overlay.ShowFlashButton = Scanner.HasTorch;
            Scanner.Options = new MobileBarcodeScanningOptions
                              {
                                  AutoRotate = true,
                                  PossibleFormats = new [] {BarcodeFormat.QR_CODE},
                                  TryHarder = true,
                                  TryInverted = true
                              };
            Scanner.IsAnalyzing = true;
            Scanner.IsScanning = true;
            Scanner.OnScanResult += result =>
                                    {
                                        Scanner.FadeTo(0, 250, Easing.BounceOut);
                                        Overlay.FadeTo(0, 250, Easing.BounceOut);
                                        Scanner.ToggleTorch();
                                    };
            Overlay.FlashButtonClicked += (sender, args) => Scanner.IsTorchOn = !Scanner.IsTorchOn;

        }
    }
}