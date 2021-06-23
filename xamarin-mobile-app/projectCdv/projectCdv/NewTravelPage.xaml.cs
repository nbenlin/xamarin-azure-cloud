    using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
        private object image1;

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

        private async void selectPictureButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device", "Ok");
                return;
            }
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImage == null)
            {
                await DisplayAlert("Error", "There was an error to get your picture", "Ok");
                return;
            }

            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }

        private async void addPictureButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync();

                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
            }
            catch(Exception)
            {
                await DisplayAlert("Failure", "You didn't save image", "Ok");
            }

        }
    }
}