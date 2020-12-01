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
    public partial class UserCardDetailsPage : ContentPage
    {
        private class localUserCard
        {
            public UserData Data { get; set; }
            public UserCard Flags { get; set; }
        }
        public string CardId
        {
            set
            {
                var card = App.Data.UserCards[Convert.ToInt64(value)];
                var conv = new Converter();
                var data = new localUserCard { Data = card.Alt_Data ? App.Data.CurrentUser.AltData : App.Data.CurrentUser.MainData, Flags = card };
                BindingContext = data;
                Title = ((localUserCard)BindingContext).Flags.Card_Name;
                InitializeComponent();
                foreach (var p in data.Data.GetType().GetProperties())
                {
                    var label = this.FindByName<Label>(p.Name);
                    if (label != null)
                        label.IsVisible = label.IsVisible && (bool)conv.Convert(p.GetValue(data.Data), typeof(bool));
                }
            }
        }
        public UserCardDetailsPage()
        {
        }
        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var newName = await DisplayPromptAsync("Enter new name: ", "");
            if (newName != null)
            {
                var result = Connection.RequestToServer<ChangeUserCardNameRequest, ChangeUserCardNameAnswer>
                    (new ChangeUserCardNameRequest { ID = ((localUserCard)BindingContext).Flags.ID, Card_Name = newName }, RequestsTypes.ChangeUserCardName);
                if (result.Success)
                    ((localUserCard)BindingContext).Flags.Card_Name = newName;
            }
        }
    }
}