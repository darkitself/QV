using QV.Infrastructure;
using QV.RequestsAndAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDataPage : ContentPage
    {
        User user;
        public UserDataPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            user = App.Data.CurrentUser;
            BindingContext = user.MainData;
        }
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var newReq = new UpdateUserDataRequest
            {
                User_ID = App.Data.CurrentUser.ID,
                Image = user.MainData.Image,
                Image_Ext = user.MainData.Image_Ext
            };

            foreach (var p in newReq.GetType().GetProperties())
            {
                var entry = this.FindByName<InputView>(p.Name);
                if (entry != null)
                    p.SetValue(newReq, entry.Text);
            }

            var res = Connection.RequestToServer<UpdateUserDataRequest, UpdateUserDataAnswer>(newReq, RequestsTypes.ChangeUserData);
            if (res.Result)
            {
                foreach (var p in user.MainData.GetType().GetProperties())
                    p.SetValue(user.MainData, newReq.GetType().GetProperty(p.Name).GetValue(newReq));
                await DisplayAlert("", "Данные успешно изменены", "OK");
            }
            else await DisplayAlert("", "Чёт не так", "OK");
        }
    }
}