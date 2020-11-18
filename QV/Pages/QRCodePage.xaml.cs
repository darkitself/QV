using System;
using QV.Infrastructure;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QV
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
    }
}