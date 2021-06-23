    using Plugin.Geolocator;
using projectCdv.Helpers;
using projectCdv.Logic;
using projectCdv.Model;
using projectCdv.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectCdv
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        NewTravelViewModel viewModel;
        public NewTravelPage()
        {
            InitializeComponent();

            viewModel = new NewTravelViewModel();
            BindingContext = viewModel;

            new ToolbarItem() { Icon = "ic_action_save.png" };
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Use with forsquare API
            //var locator = CrossGeolocator.Current;
            //var position = await locator.GetPositionAsync();

            //var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
           // venueListView.ItemsSource = venues;
        }
        

   
    }
}