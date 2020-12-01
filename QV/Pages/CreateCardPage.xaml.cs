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
    public partial class CreateCardPage : ContentPage
    {
        UserData data = null;
        public CreateCardPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            data = App.Data.CurrentUser.MainData;
            foreach (var p in data.GetType().GetProperties())
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                if (checkBox != null)
                    checkBox.IsEnabled = p.GetValue(data) != null && p.GetValue(data) as string != "";
            }
        }
        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.BCName.Text))
            {
                var bc = new UserCard() { Card_Name = this.BCName.Text };
                var req = new CreateCardRequest() { Card_Name = this.BCName.Text, User_ID = App.Data.CurrentUser.ID };
                foreach (var p in bc.GetType().GetProperties())
                {
                    var checkBox = this.FindByName<CheckBox>(p.Name);
                    if (checkBox != null)
                    {
                        p.SetValue(bc, checkBox.IsEnabled && checkBox.IsChecked);
                        req.GetType().GetProperty(p.Name).SetValue(req, checkBox.IsEnabled && checkBox.IsChecked);
                    }
                }
                var res = Connection.RequestToServer<CreateCardRequest, CreateCardAnswer>(req, RequestsTypes.CreateUserCard);
                App.Data.UserCards[bc.ID = res.ID] = bc;
            }
        }
        private void SelectAllButton_Clicked(object sender, EventArgs e)
        {
            foreach (var p in data.GetType().GetProperties())
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                if (checkBox != null)
                    if (checkBox.IsEnabled)
                        checkBox.IsChecked = true;
            }
        }
        private void DeselctAllButton_Clicked(object sender, EventArgs e)
        {
            foreach (var p in data.GetType().GetProperties())
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                if (checkBox != null)
                    if (checkBox.IsEnabled)
                        checkBox.IsChecked = false;
            }
        }
    }
}