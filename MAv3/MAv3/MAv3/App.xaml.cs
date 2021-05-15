using Moving_App_Form_Version.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAv3
{
    public partial class App : Application
    {
        public int UserID;
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
