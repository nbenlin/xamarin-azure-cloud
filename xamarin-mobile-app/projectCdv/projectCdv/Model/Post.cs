using Newtonsoft.Json;
using projectCdv.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace projectCdv.Model
{
    public class Post : INotifyPropertyChanged
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set { experience = value; OnPropertyChanged("Experience"); }
        }

        /*
        private string venueName;

        public string VenueName
        {
            get { return venueName; }
            set { venueName = value; OnPropertyChanged("VenueName"); }
        }
        */
        private string categoryId;

        public string CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; OnPropertyChanged("CategoryId"); }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; OnPropertyChanged("CategoryName"); }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; OnPropertyChanged("Latitude"); }
        }

        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; OnPropertyChanged("Longitude"); }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set { distance = value; OnPropertyChanged("Distance"); }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; OnPropertyChanged("Country"); }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }



        private DateTimeOffset createdat;

        public DateTimeOffset CREATEDAT
        {
            get { return createdat; }
            set { createdat = value; OnPropertyChanged("createdat"); }
        }


        /*
        private Venue venue;

        [JsonIgnore]
        public Venue Venue
        {
            get { return venue; }
            set
            {
                venue = value;

                if (venue.categories != null)
                {
                    var firstCategory = venue.categories.FirstOrDefault();

                    if (firstCategory != null)
                    {
                        CategoryId = firstCategory.id;
                        CategoryName = firstCategory.name;
                    }
                }

                if (venue.location != null)
                {
                    Address = venue.location.address;
                    Distance = venue.location.distance;
                    Latitude = venue.location.lat;
                    Longitude = venue.location.lng;
                }
                VenueName = venue.name;
                UserId = App.user.Id;

                OnPropertyChanged("Venue");
            }
        }
        */

        public event PropertyChangedEventHandler PropertyChanged;


        public static async void Insert(Post post)
        {
            var location = await Localization.GetMyLocation();
            var encodedLocation = await location.EncodeLocation();

            var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
            var placemarkDetails = placemarks?.FirstOrDefault();
            var country = placemarkDetails.CountryName;
            var city = placemarkDetails.Locality;
            var address = placemarkDetails.SubLocality + " " + placemarkDetails.Thoroughfare + " " + placemarkDetails.SubThoroughfare;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                post.CREATEDAT = DateTimeOffset.Now;
                post.latitude = location.Latitude;
                post.longitude = location.Longitude;
                post.country = country;
                post.city = city;
                post.address = address;
                int rows = conn.Insert(post);
            }
        }

        public static async Task<List<Post>> Read()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                return posts;
            }
        }

        public static async Task<List<Post>> ReadPlaces()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();

                return posts;
            }
        }

        public static Dictionary<string, int> PostCategories(List<Post> postTable)
        {
            var categories = (from p in postTable
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();


            foreach (var category in categories)
            {
                try
                {
                    var count = (from post in postTable
                                 where post.CategoryName == category
                                 select post).ToList().Count;
                    categoriesCount.Add(category, count);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return categoriesCount;
        }


        public async static void UpdateSelectedPost(Post selectedPost)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
