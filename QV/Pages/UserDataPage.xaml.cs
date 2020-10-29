using QV.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDataPage : ContentPage
    {
        public UserDataPage()
        {
            BindingContext = (App.Current.Properties["User"] as User).Data;
            InitializeComponent();
        }
        private void SaveButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}