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
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel viewModel;
        public HistoryPage()
        {
            InitializeComponent();

            viewModel = new HistoryViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();

            /*
            var posts = await Post.Read();
            postListView.ItemsSource = posts; 
            */
        }

        private void postListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postListView.SelectedItem as Post;

            if (selectedPost != null)
            {
                Navigation.PushAsync(new PostDetailPage(selectedPost));
            }
        }
    }
}