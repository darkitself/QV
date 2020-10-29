using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            RightImage.Source = ImageSource.FromResource("QV.Images.success (1).png");
            WrongImage.Source = ImageSource.FromResource("QV.Images.cross.png");

        }

        private void RegisterButtonClicked(object sender, EventArgs e)
        {
            
            //TODO registratipon
        }


        private void ConfirmPasswordOnCompleted(object sender, EventArgs e)
        {
            if (sender is Entry entry && entry.Text.Length != 0)
            {
                if (IsConfirmPasswordRight())
                {
                    WrongImage.IsVisible = false;
                    RightImage.IsVisible = true;
                }

                else
                {
                    RightImage.IsVisible = false;
                    WrongImage.IsVisible = true;
                }
            }
            else
            {
                RightImage.IsVisible = false;
                WrongImage.IsVisible = false;
            }
        }

        private bool IsConfirmPasswordRight()
        {
            return Password.Text.Equals(ConfirmPassword.Text);
        }
    }
}