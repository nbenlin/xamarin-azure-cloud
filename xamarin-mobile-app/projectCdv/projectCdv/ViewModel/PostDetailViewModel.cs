using projectCdv.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace projectCdv.ViewModel
{
    public class PostDetailViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        Post selectedPost;

        public PostDetailViewModel(Post selectedPost)
        {
            this.selectedPost = selectedPost;
        }




        private Post post;

        public Post Post
        {
            get { return post; }
            set { post = value; OnPropertyChanged("Post"); }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                Post = new Post()
                {
                    Experience = this.Experience,
                    //Venue = this.venue
                };
                OnPropertyChanged("Experience");
            }
        }



        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void UpdateSelectedPost(Post selectedPost)
        {
            try
            {
                Post.UpdateSelectedPost(post);
                await App.Current.MainPage.DisplayAlert("Success", "Experience succesfully updated", "Ok");
            }
            catch (NullReferenceException nre)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be updated", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be updated", "Ok");
            }
        }
        


    }
}
