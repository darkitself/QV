using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QV.Infrastructure;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QV
{
    public partial class MainPage : ContentPage
    {
        public Action<object, EventArgs> handler { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            handler(sender, e);
        }
    }
}
