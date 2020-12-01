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
using QV.RequestsAndAnswers;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllAliensCardsPage : ContentPage
    {
        public ObservableCollection<AlienCard> Items { get; set; } = new ObservableCollection<AlienCard>();
        public AllAliensCardsPage()
        {
            InitializeComponent();

            MyListView.ItemsSource = Items;
        }
        protected override void OnAppearing()
        {
            Items.Clear();
            App.Data.AliensCards.Values.ForEach(e => Items.Add(e));
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            await Shell.Current.GoToAsync($"{nameof(AlienCardDetailsPage)}?{nameof(AlienCardDetailsPage.CardId)}={(e.Item as AlienCard).ID}");
        }

        private void DelButton_Clicked(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            var card = button.BindingContext as AlienCard;
            var answer = Connection.RequestToServer<DeleteAlienCardRequest, DeleteAnswer>(new DeleteAlienCardRequest() { User_ID = App.Data.CurrentUser.ID, Card_ID = card.ID }, RequestsTypes.DeleteReceivedCard);
            if (answer.Result)
            {
                App.Data.AliensCards.Remove(card.ID);
                Items.RemoveAt(Items.IndexOf(card));
            }
        }
    }
}