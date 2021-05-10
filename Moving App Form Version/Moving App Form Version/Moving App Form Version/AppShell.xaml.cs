using Moving_App_Form_Version.ViewModels;
using Moving_App_Form_Version.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Moving_App_Form_Version
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
