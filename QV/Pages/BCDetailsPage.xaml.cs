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
    [QueryProperty(nameof(Dict), nameof(Dict))]
    [QueryProperty(nameof(BCId), nameof(BCId))]
    public partial class BCDetailsPage : ContentPage
    {
        private string id;
        private BC Bc { get; set; }
        public string Dict { get; set; }
        public string BCId
        {
            get => id;
            set
            {
                Bc = (App.Current.Properties[Dict] as Dictionary<string, BC>)[value];
                id = value;
                SetAllProperties();
            }
        }

        private void SetAllProperties()
        {
            foreach (var p in Bc.Data.GetType().GetProperties())
            {
                var label = this.FindByName<Label>(p.Name);
                label.Text = (string)p.GetValue(Bc.Data);
                label.IsVisible = label.Text != null;
            }
        }

        public BCDetailsPage()
        {
            InitializeComponent();
        }
    }
}