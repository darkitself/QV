using QV.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private UserData data = null;
        private readonly List<PropertyInfo> properties;
        public CreateBCPage()
        {
            InitializeComponent();
            properties = typeof(UserData)
                         .GetProperties()
                         .Where(x => x.SetMethod != null)
                         .ToList();
        }

        protected override void OnAppearing()
        {
            data = App.Data.CurrentUser.Data;
            foreach (var p in properties)
            {
                var checkBox = this.FindByName<CheckBox>(p.Name);
                checkBox.IsEnabled = p.GetValue(data) != null && p.GetValue(data) as string != "";
            }
        }
        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(BCName.Text))
                return;
            var bc = new BC() { Id = BCName.Text, Data = data, Flags = new DataFlags()};
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
            SetFlagToAllCheckBox(true);
        }
        
        private void DeselctAllButton_Clicked(object sender, EventArgs e)
        {
            SetFlagToAllCheckBox(false);
        }

        private void SetFlagToAllCheckBox(bool flag)
        {
            foreach (var checkBox in properties.Select(p => this
                                                           .FindByName<CheckBox>(p.Name))
                                               .Where(checkBox => checkBox != null && checkBox.IsEnabled))
                checkBox.IsChecked = flag;
        }
        
    }
}