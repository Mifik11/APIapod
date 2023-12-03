using APIapod.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace APIapod.Views
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