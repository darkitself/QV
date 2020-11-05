using QV.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDataPage : ContentPage
    {
        User user;
        public UserDataPage()
        {
            user = App.Data.CurrentUser;
            BindingContext = user.Data;
            InitializeComponent();
        }
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            foreach (var p in user.Data.GetType().GetProperties())
            {
                var entry = this.FindByName<Entry>(p.Name);
                p.SetValue(user.Data, entry.Text);
            }
            App.Current.Properties["User"] = JsonSerializer.Serialize(user);
        }
    }
}