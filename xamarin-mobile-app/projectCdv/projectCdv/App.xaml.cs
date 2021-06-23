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

        public static Color BarBackgroundColor { get; set; }
        public Color BarTextColor { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            BarBackgroundColor = Color.FromHex("#00C2CB");
            BarTextColor = Color.White;
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
