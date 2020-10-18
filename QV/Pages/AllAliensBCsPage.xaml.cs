using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Items.Clear();
            (App.Current.Properties["AlienBCsDict"] as Dictionary<string, BC>).ForEach(e => Items.Add(e.Value));

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            await Shell.Current.GoToAsync($"{nameof(BCDetailsPage)}?{nameof(BCDetailsPage.BCId)}={(e.Item as BC).Id}");
        }
    }
}