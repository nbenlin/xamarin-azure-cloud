using projectCdv.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace projectCdv.ViewModel
{
    public class MapPageViewModel
    {
        public ObservableCollection<Post> Posts { get; set; }

        public MapPageViewModel()
        {
            Posts = new ObservableCollection<Post>();
        }

        public async void UpdatePosts()
        {
            var posts = await Post.Read();
            if (posts != null)
            {
                Posts.Clear();
                foreach (var post in posts)
                    Posts.Add(post);
            }
        }
    }
}
