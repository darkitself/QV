using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllAliensBCsPage
    {
        private readonly ObservableCollection<BC> items  = new ObservableCollection<BC>();
        public AllAliensBCsPage()
        {
            InitializeComponent();
            ListView.ItemsSource = items;
        }
        
        protected override void OnAppearing()
        {
            items.Clear();
            App.Data.AliensBCs.Values.ForEach(e => items.Add(e));
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView.SelectedItem = null;
        }
    }
}