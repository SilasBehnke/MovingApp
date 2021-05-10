using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Moving_App_v2.Views;

namespace Moving_App_v2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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
