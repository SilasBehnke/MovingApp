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
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e) //Box
        {
            Navigation.PushAsync(new BoxCreate());
        }

        private void Button_Clicked_1(object sender, EventArgs e) //Location
        {
            Navigation.PushAsync(new LocationCreate());

        }
    }
}