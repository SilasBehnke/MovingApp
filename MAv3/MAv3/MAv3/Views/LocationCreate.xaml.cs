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
    public partial class LocationCreate : ContentPage
    {
        List<string> LocationTypes = new List<string>();
        public LocationCreate()
        {
            InitializeComponent();
            LocationTypes.Add("Bedroom");
            LocationTypes.Add("Kitchen");
            LocationTypes.Add("Storage");
            LocationTypes.Add("Mudroom");
            LocationTypes.Add("Laundry");
            LocationTypes.Add("Basement");
            LocationTypes.Add("Attic");
            LocationTypes.Add("Office");

            LocationPicker.ItemsSource = LocationTypes;
           
        }
    }
}