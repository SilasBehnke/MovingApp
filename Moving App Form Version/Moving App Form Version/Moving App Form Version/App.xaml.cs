using Moving_App_Form_Version.Services;
using Moving_App_Form_Version.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moving_App_Form_Version
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
