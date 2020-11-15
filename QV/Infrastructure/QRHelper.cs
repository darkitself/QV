using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QV.Infrastructure
{
    public static class QRHelper
    {
        private static readonly QrCodeEncodingOptions Options = new QrCodeEncodingOptions
                                                                {
                                                                    Height = 300,
                                                                    Width = 300,
                                                                    PureBarcode = true
                                                                };
        
        public static ZXingScannerView GetScannerView()
        {
            var scanner = new ZXingScannerView
                          {
                              Options = new MobileBarcodeScanningOptions
                                        {
                                            TryHarder = true,
                                            TryInverted = true,
                                            PossibleFormats =
                                                new[] {BarcodeFormat.QR_CODE}
                                        },
                              WidthRequest = 300,
                              HeightRequest = 300
                          };
            return scanner;
        }

        public static ZXingBarcodeImageView CreateQrCodeFrom<T>(T item)
        {
            var view = new ZXingBarcodeImageView
                       {
                           BarcodeFormat = BarcodeFormat.QR_CODE,
                           BarcodeValue = item.ToString(),
                           BarcodeOptions = Options,
                           HeightRequest = 500,
                           WidthRequest = 500,
                           IsVisible = true,
                       };
            return view;
        }
    }
}