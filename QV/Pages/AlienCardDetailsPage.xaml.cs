using QV.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(CardId), nameof(CardId))]
    public partial class AlienCardDetailsPage : ContentPage
    {
        public string CardId
        {
            set 
            {
                BindingContext = App.Data.AliensCards[Convert.ToInt64(value)];
                Title = App.Data.AliensCards[Convert.ToInt64(value)].Card_Name;
                InitializeComponent();
            }
        }
        public AlienCardDetailsPage()
        {
        }
    }
}