using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moving_App_v2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAccountPage : ContentPage
    {
        public NewAccountPage()
        {
            InitializeComponent();
        }

        private void PasswordCheckEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string password = PasswordCreateEntry.Text;
            if (PasswordCheckEntry.Text != password) ErrorMessages.Text = "Passwords Do Not Match";
        }
    }
}