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
        }

        protected override void OnAppearing()
        {
            data = App.Data.CurrentUser.Data;
            foreach (var p in data.GetType().GetProperties())
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                checkBox.IsEnabled = p.GetValue(data) != null && p.GetValue(data) as string != "";
            }
        }
        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            var bc = new BC() { Id = this.BCName.Text, Data = data, Flags = new DataFlags()};
            foreach (var p in bc.Flags.GetType().GetProperties())
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                p.SetValue(bc.Flags, checkBox.IsEnabled && checkBox.IsChecked);
            }
            App.Data.UserBCs[bc.Id] = bc;
            Application.Current.Properties["UserBCsDict"] = JsonSerializer.Serialize(App.Data.UserBCs);
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

        private void BCName_Unfocused(object sender, FocusEventArgs e)
        {
            this.CreateButton.Text = App.Data.UserBCs.ContainsKey(this.BCName.Text) ? "Save" : "Create";
        }
    }
}