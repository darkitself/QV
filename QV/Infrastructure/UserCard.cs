using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using QRCodeEncoder;
using SkiaSharp;
using Xamarin.Forms;

namespace QV.Infrastructure
{
    public class UserCard
    {
        public long ID { get; set; }
        public string Card_Name { get; set; }
        public bool Alt_Data { get; set; }
        public bool Surname { get; set; }
        public bool Name { get; set; }
        public bool Patronymic { get; set; }
        public bool Image { get; set; }
        public bool Email { get; set; }
        public bool Phone_Number { get; set; }
        public bool Telegram { get; set; }
        public bool VK { get; set; }
        public bool Facebook { get; set; }
        public bool Instagram { get; set; }
        public bool Info { get; set; }
        
        public ImageSource GetQrCodeSource()
        {
            var encoder = new Encoder();
            var encoderRes = encoder.Encode("Egor was here!!!", CorrectionLevel.H);
            var renderer = new QrRenderer();
            var qrCodeImgStream = renderer.Draw(encoderRes.Data,
                                                encoderRes.Version,
                                                CorrectionLevel.H, 
                                                SKColors.Black,
                                                new SKColor(239,51,36));
            return ImageSource.FromStream(() => new BufferedStream(qrCodeImgStream));
        }
    }
}
