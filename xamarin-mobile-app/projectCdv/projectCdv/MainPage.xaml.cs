using projectCdv.Model;
using projectCdv.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace projectCdv
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            viewModel = new MainViewModel();
            BindingContext = viewModel;

            //iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
        }
    }
}
