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
    public partial class AllAliensBCsPage
    {
        private readonly ObservableCollection<BC> Items  = new ObservableCollection<BC>();
        public AllAliensBCsPage()
        {
            InitializeComponent();
            MyListView.ItemsSource = Items;
        }
        
        protected override void OnAppearing()
        {
            Items.Clear();
            App.Data.AliensBCs.Values.ForEach(e => Items.Add(e));
        }

        private void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var current = e.CurrentItem as BC;
        }

        private void ImageButton_OnClicked(object sender, EventArgs e)
        {
            //ToDo navigate to DetailsPage
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            
        }
    }
}