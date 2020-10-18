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
    [QueryProperty(nameof(BCId), nameof(BCId))]
    public partial class BCDetailsPage : ContentPage
    {
        private string id;
        private BC Bc { get; set; }
        public string BCId
        {
            get => id;
            set
            {
                Bc = (App.Current.Properties["AlienBCsDict"] as Dictionary<string, BC>)[value];
                id = value;
                SetAllProperties();
            }
        }

        private void SetAllProperties()
        {
            Text.Text = Bc.Text;
        }

        public BCDetailsPage()
        {
            InitializeComponent();
        }
    }
}