using Microsoft.WindowsAzure.MobileServices;
using projectCdv.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectCdv
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public static MobileServiceClient MobileService = new MobileServiceClient("https://xamtravelexpapp.azurewebsites.net");
        public static User user = new User();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        // Constructor for sqlite
        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
