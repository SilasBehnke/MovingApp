using Moving_App_Form_Version.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Moving_App_Form_Version.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}