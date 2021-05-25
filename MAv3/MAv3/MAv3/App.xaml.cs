using MAv3.Views;
using Moving_App_Form_Version.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAv3
{
    public partial class App : Application
    {
        public static string UserID;
        public static string ItemName;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
