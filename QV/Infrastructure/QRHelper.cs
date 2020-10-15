using System.Threading.Tasks;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QV.Infrastructure
{
    public static class QRHelper
    {
        public static readonly QrCodeEncodingOptions Options = new QrCodeEncodingOptions
                                                               {
                                                                   Height = 300,
                                                                   Width = 300,
                                                                   PureBarcode = true
                                                               };
        
        public static Task<Result> Scan()
        {
            var scanner = new MobileBarcodeScanner();
            return scanner.Scan();
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