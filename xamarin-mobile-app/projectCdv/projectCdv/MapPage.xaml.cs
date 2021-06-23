using projectCdv.Model;
using projectCdv.ViewModel;
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
    public partial class MapPage : ContentPage
    {
        MapPageViewModel viewModel;
        public MapPage()
        {
            InitializeComponent();

            viewModel = new MapPageViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();
        }

        private async void placesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = placesListView.SelectedItem as Post;

            if (selectedPost != null)
            {
                var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

                var lat = 52.4078059;
                var lon = 16.9314785;

                try
                {
                    await Map.OpenAsync(new Xamarin.Essentials.Location(lat, lon), options);
                }
                catch (Exception ex)
                {
                    // No map application available to open
                }
            }
        }
    }
}