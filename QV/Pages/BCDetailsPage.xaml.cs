﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(BCId), nameof(BCId))]
    public partial class BCDetailsPage : ContentPage
    {
        private string id;
        private BC Bc { get; set; }
        public string BCId
        {
            get => id;
            set
            {
                Bc = (App.Current.Properties["AlienBCsDict"] as Dictionary<string, BC>)[value];
                id = value;
                SetAllProperties();
            }
        }

        private void SetAllProperties()
        {
            var a = this.GetType().GetFields().ToArray();
            foreach (var p in Bc.GetType().GetProperties().Where(p => p.Name != "Id"))
            {
                var label = this.FindByName<Label>(p.Name);
                label.Text = (string)p.GetValue(Bc);
                label.IsVisible = label.Text != null;
            }
        }

        public BCDetailsPage()
        {
            InitializeComponent();
        }
    }
}