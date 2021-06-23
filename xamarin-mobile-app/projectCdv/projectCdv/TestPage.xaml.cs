using Newtonsoft.Json;
using projectCdv.Helpers;
using projectCdv.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectCdv
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {

        RestService _restService;
            
        public TestPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

       

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            List<User> users = await _restService.GetUsersAsync(Constants.AzureFunctionURL);
            collectionView.ItemsSource = users;
        }

        private async void userSaveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                User user = new User
                {
                    Email = userEmail.Text,
                    Password = userPassword.Text
                };
                await _restService.SaveUserAsync(user);
                await DisplayAlert("Successfull", "Inserted to database.", "Ok");
            }
            catch
            {
                await DisplayAlert("Failure", "Error inserto to database", "Ok");
            }
            
        }
    }
}