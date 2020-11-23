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
using QV.Infrastructure;
using QV.Pages;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllUserCardsPage : ContentPage
    {
        public ObservableCollection<UserCard> Items { get; set; } = new ObservableCollection<UserCard>();
        public AllUserCardsPage()
        {
            InitializeComponent();

            MyListView.ItemsSource = Items;
        }
        protected override void OnAppearing()
        {
            Items.Clear();
            App.Data.UserCards.Values.ForEach(e => Items.Add(e));
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            await Shell.Current.GoToAsync($"{nameof(UserCardDetailsPage)}?{nameof(UserCardDetailsPage.CardId)}={(e.Item as UserCard).ID}");
        }
    }
}