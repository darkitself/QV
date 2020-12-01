using QV.Infrastructure;
using QV.RequestsAndAnswers;
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
                Title = ((AlienCard)BindingContext).Card_Name;
                InitializeComponent();
            }
        }
        public AlienCardDetailsPage()
        {
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var newName = await DisplayPromptAsync("Enter new name: ", "");
            if (newName != null)
            {
                var result = Connection.RequestToServer<ChangeReceivedCardNameRequest, ChangeReceivedCardNameAnswer>
                    (new ChangeReceivedCardNameRequest { Card_ID = ((AlienCard)BindingContext).ID, Card_Name = newName, User_ID = App.Data.CurrentUser.ID }, RequestsTypes.ChangeReceivedCardName);
                if (result.Success)
                    ((AlienCard)BindingContext).Card_Name = newName;
            }
        }
    }
}