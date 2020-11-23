using QV.Infrastructure;
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
                BindingContext = new localUserCard { Data = card.Alt_Data ? App.Data.CurrentUser.AltData : App.Data.CurrentUser.MainData, Flags = card };
                Title = card.Card_Name;
                InitializeComponent();
            }
        }
        public UserCardDetailsPage()
        {
        }
    }
}