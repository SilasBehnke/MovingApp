using MAv3;
using MAv3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moving_App_Form_Version.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string loginStatus = "Searching...";
            LoginStatus.BindingContext = loginStatus;
            if (UsernameEntry.Text != null && PasswordEntry.Text != null)
            {
                UserCall serverCalls = new UserCall();
                string UserExist = serverCalls.ObjectExist(UsernameEntry.Text, PasswordEntry.Text);
                if (UserExist.Contains("True"))
                {
                    LoginStatus.Text = "Success";
                    return;
                }
                LoginStatus.Text = "Username or Password is incorrect";
            }
            else
            {
                LoginStatus.Text = "Username or Password is incorrect";
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewAccount());
        }
    }
}