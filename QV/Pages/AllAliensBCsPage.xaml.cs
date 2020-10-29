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
    public partial class AllAliensBCsPage : ContentPage
    {
        public ObservableCollection<BC> Items { get; set; } = new ObservableCollection<BC>();
        public AllAliensBCsPage()
        {
            InitializeComponent();

            MyListView.ItemsSource = Items;
        }
        protected override void OnAppearing()
        {
            Items.Clear();
            JsonSerializer.Deserialize<Dictionary<string, BC>>(App.Current.Properties["AlienBCsDict"] as string).ForEach(e => Items.Add(e.Value));
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            await Shell.Current.GoToAsync($"{nameof(BCDetailsPage)}?{nameof(BCDetailsPage.Dict)}={"AlienBCsDict"}&{nameof(BCDetailsPage.BCId)}={(e.Item as BC).Id}");
        }
    }
}