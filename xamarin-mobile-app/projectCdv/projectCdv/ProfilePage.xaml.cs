using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectCdv.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectCdv
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            new ToolbarItem() { Icon = "ic_action_profile.png" };

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var postTable = await Post.Read();

            var categoriesCount = Post.PostCategories(postTable);

            categoriesListView.ItemsSource = categoriesCount;

            postCountLabel.Text = postTable.Count.ToString();
            
        }
    }
}