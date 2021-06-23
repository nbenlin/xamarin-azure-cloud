using projectCdv.Model;
using projectCdv.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectCdv
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;

            experienceEntry.Text = selectedPost.Experience;
            countryEntry.Text = selectedPost.Country;
            cityEntry.Text = selectedPost.City;
            addressEntry.Text = selectedPost.Address;
        }

        void UpdateButton_Clicked(object sender, System.EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully updated", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be updated", "Ok");
            }
        }

        void DeleteButton_Clicked(object sender, System.EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully deleted", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
            }
        }
    }
}