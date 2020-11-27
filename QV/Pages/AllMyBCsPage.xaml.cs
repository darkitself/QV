using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllMyBCsPage : ContentPage
    {
        private readonly ObservableCollection<BC> items = new ObservableCollection<BC>();
        public Dictionary<string, string> BCs { get; set; } = new Dictionary<string, string>();
        public AllMyBCsPage()
        {
            InitializeComponent();
            ListView.ItemsSource = items;
        }
        
        protected override void OnAppearing()
        {
            items.Clear();
            App.Data.UserBCs.Values.ForEach(e => items.Add(e));
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            await Shell.Current.GoToAsync($"{nameof(BCDetailsPage)}?{nameof(BCDetailsPage.Bc)}={JsonSerializer.Serialize(App.Data.UserBCs[(e.Item as BC).Id])}");
        }
    }
}