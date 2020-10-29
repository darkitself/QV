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
    public partial class RegistrationPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            Image.Source = ImageSource.FromResource("QV.Images.qvlogo.png");
        }

        private void RegisterButtonClicked(object sender, EventArgs e)
        {
            
            //TODO registratipon
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}