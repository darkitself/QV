using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(Bc), nameof(Bc))]
    public partial class BCDetailsPage : ContentPage
    {
        public string Bc
        {
            set 
            {
                bc = JsonSerializer.Deserialize<BC>(value.Replace("%7B", "{").Replace("%22", "\"").Replace("%7D", "}"));
                BindingContext = bc;
                InitializeComponent();
            }
        }
        private BC bc { get; set; }
        public BCDetailsPage()
        {
        }
    }
}