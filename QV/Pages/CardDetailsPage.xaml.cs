using QV.Infrastructure;
using QV.RequestsAndAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(CardId), nameof(CardId))]
    public partial class CardDetailsPage : ContentPage
    {
        private string CardName;
        private long Type;
        private long ID;
        public string CardId
        {
            set
            {
                Type = Convert.ToInt64(value[0]);
                ID = Convert.ToInt64(value.Remove(0, 1));
                if (Type - 48 == 0)
                {
                    var card = App.Data.AliensCards[ID];
                    var data = new UserData();
                    Title = CardName = card.Card_Name;
                    foreach (var p in data.GetType().GetProperties())
                        p.SetValue(data, card.GetType().GetProperty(p.Name).GetValue(card));
                    BindingContext = data;
                    InitializeComponent();
                }
                if (Type - 48 == 1)
                {
                    var card = App.Data.UserCards[ID];
                    var tData = card.Alt_Data ? App.Data.CurrentUser.AltData : App.Data.CurrentUser.MainData;
                    var data = new UserData();
                    Title = CardName = card.Card_Name;
                    foreach (var p in data.GetType().GetProperties())
                        if (p.Name != "Image_Ext" && (bool)card.GetType().GetProperty(p.Name).GetValue(card))
                            p.SetValue(data, tData.GetType().GetProperty(p.Name).GetValue(tData));
                    BindingContext = data;
                    InitializeComponent();
                }
            }
        }

        public CardDetailsPage()
        {
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var newName = await DisplayPromptAsync("Enter new name: ", "");
            if (newName != null)
            {
                if (Type == 0)
                {
                    var result = Connection.RequestToServer<ChangeReceivedCardNameRequest, ChangeReceivedCardNameAnswer>
                        (new ChangeReceivedCardNameRequest { Card_ID = ID, Card_Name = newName, User_ID = App.Data.CurrentUser.ID }, RequestsTypes.ChangeReceivedCardName);
                    if (result.Success)
                        Title = App.Data.AliensCards[ID].Card_Name = newName;
                }
                if (Type == 1)
                {
                    var result = Connection.RequestToServer<ChangeUserCardNameRequest, ChangeUserCardNameAnswer>
                        (new ChangeUserCardNameRequest { ID = ID, Card_Name = newName }, RequestsTypes.ChangeUserCardName);
                    if (result.Success)
                        Title = App.Data.AliensCards[ID].Card_Name = newName;
                }
            }
        }
    }
}