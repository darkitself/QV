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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        private void RegistrationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrationPage());
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}