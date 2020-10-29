using QV.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateBCPage : ContentPage
    {
        UserData data = null;
        public CreateBCPage()
        {
            InitializeComponent();
            data = JsonSerializer.Deserialize<User>(App.Current.Properties["User"] as string).Data;
        }

        protected override void OnAppearing()
        {
            foreach (var p in data.GetType().GetProperties())
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                checkBox.IsEnabled = p.GetValue(data) != null;
            }
        }
        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            var dict = JsonSerializer.Deserialize<Dictionary<string, BC>>(App.Current.Properties["MyBCsDict"] as string);
            var bc = new BC() { Id = this.BCName.Text, Data = new UserData()};
            var t = bc.Data.GetType();
            foreach (var p in data.GetType().GetProperties())
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                if (checkBox.IsEnabled && checkBox.IsChecked)
                    t.GetProperty(p.Name).SetValue(bc.Data, p.GetValue(data));
            }
            dict[bc.Id] = bc;
            App.Current.Properties["MyBCsDict"] = JsonSerializer.Serialize(dict);
        }
        private void SelectAllButton_Clicked(object sender, EventArgs e)
        {
            foreach (var p in data.GetType().GetProperties())
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                if (checkBox.IsEnabled)
                    checkBox.IsChecked = true;
            }
        }
        private void DeselctAllButton_Clicked(object sender, EventArgs e)
        {
            foreach (var p in data.GetType().GetProperties())
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                if (checkBox.IsEnabled)
                    checkBox.IsChecked = false;
            }
        }
    }
}