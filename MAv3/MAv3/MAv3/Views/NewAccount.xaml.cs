using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAv3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAccount : ContentPage
    {
        bool PasswordDone = false;
        bool UsernameDone = false;
        public NewAccount()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (UsernameEntry.Text.Length > 4)
            {
                UsernameDone = true;
            }

            if (PasswordEntry.Text != PasswordEntryConfirm.Text)
                AccountStatus.Text = "Passwords do not match";
            else if (PasswordEntry.Text.Length < 4) AccountStatus.Text = "Password needs to be at least 6 characters";
            else
            {
                AccountStatus.Text = " ";
                PasswordDone = true;
            }

            if (UsernameDone && PasswordDone)
            {
                UserCall serverCalls = new UserCall();
                string ans = serverCalls.ObjectAdd(UsernameEntry.Text, PasswordEntry.Text);
                AccountStatus.Text = ans;
            }

        }

        private void PasswordEntryConfirm_Completed(object sender, EventArgs e)
        {
            
        }
    }
}